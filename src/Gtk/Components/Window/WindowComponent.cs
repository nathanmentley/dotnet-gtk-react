/*
Copyright 2019 Nathan Mentley

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;

namespace dnetreact
{
    public class WindowComponent: Component<WindowResult, WindowState, WindowProps>{
        public override WindowState GetInitialState(WindowProps props) {
            return new WindowState();
        }

        protected override WindowResult _Render(ComponentContext<WindowResult, WindowState, WindowProps> context) {
            Console.WriteLine("render window children: " + context.GetRenderedChildren().Count);

            return new WindowResult(){
                id = "MainWindow",
                properties = new List<PropertyStructure>() {
                    new PropertyStructure() {
                        name = "can_focus",
                        value = "false"
                    },
                    new PropertyStructure() {
                        name = "title",
                        value = context.GetProps().title
                    },
                    new PropertyStructure() {
                        name = "default_width",
                        value = "240"
                    },
                    new PropertyStructure() {
                        name = "default_height",
                        value = "240"
                    }
                },
                children = context.GetRenderedChildren()
            };
        }
    }
}
