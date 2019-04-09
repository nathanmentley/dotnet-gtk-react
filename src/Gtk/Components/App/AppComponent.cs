/*
Copyright 2019 Nathan Mentley

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;

namespace dnetreact
{
    public class AppComponent: Component<AppState, AppProps>{
        public override AppState GetInitialState(AppProps props) {
            return new AppState();
        }

        protected override RenderResult _Render(ComponentContext<AppState, AppProps> context) {
            return null;
        }

        protected override void _BindElements(ComponentContext<AppState, AppProps> context) {
            /*if (widget != null) {
                widget.DeleteEvent += OnClose;
            }*/
        }
/*
        private void OnClose(object sender, DeleteEventArgs a)
        {
            GtkWidgetToolkit.Quit();
        }
*/
    }
}
