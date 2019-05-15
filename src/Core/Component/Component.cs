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
    public abstract class Component<StateType, PropsType>: BaseComponent
        where StateType: BaseState
        where PropsType: BaseProps
    {
        //data
        protected bool initialized { get; private set ;} = false;
        protected PropsType props { get; private set; } = null;
        protected StateType state { get; private set; } = null;
        protected IEnumerable<IComponent> children { get; private set; } = new List<IComponent>();
        private bool disposed { get; set ;} = false;
        private RenderResult lastResult { get; set; } = null;

        //Overridables
        protected abstract StateType _GetInitialState();
        protected abstract RenderResult _Render();
        //Optional overrides
        protected virtual Boolean ShouldUpdate(PropsType nextProps, StateType nextState) {
            //TODO: Only return true if we see prop or state changes.
            return true;
        }
        protected virtual void _Init() {}
        protected virtual void _DidMount() {}
        protected virtual void _WillRender() {}
        protected virtual void _DidRender() {}
        protected virtual void _WillUnmount() {}
        protected virtual void _Dispose() {}

        //Sealed
        internal sealed override void Init(String _key, Props _props, IEnumerable<IComponent> _children = null) {
            initialized = true;

            props = _props.BuildProps<PropsType>();
            children = _children;
            state = GetInitialState();

            //TODO: Handle key.

            //TODO: is this needed for the lifecycle? I think _DidMount is really what is useful?
            _Init();
        }

        internal protected StateType GetInitialState() {
            return _GetInitialState();
        }

        internal protected void DidMount() {
            _DidMount();
        }
        internal protected void WillRender() {
            _WillRender();
        }
        internal protected void DidRender() {
            _DidRender();
        }
        internal protected void WillUnmount() {
            _WillUnmount();
        }

        internal protected RenderResult Render(PropsType nextProps, StateType nextState) {
            if(!initialized) {
                //TODO: throw exception. <- This probably means the component wasn't created with Deact.Create
                // and the dev is doing something silly and unsupported.
            }

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

        public override void ForceUpdate() {
            Render();
        }

        protected void SetState(StateType newState) {
            //TODO: ensure we're not rendering when this is called?
            Render(props, newState);
        }

        internal void SetProps(PropsType newProps) {
            //TODO: ensure we're not rendering when this is called?
            Render(newProps, state);
        }

        //IDisposable
        public override void Dispose() {
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
