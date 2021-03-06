/*
Copyright 2019 Nathan Mentley

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;

using Deact;
using Deact.Core;
using Deact.Gtk.Components;

namespace Deact.Gtk
{
    public class GtkAppRunner: AppRunner {
        private static GtkAppRunner _instance { get; set; }

        public static void Execute(IComponent component)
        {
            if(_instance == null) {
                _instance = new GtkAppRunner();
                _instance.Run(component);
            } else {
                //throw exception
            }
        }

        protected internal void Run(IComponent component)
        {
            _Run(
                new GtkWidgetToolkit(),
                Deact.Create<AppComponent, AppProps>(
                    new AppProps(),
                    new List<IComponent>() {
                        component
                    }
                )
            );
        }
    }
}
