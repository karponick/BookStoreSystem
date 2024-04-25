using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreSystem.Controller
{
    public class FileController
    {
        public static bool ExportToCSV<T>(List<T> items, string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                Type type = typeof(T);
                var lines = new List<string>();
                PropertyInfo[] properties = typeof(T).GetProperties();
                //creating a header
                string header = "";
                for (int i = 0; i < properties.Length - 1; i++)
                {
                    header += properties[i].Name + ",";
                }
                lines.Add(header.TrimEnd(','));
                //creating items by using linq and reflection
                var valueLines = items.Select(row => string.Join(",", header.Split(',').Where(p => !string.IsNullOrWhiteSpace(p)).
                    Select(prop => type.GetProperty(prop).GetValue(row, null))));
                lines.AddRange(valueLines);
                File.WriteAllLines(path, lines.ToArray());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
    }
}
