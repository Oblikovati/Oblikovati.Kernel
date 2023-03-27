using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oblikovati.Domain.Gui
{
    public partial class MainContainerControl : UserControl
    {
        public MainContainerControl()
        {
            InitializeComponent();
            this.Dock = System.Windows.Forms.DockStyle.Fill;
        }
    }
}
