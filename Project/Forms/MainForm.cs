using Framework;
using Framework.IOC;
using Project.Forms.User;
using Project.Models.User;
using Project.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utility.Interfaces;
using Utility.Properties;

namespace Project
{
    public partial class MainForm : Form
    {
        Utility.Tools.MainMenu menu;
        public MainForm(Utility.Tools.MainMenu menu)
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.LayoutMdi(MdiLayout.TileHorizontal);
            this.menu = menu;
            this.Controls.Add(menu);
        }
    }
}
