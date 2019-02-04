/*
Copyright 2019 Nathan Mentley

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

using Gtk;

namespace dnetreact
{
    public class AppComponent: Component<AppResult, AppState, AppProps>{
        public class MainAppWindow: Window {
            private Builder builder;

            public static MainAppWindow Create(String glade) {
                using(Stream stream = glade.ToStream()) {
                    Builder builder = new Builder(stream);
                    return new MainAppWindow(builder, builder.GetObject("MainWindow").Handle);
                }
            }

            protected MainAppWindow(Builder _builder, IntPtr handle) : base(handle) {
                builder = _builder;
                builder.Autoconnect(this);
            }
        }

        public override AppState GetInitialState(AppProps props) {
            return new AppState();
        }

        protected override AppResult _Render(ComponentContext<AppResult, AppState, AppProps> context) {
            AppResult ret = new AppResult() {
                requires = new AppResult.Requires(),
                children = context.GetRenderedChildren()
            };

            var window = MainAppWindow.Create(GenerateGlad(ret));
            window.Show();

            return ret;
        }

        private String GenerateGlad(AppResult ret) {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(AppResult), new Type[] {
                typeof(BoxResult),
                typeof(ButtonResult),
                typeof(LabelResult),
                typeof(WindowResult)
            });
            
            using(StringWriter sww = new UTF8StringWriter())
            {
                using(XmlWriter writer = XmlWriter.Create(sww, new XmlWriterSettings() {NamespaceHandling = NamespaceHandling.OmitDuplicates}))
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    xsSubmit.Serialize(writer, ret, ns);
                    String xml = sww.ToString(); // Your XML

                    //A bit hacky. We need to drop the type and namespaces out of the result for glade.
                    xml = Regex.Replace(xml, "p(\\d)+:type=\"(.*?)\"", "");
                    xml = Regex.Replace(xml, "xmlns:p(\\d)+=\"(.*?)\"", "");

                    return xml;
                }
            }
        }
    }
}
