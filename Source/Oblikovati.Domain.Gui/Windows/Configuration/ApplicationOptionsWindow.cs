using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.Windows.Configuration
{
    public partial class ApplicationOptionsWindow : Form
    {
        public ApplicationOptionsWindow(IApplicationBase application)
        {
            _application = application;
            InitializeComponent();
        }
        private readonly IApplicationBase _application;

        private void ApplicationOptionsWindow_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
