/*
Copyright 2019 Nathan Mentley

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace dnetreact
{
    public class WindowResult: BaseRenderable {
        [XmlAttribute("class")]
        public String className { get { return "GtkWindow"; } }
        [XmlAttribute("id")]
        public String id { get; set; }

        [XmlElement("can_focus")]
        public Boolean canFocus { get; set; }
        [XmlElement("title")]
        public String title { get; set; }
        [XmlElement("default_width")]
        public Int32 defaultWidth { get; set; }
        [XmlElement("default_height")]
        public Int32 defaultHeight { get; set; }

        [XmlElement("child")]
        public List<BaseRenderable> children { get; set; }
    }
}
