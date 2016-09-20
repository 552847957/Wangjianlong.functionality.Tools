using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wangjianlong.functionality.Tools.Common
{
    public static class FileManager
    {
        public static string SelectFile(string filter,string title,string startFolder=null)
        {
            OpenFileDialog openfileDialog = new OpenFileDialog();
            openfileDialog.InitialDirectory = startFolder;
            openfileDialog.Filter = filter;
            openfileDialog.Title = title;
            if (openfileDialog.ShowDialog() == DialogResult.OK)
            {
                return openfileDialog.FileName;
            }
            return string.Empty;
        }
        public static string SelectFolder(string startPath=null)
        {
            FolderBrowserDialog folderBrowseDialog = new FolderBrowserDialog();
            folderBrowseDialog.SelectedPath = startPath;
            if (folderBrowseDialog.ShowDialog() == DialogResult.OK)
            {
                return folderBrowseDialog.SelectedPath;
            }
            return string.Empty;
        }

        public static string SaveFile(string filter,string title,string startPath=null)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = startPath;
            saveFileDialog.Filter = filter;
            saveFileDialog.Title = title;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }
            return string.Empty;
        }
        public static List<string> GetSpecialFiles(string folder,string filter)
        {
            var dir = new DirectoryInfo(folder);
            var files = dir.GetFiles(filter);
            return files.Select(e => e.FullName).ToList();
        }
    }
}
