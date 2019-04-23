using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTree
{
    public partial class Form : System.Windows.Forms.Form
    {
        private BTreeDebug tree;
        private Bitmap bitmap;

        public Form()
        {
            InitializeComponent();

            tree = new BTreeDebug();

            bitmap = new Bitmap(1024, 1024, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        }

        private void buttonAddKey_Click(object sender, EventArgs e)
        {
            string key = this.textBox.Text;
            
            tree.Insert(key, key);

            tree.Render(bitmap);

            pictureBox.Image = bitmap;
        }

        private void buttonRemoveKey_Click(object sender, EventArgs e)
        {

        }
    }
}
