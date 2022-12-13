using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Notepad
{
    sealed class Functions
    {
        private Functions() { }

        public static String GetNameFromAbsolutePath(String path)
        {
            return path.Substring(path.LastIndexOf('\\')).Substring(1);
        }

        public static KeyValuePair<int, int> GetCaretPosition(TextBox textBox)
        {
            return new KeyValuePair<int, int>(0, 0);
        }
    }
}
