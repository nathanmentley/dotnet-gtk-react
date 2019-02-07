/*
Copyright 2019 Nathan Mentley

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace dnetreact
{
    public class BoxComponent: Component<BoxResult, BoxState, BoxProps>, MGtkComponent{
        public override BoxState GetInitialState(BoxProps props) {
            return new BoxState();
        }

        protected override BoxResult _Render(ComponentContext<BoxResult, BoxState, BoxProps> context) {
            return new BoxResult() {
                BoxData = new BoxResult.BoxResultObject() {
                    children = context.GetRenderedChildren(),
                    properties = new List<PropertyStructure>() {
                        new PropertyStructure() {
                            name = "visible",
                            value = "True"
                        },
                        new PropertyStructure() {
                            name = "can_focus",
                            value = "False"
                        },
                        new PropertyStructure() {
                            name = "margin_left",
                            value = "4"
                        },
                        new PropertyStructure() {
                            name = "margin_right",
                            value = "4"
                        },
                        new PropertyStructure() {
                            name = "margin_top",
                            value = "4"
                        },
                        new PropertyStructure() {
                            name = "margin_bottom",
                            value = "4"
                        },
                        new PropertyStructure() {
                            name = "orientation",
                            value = "vertical"
                        },
                    }
                },
            };
        }
    }
}

