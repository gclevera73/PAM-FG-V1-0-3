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
    public partial class Form1 : Form
    {

        Library components1 = new Library();
        Face picture;
        int eyesIndex=0, mouthsIndex=0, hairsIndex=0;

        Color eyeColor = new Color();
        Color mouthColor = new Color();
        Color hairColor = new Color();

        int negative = 0, sepia = 0, frozen = 0, grayscale = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i=0; i<components1.Eyes.Images.Count; i++)
            {
                eyesList.Items.Add("", i);
            }

            eyesList.LargeImageList = components1.Eyes;

            for (int i = 0; i < components1.Mouths.Images.Count; i++)
            {
                mouthList.Items.Add("", i);
            }

            mouthList.LargeImageList = components1.Mouths;

            for (int i = 0; i < components1.Hairs.Images.Count; i++)
            {
                hairList.Items.Add("", i);
            }

            hairList.LargeImageList = components1.Hairs;

            picture = new Face(components1.Base, components1.Eyes.Images[0], components1.Mouths.Images[0], components1.Hairs.Images[0]);
            picture.drawFace();
            avatarImage.Image = picture.Avatar;
            faceCode();

        }

        private void hairList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (hairList.SelectedItems.Count > 0)
            {
                
                var tmp = hairList.SelectedItems[0];
                Image image = tmp.ImageList.Images[tmp.ImageIndex];
                RGB_Change colorInput = new RGB_Change();
                colorInput.red = colorInput.green = colorInput.blue = 0;
                if (DialogResult.OK == colorInput.ShowDialog())
                {
                    picture.hair_change(UpdateImageColor(image, hairColor));
                    avatarImage.Image = picture.Avatar;
                    hairsIndex = tmp.ImageIndex;
                    hairColor = Color.FromArgb(colorInput.red, colorInput.green, colorInput.blue);
                    faceCode();
                }
            }
        }
        
        private void mouthList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (mouthList.SelectedItems.Count > 0)
            {

                var tmp = mouthList.SelectedItems[0];
                Image image = tmp.ImageList.Images[tmp.ImageIndex];
                RGB_Change colorInput = new RGB_Change();
                colorInput.red = colorInput.green = colorInput.blue = 0;
                if (DialogResult.OK == colorInput.ShowDialog())
                {
                    picture.mouths_change(UpdateImageColor(image, mouthColor));
                    avatarImage.Image = picture.Avatar;
                    mouthsIndex = tmp.ImageIndex;
                    mouthColor = Color.FromArgb(colorInput.red, colorInput.green, colorInput.blue);
                    faceCode();
                }
            }

        }

        private void eyesList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                if (eyesList.SelectedItems.Count > 0)
                {

                    var tmp = eyesList.SelectedItems[0];
                    Image image = tmp.ImageList.Images[tmp.ImageIndex];
                    RGB_Change colorInput = new RGB_Change();
                    colorInput.red = colorInput.green = colorInput.blue = 0;
                    if (DialogResult.OK == colorInput.ShowDialog())
                    {
                        picture.eyes_change(UpdateImageColor(image, eyeColor));
                        avatarImage.Image = picture.Avatar;
                        eyesIndex = tmp.ImageIndex;
                        eyeColor = Color.FromArgb(colorInput.red, colorInput.green, colorInput.blue);
                        faceCode();
                    }
                }
            }
            catch(ArgumentException ef)
            {
                var tmp = eyesList.SelectedItems[0];
                Image image = tmp.ImageList.Images[tmp.ImageIndex];
                RGB_Change colorInput = new RGB_Change();
                colorInput.red = colorInput.green = colorInput.blue = 0;
                if (DialogResult.OK == colorInput.ShowDialog())
                {
                    picture.eyes_change(UpdateImageColor(image, eyeColor));
                    avatarImage.Image = picture.Avatar;
                    eyesIndex = tmp.ImageIndex;
                    eyeColor = Color.FromArgb(0, 0, 0);
                    faceCode();
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(avatarCode.Text);
            MessageBox.Show("Avatar code coped!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            ImageFormat format = ImageFormat.Png;
            dialog.DefaultExt = "png";
            dialog.Filter = "*.png|*.png|*.bmp|*.bmp|*.jpg|*.jpg";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(dialog.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                    case ".png":
                        format = ImageFormat.Bmp;
                        break;
                }
                picture.Avatar.Save(dialog.FileName, format);
            }
        }

        private Bitmap UpdateImageColor(Image image, Color color)
        {
            Bitmap bitmap = new Bitmap(image);
            if (Face.ChangeColors(bitmap, color.R, color.G, color.B))
                this.Invalidate();
            return bitmap;
        }

        private void AvatarCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] words = avatarCode.Text.Split('/');

                string eyeString = words[0];
                string mouthString = words[1];
                string hairString = words[2];
                string filters = words[3];

                eyesIndex = Int32.Parse(eyeString.Split('-')[0]);
                mouthsIndex = Int32.Parse(mouthString.Split('-')[0]);
                hairsIndex = Int32.Parse(hairString.Split('-')[0]);

                eyeColor = CodeToColor(eyeString.Split('-')[1]);
                mouthColor = CodeToColor(mouthString.Split('-')[1]);
                hairColor = CodeToColor(hairString.Split('-')[1]);
                
                picture = new Face(components1.Base, components1.Eyes.Images[eyesIndex], components1.Mouths.Images[mouthsIndex], components1.Hairs.Images[hairsIndex]);
                picture.eyes_change(UpdateImageColor(components1.Eyes.Images[eyesIndex], eyeColor));
                picture.mouths_change(UpdateImageColor(components1.Mouths.Images[mouthsIndex], mouthColor));
                picture.hair_change(UpdateImageColor(components1.Hairs.Images[hairsIndex], hairColor));

                picture.drawFace();
                avatarImage.Image = picture.Avatar;

                if(int.Parse(filters.Substring(0, 1)) == 1)
                {
                    Negative();
                }
                if(int.Parse(filters.Substring(1, 1)) == 1)
                {
                    Sepia();
                }
                if(int.Parse(filters.Substring(2, 1)) == 1)
                {
                    Frozen();
                }
                if(int.Parse(filters.Substring(3, 1)) == 1)
                {
                    Grayscale();
                }
            }
            catch (FormatException ef)
            {
                picture = new Face(components1.Base, components1.Eyes.Images[0], components1.Mouths.Images[0], components1.Hairs.Images[0]);
                eyesIndex = 0; mouthsIndex = 0; hairsIndex = 0;
                picture.drawFace();
                avatarImage.Image = picture.Avatar;
            }
            catch (ArgumentOutOfRangeException ef)
            {
                picture = new Face(components1.Base, components1.Eyes.Images[0], components1.Mouths.Images[0], components1.Hairs.Images[0]);
                eyesIndex = 0; mouthsIndex = 0; hairsIndex = 0;
                picture.drawFace();
                avatarImage.Image = picture.Avatar;
            }
            catch(IndexOutOfRangeException exc)
            {
                picture = new Face(components1.Base, components1.Eyes.Images[0], components1.Mouths.Images[0], components1.Hairs.Images[0]);
                eyesIndex = 0; mouthsIndex = 0; hairsIndex = 0;
                picture.drawFace();
                avatarImage.Image = picture.Avatar;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            picture = new Face(components1.Base, components1.Eyes.Images[0], components1.Mouths.Images[0], components1.Hairs.Images[0]);
            picture.drawFace();
            avatarImage.Image = picture.Avatar;
            eyesIndex = 0; mouthsIndex = 0; hairsIndex = 0;
            negative = 0;
            sepia = 0;
            frozen = 0;
            grayscale = 0;
            avatarCode.Text = "0-000000/0-000000/0-000000/0000";
        }

        private void faceCode()
        {
            avatarCode.Text = eyesIndex.ToString() + "-" + ColorToCode(eyeColor) + "/" + mouthsIndex.ToString() + "-" + ColorToCode(mouthColor) + "/" + hairsIndex.ToString() +  "-" + ColorToCode(hairColor) + "/" + negative + "" + sepia + "" + frozen + "" + grayscale;

        }

        public void Sepia()
        {
            int a, r, g, b;
            int tr, tg, tb;
            for (int i = 0; i < 150; i++)
            {
                for (int j = 0; j < 150; j++)
                {
                    Color p = picture.Avatar.GetPixel(i, j);
                    a = p.A;
                    r = p.R;
                    g = p.G;
                    b = p.B;

                    tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                    tg = (int)(0.343 * r + 0.686 * g + 0.168 * b);
                    tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                    if (tr > 255)
                        r = 255;
                    else
                        r = tr;
                    if (tg > 255)
                        g = 255;
                    else
                        g = tg;
                    if (tb > 255)
                        b = 255;
                    else
                        b = tb;
                    picture.Avatar.SetPixel(i, j, Color.FromArgb(a, r, g, b));

                }
            }

            avatarImage.Image = picture.Avatar;
        }

        public void Frozen()
        {
            ImageAttributes ia = new ImageAttributes();
            ColorMatrix cmPicture = new ColorMatrix(new float[][]
                    {
                        new float[]{1+0.3f, 0, 0, 0, 0},
                        new float[]{0, 1+0f, 0, 0, 0},
                        new float[]{0, 0, 1+5f, 0, 0},
                        new float[]{0, 0, 0, 1, 0},
                        new float[]{0, 0, 0, 0, 1}
                    });
            ia.SetColorMatrix(cmPicture);
            Graphics g = Graphics.FromImage(picture.Avatar);

            g.DrawImage(picture.Avatar, new Rectangle(0, 0, 150, 150), 0, 0, 150, 150, GraphicsUnit.Pixel, ia);
            g.Dispose();
            avatarImage.Image = picture.Avatar;
        }

        public void Negative()
        {
            int a, r, g, b;
            for (int i = 0; i < 150; i++)
            {
                for (int j = 0; j < 150; j++)
                {
                    Color p = picture.Avatar.GetPixel(i, j);
                    a = p.A;
                    r = p.R;
                    g = p.G;
                    b = p.B;
                    r = 255 - r;
                    b = 255 - b;
                    g = 255 - g;
                    picture.Avatar.SetPixel(i, j, Color.FromArgb(a, r, g, b));
                }
            }
            avatarImage.Image = picture.Avatar;
        }

        public void Grayscale()
        {
            int a, r, g, b;
            int avg;
            for (int i = 0; i < 150; i++)
            {
                for (int j = 0; j < 150; j++)
                {
                    Color p = picture.Avatar.GetPixel(i, j);
                    a = p.A;
                    r = p.R;
                    g = p.G;
                    b = p.B;

                    avg = (r + g + b) / 3;
                    picture.Avatar.SetPixel(i, j, Color.FromArgb(a, avg, avg, avg));

                }
            }

            avatarImage.Image = picture.Avatar;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if(negative == 1)
                negative = 0;
            else
                negative = 1;
            Negative();
            faceCode();
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            sepia = 1;
            Sepia();
            faceCode();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            frozen = 1;
            Frozen();
            faceCode();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            grayscale = 1;
            Grayscale();
            faceCode();
        }

        private string ColorToCode(Color color)
        {
            return color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }
        private Color CodeToColor(string colorCode)
        {
            return Color.FromArgb(
                int.Parse(colorCode.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                int.Parse(colorCode.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                int.Parse(colorCode.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)
                );
        }
    }
}

