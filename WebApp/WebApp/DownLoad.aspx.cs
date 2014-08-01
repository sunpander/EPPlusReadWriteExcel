using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Data;

namespace WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Price");
                for (int i = 0; i < 10; i++)
                {
                    dt.Rows.Add(i, "name:" + i, i * 3);
                }
                this.Store1.DataSource = dt;
                this.Store1.DataBind();
            }
        }
 
       public  void Button1_DirectClick(object sender, DirectEventArgs e)
       {
           RowSelectionModel sm = this.GridPanel1.GetSelectionModel() as RowSelectionModel;
           SelectedRow row =   sm.SelectedRow;
           String str =  row.RecordID+"__"+row.RowIndex ;
      
          // Store1.GetAt(row.RowIndex)
             
        }
       public void Export_DirectClick(object sender, DirectEventArgs e)
       {
           try
           {

               string fileName = @"C:\Users\Administrator\Desktop\报表填报设计.xlsx";
               System.IO.FileInfo info = new System.IO.FileInfo(fileName);
               if (info.Exists)
               {
                   this.Response.Clear();
                   this.Response.ContentType = "application/vnd.ms-excel";
                   this.Response.AddHeader("Content-Disposition", "attachment; filename=" + info.Name);

                   Response.TransmitFile(fileName);
                   this.Response.End();
               }
           }
           catch (Exception ex)
           {
                
           }

       }
       public void Export_DirectClick3(object sender, DirectEventArgs e)
       {
           try
           {
               RowSelectionModel sm = this.GridPanel1.GetSelectionModel() as RowSelectionModel;
               if (sm == null || sm.SelectedIndex < 0)
               {
                   new Ext.Net.MessageBox().Alert("选择换呢过", "选择横");
                   return;
               }
               new Ext.Net.MessageBox().Alert("选择换呢过", sm.SelectedIndex);
               string fileName = @"C:\Users\Administrator\Desktop\报表填报设计.xlsx";
               System.IO.FileInfo info = new System.IO.FileInfo(fileName);
               if (info.Exists)
               {
                   this.Response.Clear();
                   this.Response.ContentType = "application/vnd.ms-excel";
                   this.Response.AddHeader("Content-Disposition", "attachment; filename=" + info.Name);

                   Response.TransmitFile(fileName);
                   this.Response.End();
               }
           }
           catch (Exception ex)
           {

           }

       }

       public void Export_DirectClick2(object sender, DirectEventArgs e)
       {
           try
           {
               RowSelectionModel sm = this.GridPanel1.GetSelectionModel() as RowSelectionModel;
               if (sm == null || sm.SelectedIndex < 0)
               {
                   new Ext.Net.MessageBox().Alert("选择换呢过","选择横");
                   return;
               }
               new Ext.Net.MessageBox().Alert("选择换呢过", sm.SelectedIndex);
               //SelectedRow row = sm.SelectedRow;

               string fileName = @"C:\Users\Administrator\Desktop\报表填报设计.xlsx";
               System.IO.FileInfo info = new System.IO.FileInfo(fileName);
               if (info.Exists)
               {
                   HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=Excel.xls");
                   HttpContext.Current.Response.Charset = "gb2312";
                   HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                   HttpContext.Current.Response.ContentType = "application/ms-excel";
                   
                   System.IO.StringWriter tw = new System.IO.StringWriter();
                   System.IO.FileStream file = new System.IO.FileStream(fileName, System.IO.FileMode.Open);


                   HttpContext.Current.Response.Write(file.ToString());
                   HttpContext.Current.Response.End(); 
               }
           }
           catch (Exception ex)
           {

           }

       }

      public  void Button2_Click(object sender, EventArgs e)
       {
           try
           {

               string fileName = @"C:\Users\Administrator\Desktop\报表填报设计.xlsx";
               System.IO.FileInfo info = new System.IO.FileInfo(fileName);
               if (info.Exists)
               {
                   this.Response.Clear();
                   this.Response.ContentType = "application/vnd.ms-excel";
                   this.Response.AddHeader("Content-Disposition", "attachment; filename=" + info.Name);
                   Response.TransmitFile(fileName);
                   this.Response.End();
               }
           }
           catch (Exception ex)
           {

           }
           //RowSelectionModel sm = this.GridPanel1.GetSelectionModel() as RowSelectionModel;

           //SelectedRow row = sm.SelectedRow;
       }
    }
}