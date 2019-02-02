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
    public class ComponentProcessor<RenderableType, StateType, PropsType>: IDisposable, IComponentProcessor, IComponentEventDelegate
        where RenderableType: BaseRenderable
        where StateType: BaseState
        where PropsType: BaseProps
    {
        private bool disposed = false;

        private Component<RenderableType, StateType, PropsType> component;
        private ComponentContext<RenderableType, StateType, PropsType> context;

        public ComponentProcessor(
                Component<RenderableType, StateType, PropsType> _component, PropsType props, IList<IComponentProcessor> children
        ) {
            component = _component;
            context = new ComponentContext<RenderableType, StateType, PropsType>(_component, props, children, this);
        }

        public void ForceUpdate() {
            _Render();
        }

        public void OnComponentStateUpdate() {
            Render();
        }
        /*
        public void OnComponentPropsUpdate() {
            Render();
        }*/
        
        protected void Render() {
            if (component.ShouldUpdate(context)) {
                _Render();
            }
        }

        protected void _Render() {
            component.WillRender(context);
            RenderResult<RenderableType> result = new RenderResult<RenderableType>(component.Render(context));
            component.DidRender(context);
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this); 
        }

        private void Dispose(bool disposing) {
            if (disposed)
                return; 
      
            if (disposing) {
                component.Dispose();
                context.Dispose();
            }
            
            disposed = true;
        }
    }
}
