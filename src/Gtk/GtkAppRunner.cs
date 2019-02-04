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
    public class GtkAppRunner: AppRunner {
        public static void Execute<RenderableType, StateType, PropsType>(
            Component<RenderableType, StateType, PropsType> component,
            PropsType props,
            IList<IComponentProcessor> children = null
        )
            where RenderableType: BaseRenderable
            where StateType: BaseState
            where PropsType: BaseProps
        {
            GtkAppRunner runner = new GtkAppRunner();

            runner.Run(component, props, children);
        }

        protected void Run<RenderableType, StateType, PropsType>(
            Component<RenderableType, StateType, PropsType> component,
            PropsType props,
            IList<IComponentProcessor> children = null
        )
            where RenderableType: BaseRenderable
            where StateType: BaseState
            where PropsType: BaseProps
        {
            _Run(
                new GtkWidgetToolkit(),
                new AppComponent(),
                new AppProps(),
                new List<IComponentProcessor>() {
                    new ComponentProcessor<RenderableType, StateType, PropsType>(
                        component,
                        props,
                        children
                    )
                }
            );
        }
    }
}
