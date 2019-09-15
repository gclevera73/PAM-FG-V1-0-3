using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    class Face
    {
        public Image Eyes { get; set; }
        public Image Hairs { get; set; }
        public Image Mouths { get; set; }
        public Bitmap Base { get; set; }
        public Bitmap Avatar {get ; set;}
        
        public Face(Image _base, Image _Eyes, Image _Mouths, Image _Hairs)
        {
            Base = new Bitmap(_base, new Size(120, 150)); ;
            Eyes = _Eyes;
            Hairs = _Hairs;
            Mouths = _Mouths;
            Avatar = new Bitmap(150, 150);
        }
        public void drawFace()
        {
            Graphics g = Graphics.FromImage(Avatar);
            g.Clear(Color.White);
            g.ScaleTransform(1F, 1F);
            g.DrawImage(Base, new Point(15, 0));
            g.DrawImage(Eyes, new Point(0, 0));
            g.DrawImage(Hairs, new Point(0, 0));
            g.DrawImage(Mouths, new Point(0, 0));
        }
        public void eyes_change(Image _eyes)
        {
            Eyes = _eyes;
            drawFace();
        }

        public void mouths_change(Image _mouths)
        {
            Mouths = _mouths;
            drawFace();
        }

        public void hair_change(Image _hair)
        {
            Hairs = _hair;
            drawFace();
        }

        public static bool ChangeColors(Bitmap b, int red, int green, int blue)
        {
            if (red < -255 || red > 255) return false;
            if (green < -255 || green > 255) return false;
            if (blue < -255 || blue > 255) return false;

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                int nOffset = stride - b.Width * 4;
                int nPixel;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < b.Width; ++x)
                    {
                        nPixel = p[2] + red;
                        nPixel = Math.Max(nPixel, 0);
                        p[2] = (byte)Math.Min(255, nPixel);

                        nPixel = p[1] + green;
                        nPixel = Math.Max(nPixel, 0);
                        p[1] = (byte)Math.Min(255, nPixel);

                        nPixel = p[0] + blue;
                        nPixel = Math.Max(nPixel, 0);
                        p[0] = (byte)Math.Min(255, nPixel);

                        p += 4;
                    }
                    p += nOffset;
                }
            }
            b.UnlockBits(bmData);
            return true;
        }
    }
}
