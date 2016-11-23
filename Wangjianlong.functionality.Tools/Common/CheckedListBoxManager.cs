using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wangjianlong.functionality.Tools.Common
{
    public static class CheckedListBoxManager
    {
        public static  string GetWhereClause(CheckedListBox checkedListBox, string fieldName, bool quotes)
        {
            var list = GetChecked(checkedListBox);
            string whereClause = string.Empty;
            foreach (var item in list)
            {
                var str = quotes ? string.Format("\"{0}\" = '{1}'", fieldName, item) : string.Format("\"{0}\" = {1}", fieldName, item);
                if (string.IsNullOrEmpty(whereClause))
                {
                    whereClause += str;
                }
                else
                {
                    whereClause += string.Format(" OR {0}", str);
                }
            }
            return whereClause;
        }
        public static  List<string> GetChecked(CheckedListBox checkedlistbox)
        {
            var list = new List<string>();
            for (var i = 0; i < checkedlistbox.Items.Count; i++)
            {
                if (checkedlistbox.GetItemChecked(i))
                {
                    list.Add(checkedlistbox.GetItemText(checkedlistbox.Items[i]));
                }
            }
            return list;
        }
    }
}
