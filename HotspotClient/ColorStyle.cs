//MIT License

//Copyright (c) 2016 Ashutosh Varma

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.


using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotspotClient
{
    class ColorStyle
    {
        public ColorScheme Blue = new ColorScheme(Primary.LightBlue700, Primary.LightBlue800, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        public ColorScheme Green = new ColorScheme(Primary.Green600, Primary.Green500, Primary.Green400, Accent.Green700, TextShade.WHITE);
        public ColorScheme Red = new ColorScheme(Primary.Red800, Primary.Red700, Primary.Red600, Accent.Red200, TextShade.WHITE);
        public ColorScheme Pink = new ColorScheme(Primary.Pink600, Primary.Pink700, Primary.Pink500, Accent.Pink700, TextShade.WHITE);
        public ColorScheme DarkGreen = new ColorScheme(Primary.Teal800, Primary.Teal900, Primary.Teal600, Accent.Teal700, TextShade.WHITE);

        public string[] StyleNames
        {
            get
            {
                return new string[] { "Blue", "Green", "Red", "Pink", "DarkGreen" };
            }
        }
    }
}
