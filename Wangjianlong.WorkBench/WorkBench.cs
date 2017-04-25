using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Wangjianlong.WorkBench.UIs;

namespace Wangjianlong.WorkBench
{
    public static class WorkBench
    {
        private static object objToLock { get; set; }
        private static string _configFileName { get; set; }
        /// <summary>
        /// 配置文件
        /// </summary>
        public static string ConfigFileName
        {
            get
            {
                if (string.IsNullOrEmpty(_configFileName))
                {
                    return System.IO.Path.Combine(Application.StartupPath, System.Configuration.ConfigurationManager.AppSettings["CONFIG"]);
                }
                else
                {
                    return _configFileName;
                }
            }
            set { _configFileName = value; }
        }

        static WorkBench()
        {
            objToLock = new object();
        }

        private static MainForm _mainForm { get; set; }
        /// <summary>
        /// 功能主窗体
        /// </summary>
        public static MainForm MainForm
        {
            get
            {
                if (_mainForm == null || _mainForm.Created == false || _mainForm.IsDisposed == true)
                {

                    lock (objToLock)
                    {
                        if (_mainForm == null || _mainForm.Created == false || _mainForm.IsDisposed == true)
                        {
                            System.Windows.Forms.Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                            System.AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                            SysIniter sysIniter = new SysIniter() { XMLConfigFilePath = ConfigFileName };
                            sysIniter.Initer();
                        }
                    }
                }
                return _mainForm;
            }
            set { _mainForm = value; }
        }

        #region DEV控件
        private static RibbonControl _ribbonControl { get; set; }
        public static RibbonControl RibbonControl { get { return _ribbonControl; }set { _ribbonControl = value; } }
        private static RibbonStatusBar _statusBar { get; set; }
        public static RibbonStatusBar StatusBar { get { return _statusBar; }set { _statusBar = value; } }
        #endregion


        #region 异常处理事件
        /// <summary>
        /// 作用：未捕获线程异常处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {

                string msg = "系统发生未处理的异常！";
                msg += "\r\n异常信息：" + e.Exception.Message;
                msg += "\r\n引发异常的对象：" + e.Exception.Source;
                msg += "\r\n引发异常的方法：" + e.Exception.TargetSite;
                msg += "\r\n错误堆栈：" + e.Exception.StackTrace.ToString();
                throw new Exception(msg);
            }
            catch
            {

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                string msg = "系统发生未处理的异常！";
                msg += e.ToString();
                msg += e.ExceptionObject.ToString();
                throw new Exception(msg);
            }
            catch
            {

            }
        }
        #endregion
    }
}
