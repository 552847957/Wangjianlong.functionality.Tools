using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wangjianlong.WorkBench.UIs
{
    internal class SysIniter
    {

        private string _XMLConfigFilePath { get; set; }
        /// <summary>
        /// 配置文件
        /// </summary>
        public string XMLConfigFilePath { get { return _XMLConfigFilePath; }set { _XMLConfigFilePath = value; } }

        public void Initer()
        {
            MainForm form = null;
            try
            {
                System.Windows.Forms.Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(WorkBench.Application_ThreadException);
                System.AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(WorkBench.CurrentDomain_UnhandledException);

                UIIniter initer = new UIIniter { XMLConfigFilePath = _XMLConfigFilePath };
                form = initer.CreateUI();
                form.Show();
                WorkBench.MainForm = form;

            }catch(Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex);
            }
           
        }
    }
}
