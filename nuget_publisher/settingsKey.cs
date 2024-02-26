using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nuget_publisher
{
    public partial class settingsKey : Form
    {
        public settingsKey()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.va = "ret";
            this.Close();
        }
    }
}
