using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabioGusmao.Infra.FileUtils
{
    public static class CsvConverter
    {
        public static string SaveToCsv<T>(List<T> reportData)
        {
            StringBuilder lines = new StringBuilder();
            IEnumerable<PropertyDescriptor> props = TypeDescriptor.GetProperties(typeof(T)).OfType<PropertyDescriptor>();
            var header = string.Join(",", props.ToList().Select(x => x.Name));
            lines.AppendLine(header);
            //var valueLines = reportData.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
            reportData.ForEach(row=> lines.AppendLine(string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null)))));
            //lines.AddRange(valueLines);
            return lines.ToString();
        }
    }
}
