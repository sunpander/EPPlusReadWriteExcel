using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinApp
{
    public partial class FormLoadConfig : Form
    {
        public FormLoadConfig()
        {
            InitializeComponent();
        }

        private void btnWriteConfig_Click(object sender, EventArgs e)
        {
            ResourceServerConfig config = new ResourceServerConfig();
            config.createPerson = "abc";
            config.createTime = DateTime.Now.ToShortDateString();
            config.dataX = 5;
            config.dataY = 1;
            config.listDataColEname = new List<string>();
            config.listDataColEname.Add("ID");
            config.listDataColEname.Add("NAME");
            config.listDataColEname.Add("AGE");

            config.SaveConfig(txtFileName.Text+".conf");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
          
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("name");
            dt.Columns.Add("age");
            dt.Columns.Add("class");
            for (int i = 0; i < 10; i++)
            {
                dt.Rows.Add(i, "name:" + i, i, "class:" + i);
            }


            ExportUtil.ExportData(dt, txtFileName.Text);
            
        }
    }
}
