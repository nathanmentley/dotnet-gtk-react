/*
Copyright 2019 Nathan Mentley

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Xml.Serialization;

namespace dnetreact
{
    public class LabelResult: BaseRenderable {
        public class LabelResultObject {
            [XmlAttribute("class")]
            public String className { get { return "GtkLabel"; } }
            [XmlAttribute("id")]
            public String id { get; set; }

            [XmlElement("label")]
            public String label { get; set; }
            [XmlElement("visible")]
            public Boolean visible { get; set; }
            [XmlElement("can_focus")]
            public Boolean canFocus { get; set; }
            [XmlElement("receives_default")]
            public Boolean receivesDefault { get; set; }
        }

        [XmlElement("object")]
        public LabelResultObject LabelData { get; set; }
        [XmlElement("packing")]
        public PackingStructure PackingDetails { get; set; }
    }
}
