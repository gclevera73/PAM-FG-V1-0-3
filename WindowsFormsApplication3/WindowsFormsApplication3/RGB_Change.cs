using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class RGB_Change : Form
    {

        public RGB_Change()
        {
            InitializeComponent();
            OK.DialogResult = DialogResult.OK;
        }

        public int red
        {
            get
            {
                try
                {
                    return (Convert.ToInt32(Red.Text, 10));
                }
                catch(FormatException ef)
                {
                    return (Convert.ToInt32("0", 10));
                }
                catch (OverflowException ef)
                {
                    return (Convert.ToInt32("0", 10));
                }
            }
            set { Red.Text = value.ToString(); }
        }

        public int green
        {
            get
            {
                try
                {
                    return (Convert.ToInt32(Green.Text, 10));
                }
                catch (FormatException ef)
                {
                    return (Convert.ToInt32("0", 10));
                }
                catch (OverflowException ef)
                {
                    return (Convert.ToInt32("0", 10));
                }
            }
            set { Green.Text = value.ToString(); }
        }

        public int blue
        {
            get
            {
                try
                {
                    return (Convert.ToInt32(Blue.Text, 10));
                }
                catch (FormatException ef)
                {
                    return (Convert.ToInt32("0", 10));
                }
                catch (OverflowException ef)
                {
                    return (Convert.ToInt32("0", 10));
                }
            }
            set { Blue.Text = value.ToString(); }
        }

        private void ColorInput_Load(object sender, System.EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }

}
