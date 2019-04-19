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
        public BTree tree;

        public Form()
        {
            InitializeComponent();

            this.tree = new BTree();
        }

        private void buttonAddKey_Click(object sender, EventArgs e)
        {
            string key = this.textBox.Text;
            
            tree.Insert(key, key);

            //...
        }

        private void buttonRemoveKey_Click(object sender, EventArgs e)
        {

        }
    }
}
