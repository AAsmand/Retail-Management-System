using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Project.Tools
{
    public static class DGVSetting
    { 
        public static List<string> ReadDataGridViewSetting(DataGridView dgv, string FileName)
        {
            List<string> deactive = new List<string>();
            XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlnode;
            //declare the filestream for reading and accessing the xml file  
            FileStream fs = new FileStream(Path.Combine(Application.StartupPath, "Setting", FileName + ".xml"), FileMode.Open, FileAccess.Read);
            //pass the filestreanm as object for xmlnode load event  
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
                dgv.Columns[columnName].DisplayIndex = displayindex;
                //set the visibility  
                dgv.Columns[columnName].Visible = visible;
            }
            fs.Close();
            return deactive;
        }
        public static void WriteGrideViewSetting(DataGridView dgv, string FileName)
        {
            XmlTextWriter settingwriter = new XmlTextWriter(Path.Combine(Application.StartupPath, "Setting", FileName + ".xml"), null);
            settingwriter.WriteStartDocument();
            settingwriter.WriteStartElement(dgv.Name);
            int count = dgv.Columns.Count;
            //count the gridview column  
            for (int i = 0; i < count; i++)
            {
                //now create the column root node  
                settingwriter.WriteStartElement("column");
                //then creat the name node and fill the value in this node  
                settingwriter.WriteStartElement("Name");
                settingwriter.WriteString(dgv.Columns[i].Name);
                // close the name node  
                settingwriter.WriteEndElement();
                settingwriter.WriteStartElement("displayindex");
                settingwriter.WriteString(dgv.Columns[i].DisplayIndex.ToString());
                settingwriter.WriteEndElement();
                settingwriter.WriteStartElement("visible");
                settingwriter.WriteString(dgv.Columns[i].Visible.ToString());
                settingwriter.WriteEndElement();
                //end the column node  
                settingwriter.WriteEndElement();
            }
            //end the main root of the xml file which is datagrid name  
            settingwriter.WriteEndElement();
            //end the settingwritter  
            settingwriter.WriteEndDocument();
            //the close the wriiter  
            settingwriter.Close();
        }
    }
}