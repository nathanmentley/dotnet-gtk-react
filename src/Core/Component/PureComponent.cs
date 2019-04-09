/*
Copyright 2019 Nathan Mentley

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;

namespace dnetreact
{
    public class EmptyState: BaseState {}

    public abstract class PureComponent<PropsType>: Component<EmptyState, PropsType>
        where PropsType: BaseProps
    {
        public override sealed EmptyState GetInitialState(PropsType props) {
            return new EmptyState();
        }
        protected override sealed RenderResult _Render(ComponentContext<EmptyState, PropsType> context) {
            return _Render(context.GetProps());
        }
        
        public override sealed Boolean ShouldUpdate(ComponentContext<EmptyState, PropsType> context) {
            //TODO: Only return true if we see prop or state changes.
            return true;
        }
        public override sealed void DidMount(ComponentContext<EmptyState, PropsType> context) {
            DidMount(context.GetProps());
        }
        public override sealed void WillRender(ComponentContext<EmptyState, PropsType> context) {
            WillRender(context.GetProps());
        }
        public override sealed void DidRender(ComponentContext<EmptyState, PropsType> context) {
            DidRender(context.GetProps());
        }
        public override sealed void WillUnmount(ComponentContext<EmptyState, PropsType> context) {
            WillUnmount(context.GetProps());
        }
        protected override sealed void _BindElements(ComponentContext<EmptyState, PropsType> context) {
            _BindElements(context.GetProps());
        }

        protected abstract RenderResult _Render(PropsType props);

        protected virtual void DidMount(PropsType props) {}
        protected virtual void WillRender(PropsType props) {}
        protected virtual void DidRender(PropsType props) {}
        protected virtual void WillUnmount(PropsType props) {}
        protected virtual void _BindElements(PropsType props) {}
    }
}
