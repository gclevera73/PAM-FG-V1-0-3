using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApplication3
{
    class Library
    {
        public ImageList Eyes { get; set; }
        public ImageList Hairs { get; set; }
        public ImageList Mouths { get; set; }
        public Image Base { get; set; }
        public string[] Folders = new string[] { "Eyes", "Hairs", "Mouths" };

        public Library()
        {

            Eyes = new ImageList();
            Eyes.ImageSize = new Size(150, 150);
            Hairs = new ImageList();
            Hairs.ImageSize = new Size(150, 150);
            Mouths = new ImageList();
            Mouths.ImageSize = new Size(150, 150);
            Base = Image.FromFile("base.png");
            

            for (int i = 0; i < Folders.Length; i++)
                {
                    DirectoryInfo Dane = new DirectoryInfo(Folders[i]);
                    FileInfo[] Images = Dane.GetFiles("*.png");


                        for (int j = 0; j < Images.Length; j++)
                                {

                                        switch (i)
                                        {
                                            case 0:
                                                Eyes.Images.Add(Image.FromFile(Images[j].FullName));
                                                break;

                                            case 1:
                                                Hairs.Images.Add(Image.FromFile(Images[j].FullName));
                                                break;

                                            case 2:
                                                Mouths.Images.Add(Image.FromFile(Images[j].FullName));
                                                break;

                                        }

                                }
                     }


            }




    }
}
