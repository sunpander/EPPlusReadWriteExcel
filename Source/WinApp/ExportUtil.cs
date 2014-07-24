using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace WinApp
{
    public class ExportUtil
    {
        public static void ExportData(DataTable dtContent, string tmpFileName)
        {
            bool isConfigTemp = false;
            string templateFolder = "template";
            //1.查看是否有模板文件(tmpFileName.xlsx)
            FileInfo xlsFile = new FileInfo(templateFolder + "\\" + tmpFileName + ".xlsx");
            isConfigTemp = xlsFile.Exists;
            //2.查看是否有对应的 配置文件(tmpFileName.conf)
            ResourceServerConfig config = ResourceServerConfig.LoadConfig(tmpFileName + ".conf");
            isConfigTemp = isConfigTemp && (config != null);

           
            if (!isConfigTemp)
            {
                //如果没有,相应配置,直接加载表信息
                System.IO.FileInfo file = new System.IO.FileInfo("demo.xls");
                using (ExcelPackage pck = new ExcelPackage(file))
                {
                    //Create the worksheet
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Demo");
               

                    //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
                    ws.Cells["A1"].LoadFromDataTable(dtContent, true);
                    for (int i = 0; i < dtContent.Columns.Count; i++)
                    {
                        if (string.IsNullOrEmpty(dtContent.Columns[i].Caption))
                        {
                            ws.Cells[1, i + 1].Value = dtContent.Columns[i].ColumnName;
                        }
                        else
                        {
                            ws.Cells[1, i + 1].Value = dtContent.Columns[i].Caption;
                        }
                    }
                    //Format the header for column 1-3
                    using (ExcelRange rng = ws.Cells["A1:C1"])
                    {
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    }
                    pck.Save();
                }
            }
            else
            {
                //如果有相应配置,读取配置
            }


        }
    }
}
