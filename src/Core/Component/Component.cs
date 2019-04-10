/*
Copyright 2019 Nathan Mentley

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Deact.Core
{
    public abstract class Component<StateType, PropsType>: IComponent
        where StateType: BaseState
        where PropsType: BaseProps
    {
        //data
        private bool disposed = false;
        private RenderResult lastResult = null;

        protected PropsType props { get; private set; }
        protected StateType state { get; private set; }
        protected IEnumerable<IComponent> children { get; private set; }

        //constructore
        public Component(Props _props, IEnumerable<IComponent> _children = null) {
            props = _props.BuildProps<PropsType>();
            children = _children;
            state = GetInitialState();
        }

        //Overridables
        protected abstract StateType GetInitialState();
        protected abstract RenderResult _Render();
        
        protected virtual Boolean ShouldUpdate(PropsType nextProps, StateType nextState) {
            //TODO: Only return true if we see prop or state changes.
            return true;
        }
        protected virtual void DidMount() {}
        protected virtual void WillRender() {}
        protected virtual void DidRender() {}
        protected virtual void WillUnmount() {}
        
        protected virtual void _Dispose() {}

        //Sealed
        internal RenderResult Render(PropsType nextProps, StateType nextState) {
            if(lastResult == null || ShouldUpdate(nextProps, nextState)) {
                props = nextProps;
                state = nextState;

                if(lastResult == null) {
                    DidMount();
                }

                WillRender();
                lastResult = this._Render();
                DidRender();
            }

            return lastResult;
        }

        public RenderResult Render() {
            return Render(props, state);
        }

        public void ForceUpdate() {
            Render();
        }

        protected void SetState(StateType newState) {
            //TODO: ensure we're not rendering?
            Render(props, newState);
        }

        internal void SetProps(PropsType newProps) {
            //TODO: ensure we're not rendering?
            Render(newProps, state);
        }

        //IDisposable
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this); 
        }

        private void Dispose(bool disposing) {
            if (disposed)
                return; 
      
            if (disposing) {
                children?.ToList()?.ForEach(child => child.Dispose());

                WillUnmount();

                _Dispose();
            }
            
            disposed = true;
        }
    }
}
