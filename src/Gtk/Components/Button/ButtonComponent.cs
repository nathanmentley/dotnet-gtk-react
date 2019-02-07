/*
Copyright 2019 Nathan Mentley

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using Gtk;

namespace dnetreact
{
    public class ButtonComponent: Component<ButtonResult, ButtonState, ButtonProps>, MGtkComponent {
        private Button button { get; set; }

        public override ButtonState GetInitialState(ButtonProps props) {
            return new ButtonState() {
                clicks = 0
            };
        }

        protected override ButtonResult _Render(ComponentContext<ButtonResult, ButtonState, ButtonProps> context) {
            return new ButtonResult() {
                ButtonData = new ButtonResult.ButtonResultObject() {
                    id = "_button1",
                    properties = new List<PropertyStructure>() {
                        new PropertyStructure() {
                            name = "label",
                            value = context.GetProps().label + " clicks: " + context.GetState().clicks
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

        protected override void _BindElements(ComponentContext<ButtonResult, ButtonState, ButtonProps> context) {
            if(button == null) {
                button = this.GetGtkElement<Button>("_button1");
                button.Clicked += (object sender, EventArgs a) => OnClick(context);
            }
        }

        private void OnClick(ComponentContext<ButtonResult, ButtonState, ButtonProps> context) {
            if(context.GetProps().OnClick != null) {
                context.GetProps().OnClick();
            }
        }
    }
}

