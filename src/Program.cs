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
            Console.WriteLine("Hello World!");

            /*
            <Window>
                <Box>
                    <Label />
                    <Button />
                </Box>
            </Window>
            */
            GtkAppRunner.Execute(
                new WindowComponent(), new WindowProps() { title = "Ziggy" }, new List<IComponentProcessor>() {
                    new ComponentProcessor<BoxResult, BoxState, BoxProps>(new BoxComponent(), new BoxProps(), new List<IComponentProcessor>() {
                            new ComponentProcessor<LabelResult, LabelState, LabelProps>(new LabelComponent(), new LabelProps() { label = "LC" }),
                            new ComponentProcessor<ButtonResult, ButtonState, ButtonProps>(new ButtonComponent(), new ButtonProps() { label = "Spooky" })
                        }
                    )
                }
            );
        }
    }
}
