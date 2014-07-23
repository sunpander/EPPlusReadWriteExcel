using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using EPPlusSamples;
using PlugInCore.Common.XML;
using OfficeOpenXml;
namespace WinApp
{
    public partial class FormEPPlusSamples : Form
    {
        public FormEPPlusSamples()
        {
            InitializeComponent();

            // change this line to contain the path to the output folder
             outputDir = new DirectoryInfo(@"c:\temp\SampleApp");

            if (!outputDir.Exists)
            {
                outputDir.Create();
            }
        }
        DirectoryInfo outputDir;
        private void btnSample1_Click(object sender, EventArgs e)
        {
            // Sample 1 - simply creates a new workbook from scratch
            // containing a worksheet that adds a few numbers together 
            Console.WriteLine("Running sample 1");
            string output = Sample1.RunSample1(outputDir);
            Console.WriteLine("Sample 1 created: {0}", output);
            Console.WriteLine();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Sample 1 - simply creates a new workbook from scratch
            // containing a worksheet that adds a few numbers together 
            Console.WriteLine("Running sample 1");
            string output = Sample5.RunSample5(outputDir);
            Console.WriteLine("Sample 1 created: {0}", output);
            Console.WriteLine();
        }

        private void button2_Click(object sender, EventArgs e)
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

            config.SaveConfig();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResourceServerConfig config = ResourceServerConfig.LoadConfig();
            String dd = config.sheetName;
        }


        public static string RunSample5(DirectoryInfo outputDir, DataTable dtContent, ResourceServerConfig config)
        {
            FileInfo templateFile = new FileInfo(outputDir.FullName + @"\化学分析.xlsx");
            FileInfo newFile = new FileInfo(outputDir.FullName + @"\化学分析2.xlsx");
            if (newFile.Exists)
            {
                newFile.Delete();  // ensures we create a new workbook
                newFile = new FileInfo(outputDir.FullName + @"\化学分析2.xlsx");
            }
            using (ExcelPackage package = new ExcelPackage(newFile, templateFile))
            {
                //Open worksheet 1
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                //worksheet.InsertRow(5, 2);
                int x = config.dataX;
                int y = config.dataY;
                List<String> listColIndex = config.listDataColEname;
                int totalX = 0;
                int totalY = 0;
                for (int i = 0; i < dtContent.Rows.Count; i++)
                {
                    for (int k = 0; k < listColIndex.Count; k++)
                    {
                        object obj = dtContent.Rows[i][listColIndex[k]];
                        if ("rec_date" == listColIndex[k])
                        {
                            worksheet.Cells[x + i, y + k].Value = DateTime.Parse(obj.ToString()).ToString( );
                        }
                        else
                        {
                            worksheet.Cells[x + i, y + k].Value = obj;
                        }
                        totalY = y + k;
                    }
                    totalX = x + i;
                }
                
                // save our new workbook and we are done!
                package.Save();
            }

            return newFile.FullName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResourceServerConfig config = ResourceServerConfig.LoadConfig();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("name");
            dt.Columns.Add("age");
            dt.Columns.Add("class");
            for (int i = 0; i < 10; i++)
            {
                dt.Rows.Add(i, "name:" + i, i, "class:" + i);
            }
            RunSample5(outputDir, dt,config);


        }
    }
}
