using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinApp
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
        public static ResourceServerConfig LoadConfig(String fileName)
        {
            try
            {
                string strConfigPath = "template\\";// Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\iPlat4C_Config\\";
                System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(strConfigPath);
                string tmp2 = strConfigPath + fileName ;
                if (!info.Exists)
                {
                    info.Create();
                }
                object obj = XMLConfigUtility.LoadConfigByType(typeof(ResourceServerConfig), fileName, strConfigPath);
                ResourceServerConfig config = null;
                if (obj is ResourceServerConfig)
                {
                    config = obj as ResourceServerConfig;
                }
                if (config != null)
                    return config;
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 保存配置
        /// </summary>
        /// <returns></returns>
        public bool SaveConfig(String fileName)
        {
            try
            {
                string strConfigPath = "template\\";     // Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\iPlat4C_Config\\";
                System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(strConfigPath);
                if (!info.Exists)
                {
                    info.Create();
                }
                return XMLConfigUtility.SaveNewConfig(this, fileName, strConfigPath);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
    #endregion
}
