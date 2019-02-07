/*
Copyright 2019 Nathan Mentley

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.IO;

using Gtk;

namespace dnetreact
{
    public class MainGtkApp: Window {
        private static MainGtkApp _instance { get; set; }

        public static MainGtkApp Get() {
            return _instance;
        }

        public static MainGtkApp Create(String glade, String windowId) {
            if(_instance == null) {
                using(Stream stream = glade.ToStream()) {
                    Builder builder = new Builder(stream);

                    _instance = new MainGtkApp(builder, builder.GetObject(windowId).Handle);
                }
            } else {
                _instance.builder.AddFromString(glade);
            }

            return _instance;
        }
        public Builder builder { get; private set; }

        protected MainGtkApp(Builder _builder, IntPtr handle) : base(handle) {
            builder = _builder;
            //builder.Autoconnect(this);
        }
    }
}
