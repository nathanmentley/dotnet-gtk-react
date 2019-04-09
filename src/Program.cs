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
    class Program
    {
        static void Main(string[] args)
        {
            /*
            If we had a jsx like preprocessor we could write this:
            GtkAppRunner.Execute(
                <Window Title="Ziggy">
                    <HBox>
                        <Label Label={this.localVariable} />
                        <Button Label="Hello World Button" OnClick={this.callBack} />
                    </HBox>
                </Window>
            );

            Which is the ultimate goal. Tho, I'm not deadset on the xml format if something is still clean and easy to do.
            */
            GtkAppRunner.Execute(
                new WindowComponent(), new Props() {
                        {
                            "Title", "DotNet React Window Title"
                        }
                    }, new List<IComponentProcessor>() {
                    new ComponentProcessor<EmptyState, BoxProps>(new HBoxComponent(), new Props(), new List<IComponentProcessor>() {
                        new ComponentProcessor<EmptyState, LabelProps>(new LabelComponent(), new Props{
                            {
                                "Label", "Hello World"
                            }
                        }),
                        new ComponentProcessor<EmptyState, ButtonProps>(new ButtonComponent(), new Props{
                            {
                                "Label", "Hello World Button"
                            },
                            {
                                "OnClick", (Action)(() => { Console.WriteLine("Button Click"); })
                            }
                        })
                    })
                }
            );
        }
    }
}
