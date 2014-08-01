using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace WinApp
{
    /**
   xml文件中存放.
1.excel数据块的datasource数据源 
2.excel数据块的开始坐标 x,y 
3.excel数据块列英文名称(从左到右的一个list)
4.excel数据块列标题区域(比如 a1,c4)----用来读取列标题,构建grid列
------初次打开画面,读取excel列标题区域,同时生成一个临时文件,存放读取的列信息,下次直接读取,
     **/
    #region
    /// <summary>
    /// 资源管理配置类
    /// </summary>
    public class ResourceServerConfig : INotifyPropertyChanged
    {


        private String _fileName;
        private String _sheetName;

        public String sheetName
        {
            get { return _sheetName; }
            set { _sheetName = value; }
        }
        private String _createPerson;
        [Category("报表基本信息")]
        [Description("创建人")]
        public String createPerson
        {
            get { return _createPerson; }
            set { _createPerson = value; }
        }
        private String _createTime;
        [Category("报表基本信息")]
        [Description("创建时间")]
        public String createTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }
        private String _reportYearMonth;
        [Category("报表基本信息")]
        [Description("报表年月")]
        public String reportYearMonth
        {
            get { return _reportYearMonth; }
            set { _reportYearMonth = value; }
        }
        private String _reportCreatePerson;
        [Category("报表基本信息")]
        [Description("报表编制人")]
        public String reportCreatePerson
        {
            get { return _reportCreatePerson; }
            set { _reportCreatePerson = value; }
        }
        private String _title;

        private List<string> _listDataColEname;

        [Category("报表基本信息")]
        [Description("报表列名称")]
        //[TypeConverter(typeof(typeof(String))]
        public List<string> listDataColEname
        {
            get { return _listDataColEname; }
            set { _listDataColEname = value; }
        }

        private List<int> _listIntlEname;
        [Category("报表基本信息")]
        [Description("数据开始行")]
        public List<int> listDat
        {
            get { return _listIntlEname; }
 
            set { _listIntlEname = value; }
        }


        private int _dataX;

        [Category("报表基本信息")]
        [Description("数据开始行")]
        public int dataX
        {
            get { return _dataX; }
            set { _dataX = value; }
        }
        private int _dataY;
        [Category("报表基本信息")]
        [Description("数据开始列")]
        public int dataY
        {
            get { return _dataY; }
            set { _dataY = value; }
        }

        private int _titleX;

        public int titleX
        {
            get { return _titleX; }
            set { _titleX = value; }
        }
        private int _titleY;

        public int titleY
        {
            get { return _titleY; }
            set { _titleY = value; }
        }

        private int _dataRowCount;

        public int dataRowCount
        {
            get { return _dataRowCount; }
            set { _dataRowCount = value; }
        }
        private int _dataColCount;

        public int dataColCount
        {
            get { return _dataColCount; }
            set { _dataColCount = value; }
        }
        /**
         * 列标题区域
         * */
        private String _columnRange;

        public String columnRange
        {
            get { return _columnRange; }
            set { _columnRange = value; }
        }
        private Columns _columnInfo;

        public Columns columnInfo
        {
            get { return _columnInfo; }
            set { _columnInfo = value; }
        }


        [Category("报表基本信息")]
        [Description("报表名称")]
        public String fileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                if (_fileName == value) return;
                _fileName = value;
                OnPropertyChanged("fileName");
            }
        }
        [Category("报表基本信息")]
        [Description("标题")]
        public String title
        {
            get { return _title; }
            set { _title = value; }
        }
        
        /**
         * 列标题区域
         * */



        public class Columns
        {
            public String id = "";
            public String text = "";
            public int width = 80;
            public String dataIndex = "";
            public List<Columns> childrens = new List<Columns>();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentNullException("propertyName");
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
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
