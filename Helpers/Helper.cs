using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace EcomerceProject.Helpers
{
    public class Helper
    {
        public static class Barcode
        {
            public static dynamic Set(string barcode)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    //The Image is drawn based on length of Barcode text.
                    using (Bitmap bitMap = new Bitmap(barcode.Length * 40, 80))
                    {
                        //The Graphics library object is generated for the Image.
                        using (Graphics graphics = Graphics.FromImage(bitMap))
                        {
                            //The installed Barcode font.
                            Font oFont = new Font("IDAutomationHC39M Free Version", 16);
                            PointF point = new PointF(2f, 2f);

                            //White Brush is used to fill the Image with white color.
                            SolidBrush whiteBrush = new SolidBrush(Color.White);
                            graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);

                            //Black Brush is used to draw the Barcode over the Image.
                            SolidBrush blackBrush = new SolidBrush(Color.Black);
                            //graphics.DrawString("*" + barcode + "*", oFont, blackBrush, point);
                            graphics.DrawString(barcode, oFont, blackBrush, point);
                        }

                        //The Bitmap is saved to Memory Stream.
                        bitMap.Save(ms, ImageFormat.Png);

                        //The Image is finally converted to Base64 string.
                        return "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }
    }
}
