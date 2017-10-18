using System;
using System.IO;
using System.Windows.Forms;

namespace Fw
{
    public partial class frm1 : Form
    {
        private FileSystemWatcher watcher;
        private delegate void UpdateWatchTextDelegate(string newText);


        public frm1()
        {
            InitializeComponent();
            this.watcher = new FileSystemWatcher();
            this.watcher.Deleted += new FileSystemEventHandler(watcher_Deleted);
            this.watcher.Renamed += new RenamedEventHandler(watcher_Renamed);
            this.watcher.Changed += new FileSystemEventHandler(watcher_Changed);
            this.watcher.Created += new FileSystemEventHandler(watcher_Created);

        }

        public void UpdateWatchText(string newText)
        {
            lblWatch.Text = newText;
        }


        public void WriteLog(string LogContent) 
        {
            using (StreamWriter sw = new StreamWriter("c:\\Log.txt", true))
            {
                sw.WriteLine(LogContent);
                sw.Close();
            } 
            
        }

        void watcher_Created(object sender, FileSystemEventArgs e)
        {           
            try
            {
                WriteLog(String.Format("File: {0} Created", e.FullPath));
                this.BeginInvoke(new UpdateWatchTextDelegate(UpdateWatchText), "文件" + e.FullPath + "被创建");
            }
            catch (IOException)
            {
                this.BeginInvoke(new UpdateWatchTextDelegate(UpdateWatchText), "创建日志写入失败!");
            }
        }


        void watcher_Changed(object sender, FileSystemEventArgs e)
        {            
            try
            {              
                WriteLog(String.Format("File: {0} {1}", e.FullPath, e.ChangeType.ToString()));
                this.BeginInvoke(new UpdateWatchTextDelegate(UpdateWatchText), "文件" + e.FullPath + "被修改");
            }
            catch (IOException)
            {
                this.BeginInvoke(new UpdateWatchTextDelegate(UpdateWatchText), "修改日志写入失败!");
            }
        }

        void watcher_Renamed(object sender, RenamedEventArgs e)
        {            
            try
            {               
                WriteLog(String.Format("File renamed from {0} to {1}", e.OldName, e.FullPath));
                this.BeginInvoke(new UpdateWatchTextDelegate(UpdateWatchText), "文件" + e.OldName + "被重命名为" + e.FullPath);
            }
            catch (IOException)
            {
                this.BeginInvoke(new UpdateWatchTextDelegate(UpdateWatchText), "重命名日志写入失败!");
            }
        }

        void watcher_Deleted(object sender, FileSystemEventArgs e)
        {            
            try
            {                
                WriteLog(String.Format("File: {0} Deleted", e.FullPath));
                this.BeginInvoke(new UpdateWatchTextDelegate(UpdateWatchText), "文件" + e.FullPath + "被删除");
            }
            catch (IOException)
            {
                this.BeginInvoke(new UpdateWatchTextDelegate(UpdateWatchText), "删除日志写入失败!");
            }
        }


        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() != DialogResult.Cancel)
            {
                txtLocation.Text = this.folderBrowserDialog1.SelectedPath;
                cmdWatch.Enabled = true;
            }
        }

        private void cmdWatch_Click(object sender, EventArgs e)
        {
            if (txtLocation.Text.Length <= 0) 
            {
                MessageBox.Show("请先选择要监视的文件夹!");
                cmdBrowse.Focus();
                return;
            }
            watcher.Path = txtLocation.Text;//监控路径（文件夹）
            watcher.IncludeSubdirectories = true; //是否包含子目录

            watcher.Filter = "*.*";//如果filter为文件名称则表示监控该文件，如果为*.txt则表示要监控指定目录当中的所有.txt文件
            watcher.NotifyFilter = NotifyFilters.LastWrite |
                NotifyFilters.FileName |
                NotifyFilters.Size;
            lblWatch.Text = watcher.Path + " 监视中...";

            //begin watching.
            watcher.EnableRaisingEvents = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            watcher.EnableRaisingEvents = false;
            lblWatch.Text = watcher.Path + " 监视已经停止!";
        }




    }
}
