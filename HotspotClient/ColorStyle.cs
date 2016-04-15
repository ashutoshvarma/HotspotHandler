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
        public ColorScheme Pink = new ColorScheme(Primary.Pink600, Primary.Pink600, Primary.Pink500, Accent.Pink700, TextShade.WHITE);
        public ColorScheme DarkGreen = new ColorScheme(Primary.Teal800, Primary.Teal800, Primary.Teal600, Accent.Teal700, TextShade.WHITE);

        public string[] StyleNames
        {
            get
            {
                return new string[] { "Blue", "Green", "Red", "Pink", "DarkGreen" };
            }
        }
    }
}
