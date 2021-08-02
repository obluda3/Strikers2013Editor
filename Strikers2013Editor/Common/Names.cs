using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Strikers2013Editor.Common
{
    public static class Names
    {
        public static string[] GetTextFile(string path)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var file = assembly.GetManifestResourceStream(path))
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    var linesList = new List<string>();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        linesList.Add(line);
                    }

                    return linesList.ToArray();
                }
            }
        }
    }
}
