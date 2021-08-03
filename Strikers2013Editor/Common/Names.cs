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

        public static string[] ChargeProfilesNames = 
        {
            "",
            "Boy GK Medium",
            "Boy GK Fast",
            "Boy GK Slow",
            "Boy DF Medium",
            "Boy DF Fast",
            "Boy DF Slow",
            "Boy MF Medium",
            "Boy MF Fast",
            "Boy MF Slow",
            "Boy FW Medium",
            "Boy FW Fast",
            "Boy FW Slow",
            "Girl GK Medium (UNUSED)",
            "Girl GK Fast",
            "Girl GK Slow (UNUSED)",
            "Girl DF Medium",
            "Girl DF Fast",
            "Girl DF Slow (UNUSED)",
            "Girl MF Medium",
            "Girl MF Fast",
            "Girl MF Slow (UNUSED)",
            "Girl FW Medium",
            "Girl FW Fast",
            "Girl FW Slow (UNUSED)",
            "Keshin User GK Medium (UNUSED)",
            "Keshin User GK Fast (UNUSED)",
            "Keshin User GK Slow",
            "Keshin User DF Medium",
            "Keshin User DF Fast (UNUSED)",
            "Keshin User DF Slow",
            "Keshin User MF Medium",
            "Keshin User MF Fast (UNUSED)",
            "Keshin User MF Slow",
            "Keshin User FW Medium",
            "Keshin User FW Fast (UNUSED)",
            "Keshin User FW Slow",
            "Mixi-Max (UNUSED)"
        };
    }
}
