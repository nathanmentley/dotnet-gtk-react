/*
Copyright 2019 Nathan Mentley

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;

using Gtk;

using Deact.Core;

namespace Deact.Gtk.Components
{
    abstract public class BoxComponent<BoxType>: Component<EmptyState, BoxProps>, MGtkComponent<BoxType, BoxProps>
    where BoxType: Box, new() {
        public BoxType widget { get; private set; }

        protected override EmptyState GetInitialState() {
            return new EmptyState();
        }

        protected override void _DidMount() {
            BindEvents();

            widget = new BoxType();
        }

        protected override RenderResult _Render() {
            return null;
        }

        public void BindEvents() {}
    }
}