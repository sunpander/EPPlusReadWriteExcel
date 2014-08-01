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
            //ResourceServerConfig config = new ResourceServerConfig();
            //config.createPerson = "abc";
            //config.createTime = DateTime.Now.ToShortDateString();
            //config.dataX = 5;
            //config.dataY = 1;
            //config.listDataColEname = new List<string>();
            //config.listDataColEname.Add("ID");
            //config.listDataColEname.Add("NAME");
            //config.listDataColEname.Add("AGE");

            //config.SaveConfig(txtFileName.Text+".conf");
            string configName = this.txtFileName.Text + ".conf";

            ResourceServerConfig config = this.propertyGrid1.SelectedObject as ResourceServerConfig;
            if (config != null)
            {
                config.listDataColEname = new List<string>();
                config.listDataColEname.Add("ID");
                config.listDataColEname.Add("NAME");
                config.listDataColEname.Add("AGE");
            }
            config.SaveConfig(configName);
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

        private void FormLoadConfig_Load(object sender, EventArgs e)
        {
            try
            {
                ResourceServerConfig config = new ResourceServerConfig();
                this.propertyGrid1.SelectedObject = config;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSelTemp_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtFileName.Text = openFileDialog1.FileName;

                string configName = this.txtFileName.Text+".conf";
                ResourceServerConfig config = ResourceServerConfig.LoadConfig(configName);
                if (config == null)
                {
                    config = new ResourceServerConfig();
                    config.SaveConfig(configName);
                }
                this.propertyGrid1.SelectedObject = config;
            }
        }
    }
}
