/*
Copyright 2019 Nathan Mentley

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace dnetreact
{
    public class ComponentContext<StateType, PropsType>: IDisposable
        where StateType: BaseState
        where PropsType: BaseProps
    {
        private bool disposed = false;

        private PropsType props;
        private StateType state;
        private IList<IComponentProcessor> children;
        private IComponentEventDelegate handler;

        public ComponentContext(
                Component<StateType, PropsType> component,
                Props _props,
                IList<IComponentProcessor> _children,
                IComponentEventDelegate _handler
        ) {
            props = _props.BuildProps<PropsType>();
            children = _children;
            handler = _handler;
            state = component.GetInitialState(props);
        }

        public PropsType GetProps() {
            return props;
        }

        public IList<IComponentProcessor> GetChildren() {
            return children;
        }

        public List<RenderResult> GetRenderedChildren() {
            return GetChildren().Select(x => x.ForceUpdate()).Where(x => x != null).ToList();
        }

        public StateType GetState() {
            return state;
        }

        public void SetState(StateType _state) {
            state = _state;

            handler.OnComponentStateUpdate();
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this); 
        }

        private void Dispose(bool disposing) {
            if (disposed)
                return; 
      
            if (disposing) {
                foreach(IComponentProcessor child in children) {
                    child.Dispose();
                }
            }
            
            disposed = true;
        }
    }
}
