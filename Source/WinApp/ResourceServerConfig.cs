using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PlugInCore.Common.XML
{
    #region 记录最近登录用户,密码
    /// <summary>
    /// 资源管理配置类
    /// </summary>
    public class ResourceServerConfig
    {


        public String fileName;
        public String sheetName;
        public String createPerson;
        public String createTime;
        public String reportYearMonth;
        public String reportCreatePerson;
        public String title;
        public List<String> listDataColEname;
        public int dataX;
        public int dataY;

        public int titleX;
        public int titleY;

        public int dataRowCount;
        public int dataColCount;

        /// <summary>
        /// 加载配置
        /// </summary>
        /// <param name="localPath"></param>
        /// <returns></returns>
        public static ResourceServerConfig LoadConfig()
        {
            try
            {
                string strConfigPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\iPlat4C_Config\\";
                System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(strConfigPath);

                string tmp = Environment.GetEnvironmentVariable("TEMP") + "\\iPlat4C_Config\\login.conf";
                System.IO.FileInfo info2 = new System.IO.FileInfo(tmp);
                string tmp2 = strConfigPath+"login.conf";
              
                if (!info.Exists)
                {
                    info.Create();
                 
                }
                if (info2.Exists)
                {
                    System.IO.FileInfo info3 = new System.IO.FileInfo(tmp2);
                    if (!info3.Exists)
                    {
                        info2.MoveTo(tmp2);
                    }
                }
                object obj = XMLConfigUtility.LoadConfigByType(typeof(ResourceServerConfig),"login.conf", strConfigPath);
                ResourceServerConfig config = null;
                if (obj is ResourceServerConfig)
                {
                    config = obj as ResourceServerConfig;
                }
                if (config != null)
                    return config;
                else
                    return new ResourceServerConfig();
            }
            catch
            {
                return new ResourceServerConfig();
            }
        }
        /// <summary>
        /// 保存配置
        /// </summary>
        /// <returns></returns>
        public bool SaveConfig()
        {
            try
            {
                string strConfigPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\iPlat4C_Config\\";
                System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(strConfigPath);
                if (!info.Exists)
                {
                    info.Create();
                }
                return XMLConfigUtility.SaveNewConfig(this, "login.conf", strConfigPath);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
    #endregion
}
