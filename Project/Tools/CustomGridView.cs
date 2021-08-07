using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Project.Tools
{
    public partial class CustomGridView : DataGridView
    {
        public ContextMenuStrip Gridmenu;
        public ToolStripMenuItem HideColumn;

        public CustomGridView(string name)
        {
            InitializeComponent();
            this.Name = name;
            Gridmenu = new ContextMenuStrip();
            HideColumn = new ToolStripMenuItem("ستون های مخفی");
            Gridmenu.Items.Add(HideColumn);
            HideColumn.DropDownItemClicked += HideColumn_DropDownItemClicked;
            this.ContextMenuStrip = Gridmenu;
            this.KeyDown += GridView_KeyDown;
        }
        public CustomGridView()
        {
            InitializeComponent();
            Gridmenu = new ContextMenuStrip();
            HideColumn = new ToolStripMenuItem("ستون های مخفی");
            Gridmenu.Items.Add(HideColumn);
            HideColumn.DropDownItemClicked += HideColumn_DropDownItemClicked;
            this.ContextMenuStrip = Gridmenu;
            this.KeyDown += GridView_KeyDown;
        }
        public void Init()
        {
            List<string> list = ReadDataGridViewSetting();
            FillHideMenu(list);
        }
        private void GridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.N))
            {
                string column = this.Columns[this.CurrentCell.ColumnIndex].Name;
                this.Columns[column].Visible = false;

                HideColumn.DropDownItems.Add(this.Columns[column].HeaderText);
            }
        }
        private void FillHideMenu(List<string> deactiveList)
        {
            if (deactiveList != null)
            {
                HideColumn.DropDownItems.Clear();
                foreach (string item in deactiveList)
                {
                    HideColumn.DropDownItems.Add(this.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.Name == item).HeaderText);
                }
            }
        }

        private void HideColumn_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var menuText = this.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.HeaderText == e.ClickedItem.Text).Name;
            this.Columns[menuText].Visible = true;
            HideColumn.DropDownItems.Remove(e.ClickedItem);
        }
        public List<string> ReadDataGridViewSetting()
        {
            try
            {
                List<string> deactive = new List<string>();
                XmlDocument xmldoc = new XmlDocument();
                XmlNodeList xmlnode;
                FileStream fs = new FileStream(Path.Combine(Application.StartupPath, "Setting", this.Name + ".xml"), FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);
                xmlnode = xmldoc.GetElementsByTagName("column");
                for (int i = 0; i <= xmlnode.Count - 1; i++)
                {
                    string columnName = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                    int displayindex = int.Parse(xmlnode[i].ChildNodes.Item(1).InnerText.Trim());
                    Boolean visible = Convert.ToBoolean(xmlnode[i].ChildNodes.Item(2).InnerText.Trim());
                    if (!visible && displayindex <= 6)
                        deactive.Add(columnName);
                    //set the column index it means the order of the column  
                    this.Columns[columnName].DisplayIndex = displayindex;
                    //set the visibility  
                    this.Columns[columnName].Visible = visible;
                }
                fs.Close();
                return deactive;
            }
            catch (Exception exp) { return null; }
        }
        public void WriteGrideViewSetting()
        {
            try
            {
                XmlTextWriter settingwriter = new XmlTextWriter(Path.Combine(Application.StartupPath, "Setting", this.Name + ".xml"), null);
                settingwriter.WriteStartDocument();
                settingwriter.WriteStartElement(this.Name);
                int count = this.Columns.Count;
                for (int i = 0; i < count; i++)
                {
                    settingwriter.WriteStartElement("column");
                    settingwriter.WriteStartElement("Name");
                    settingwriter.WriteString(this.Columns[i].Name);
                    settingwriter.WriteEndElement();
                    settingwriter.WriteStartElement("displayindex");
                    settingwriter.WriteString(this.Columns[i].DisplayIndex.ToString());
                    settingwriter.WriteEndElement();
                    settingwriter.WriteStartElement("visible");
                    settingwriter.WriteString(this.Columns[i].Visible.ToString());
                    settingwriter.WriteEndElement();
                    settingwriter.WriteEndElement();
                }
                settingwriter.WriteEndElement();
                settingwriter.WriteEndDocument();
                settingwriter.Close();
            }
            catch (Exception) { }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
