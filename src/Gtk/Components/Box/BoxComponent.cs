/*
Copyright 2019 Nathan Mentley

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Xml.Serialization;

namespace dnetreact
{
    public class BoxComponent: Component<BoxResult, BoxState, BoxProps>{
        public override BoxState GetInitialState(BoxProps props) {
            return new BoxState();
        }

        public override BoxResult Render(ComponentContext<BoxResult, BoxState, BoxProps> context) {
            return new BoxResult() {
                BoxData = new BoxResult.BoxResultObject() {
                    id = "_button1",
                    label = context.GetProps().label,
                    visible = true,
                    canFocus = true,
                    receivesDefault = true
                },
                PackingDetails = new PackingStructure() {
                    expand = true,
                    fill = true,
                    position = 1
                }
            };
        }

        private void OnClick(ComponentContext<BoxResult, BoxState, BoxProps> context) {
            if(context.GetProps().OnClick != null) {
                context.GetProps().OnClick();
            }
        }
    }
}

