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
    public class ButtonComponent: Component<ButtonResult, ButtonState, ButtonProps>{
        public override ButtonState GetInitialState(ButtonProps props) {
            return new ButtonState();
        }

        public override ButtonResult Render(ComponentContext<ButtonResult, ButtonState, ButtonProps> context) {
            Console.WriteLine("render button children: " + context.GetRenderedChildren().Count);
/*
            [XmlElement("label")]
            public String label { get; set; }
            [XmlElement("visible")]
            public Boolean visible { get; set; }
            [XmlElement("can_focus")]
            public Boolean canFocus { get; set; }
            [XmlElement("receives_default")]
            public Boolean receivesDefault { get; set; }*/

            return new ButtonResult() {
                ButtonData = new ButtonResult.ButtonResultObject() {
                    id = "_button1",
                    properties = new List<PropertyStructure>() {
                        new PropertyStructure() {
                            name = "label",
                            value = context.GetProps().label
                        },
                        new PropertyStructure() {
                            name = "visible",
                            value = "True"
                        },
                        new PropertyStructure() {
                            name = "can_focus",
                            value = "True"
                        },
                        new PropertyStructure() {
                            name = "receives_default",
                            value = "True"
                        }
                    }
                },
                PackingDetails = new PackingStructure() {
                    properties = new List<PropertyStructure>() {
                        new PropertyStructure() {
                            name = "expand",
                            value = "True"
                        },
                        new PropertyStructure() {
                            name = "fill",
                            value = "True"
                        },
                        new PropertyStructure() {
                            name = "position",
                            value = "1"
                        }
                    }
                }
            };
        }

        private void OnClick(ComponentContext<ButtonResult, ButtonState, ButtonProps> context) {
            if(context.GetProps().OnClick != null) {
                context.GetProps().OnClick();
            }
        }
    }
}

