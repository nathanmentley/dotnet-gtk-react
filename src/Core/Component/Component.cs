/*
Copyright 2019 Nathan Mentley

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;

namespace dnetreact
{
    public abstract class Component<RenderableType, StateType, PropsType>: IDisposable
        where RenderableType: BaseRenderable
        where StateType: BaseState
        where PropsType: BaseProps
    {
        private bool disposed = false;

        public abstract StateType GetInitialState(PropsType props);
        protected abstract RenderableType _Render(ComponentContext<RenderableType, StateType, PropsType> context);
        
        public virtual Boolean ShouldUpdate(ComponentContext<RenderableType, StateType, PropsType> context) {
            return true;
        }
        public virtual void DidMount(ComponentContext<RenderableType, StateType, PropsType> context) {}
        public virtual void WillRender(ComponentContext<RenderableType, StateType, PropsType> context) {}
        public virtual void DidRender(ComponentContext<RenderableType, StateType, PropsType> context) {}
        public virtual void WillUnmount(ComponentContext<RenderableType, StateType, PropsType> context) {}

        public RenderableType Render(ComponentContext<RenderableType, StateType, PropsType> context) {
            return this._Render(context);
        }

        protected virtual void _Dispose() {
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this); 
        }

        private void Dispose(bool disposing) {
            if (disposed)
                return; 
      
            if (disposing) {
                _Dispose();
            }
            
            disposed = true;
        }
    }
}
