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

    
        //public static void ReadMergeCell(ExcelWorksheet ws,string address,ref int width,ref int height)
        //{
        //    if (ws.MergedCells.Count == 0)
        //        return;
        //    foreach (var item in ws.MergedCells)
        //    {
        //        if (item.StartsWith(address))
        //        {
                  
        //        }
        //    }
        //}
        /**
	 * @param args
	 */
        public static void ReadTitle(string tmpFileName)
        {
            ResourceServerConfig config = ResourceServerConfig.LoadConfig(tmpFileName);
            if (config == null)
            {
                config = new ResourceServerConfig();
                System.Windows.Forms.MessageBox.Show("位置配置不存在.");
                return;
            }
            List<String> colNames = config.listDataColEname;
            if (colNames == null)
            {
                System.Windows.Forms.MessageBox.Show("列英文名列表为空");
                return;
            }
            #region 读取列信息
            WinApp.ResourceServerConfig.Columns colTop = new WinApp.ResourceServerConfig.Columns();
          
            // col.id="1";
            // col.text="测试";
            // col.width = 80;
            // col.dataIndex="abc";
            int colX0 = 1;
            int colY0 = 1;
            int colX1 = 3;
            int colY1 = 17;
      

            System.IO.FileInfo file = new System.IO.FileInfo("b.xlsx");
            if (!file.Exists)
            {
                System.Windows.Forms.MessageBox.Show("文件不存在");
                return;
            }
            using (ExcelPackage pck = new ExcelPackage(file))
            {
                //Create the worksheet
                ExcelWorksheet ws = pck.Workbook.Worksheets[1];
                for (int i = colY0; i <= colY1; )
                {
                    String text=  ws.Cells[colX0, i].Text;
                    int mergeX = 0;// [ colX,i].mergerX
                    int mergeY = 0;// [ colX,i].mergerY
                    if (ws.Cells[colX0, i].Merge)
                    {
                        int index =  ws.GetMergeCellId(colX0, i);
                        if (index > 0)
                        {
                            mergeY = ws.Cells[ws.MergedCells[index - 1]].End.Column - ws.Cells[ws.MergedCells[index - 1]].Start.Column;
                            mergeX = ws.Cells[ws.MergedCells[index - 1]].End.Row - ws.Cells[ws.MergedCells[index - 1]].Start.Row;
                        }
                    }
                    //ws.Column(i).Width;
                    WinApp.ResourceServerConfig.Columns col = new WinApp.ResourceServerConfig.Columns();
                    col.id = Guid.NewGuid().ToString();
                    col.text = text;
                    col.width = 80;
                    col.dataIndex = "abc";
                    colTop.childrens.Add(col);
                    // 如果横向merger
                    // if (mergeX > 1) {
                    if (colX1 > 1)
                    {
                        // 如果横向有merger
                        AllColumn(ws, col, colX0 + 1 + mergeX, i, colX1, i + mergeY, colNames);
                    }
                    i +=(1+ mergeY);
                }
                pck.Save();
            }
            #endregion
            config.columnInfo = colTop;
            config.createPerson = "abc";
            config.createTime = DateTime.Now.ToShortDateString();
            config.dataX = 5;
            config.dataY = 1;
            config.listDataColEname = new List<string>();
            config.listDataColEname.Add("ID");
            config.listDataColEname.Add("NAME");
            config.listDataColEname.Add("AGE");

            config.SaveConfig(tmpFileName + ".conf");
            Console.WriteLine("ok");
            
        }

        private static void AllColumn(ExcelWorksheet ws, WinApp.ResourceServerConfig.Columns colTop, int colX0, int colY0,
                int colX1, int colY1,List<String> colNames)
        {
            for (int i = colY0; i <= colY1; )
            {
                String text = ws.Cells[colX0, i].Text;
                int mergeX = 0;// [ colX,i].mergerX
                int mergeY = 0;// [ colX,i].mergerY
                if (ws.Cells[colX0, i].Merge)
                {
                    mergeY = ws.Cells[colX0, i].End.Column - ws.Cells[colX0, i].Start.Column;
                    mergeX = ws.Cells[colX0, i].End.Row - ws.Cells[colX0, i].Start.Row;
                }
                //ws.Column(i).Width;
                WinApp.ResourceServerConfig.Columns col = new WinApp.ResourceServerConfig.Columns();
                col.id = Guid.NewGuid().ToString();
                col.text = text;
                col.width = 80;
                col.dataIndex = "abc";
                colTop.childrens.Add(col);
                // 如果横向merger
                // if (mergeX > 1) {
                if (colX1 >(1+ colX0 + mergeX))
                {
                    // 如果横向有merger
                    AllColumn(ws, col, colX0 + mergeX + 1, i, colX1, i + mergeY, colNames);
                }
                i +=(1+ mergeX);
            }
        }

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
                System.IO.FileInfo file = new System.IO.FileInfo("b.xls");
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
