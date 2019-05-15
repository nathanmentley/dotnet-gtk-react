/*
Copyright 2019 Nathan Mentley

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;

using Gtk;

using Deact.Core;

namespace Deact.Gtk
{
    internal interface IGtkComponent {
        Widget GetWidget();

        Boolean IsMounted { get; set; }
    }

    public abstract class GtkComponent<GTKWidgetType, StateType, PropsType>: Component<StateType, PropsType>, IGtkComponent
    where GTKWidgetType: Widget
    where StateType: BaseState
    where PropsType: BaseProps {
        protected GTKWidgetType widget { get; private set; }
        public Boolean IsMounted { get; set; }
        protected abstract GTKWidgetType CreateWidget();
        protected abstract void BindEvents();

        public Widget GetWidget() {
            return widget;
        }
        protected virtual void __DidMount() {}
        protected sealed override void _DidMount() {
            widget = CreateWidget();
            BindEvents();

            IsMounted = false;

            __DidMount();
        }

        protected virtual void __DidRender() {}
        protected sealed override void _DidRender() {
            if(children != null) {
                foreach(var child in children) {
                    if(child is IGtkComponent) {
                        if(!((IGtkComponent)child).IsMounted) {
                            if(GetWidget() is Container) {
                                var childWidget = ((IGtkComponent)child).GetWidget();

                                ((Container)GetWidget()).Add(childWidget);

                                ((IGtkComponent)child).IsMounted = true;
                            }
                        }
                    }
                }
            }

            __DidRender();
        }
    }
}
