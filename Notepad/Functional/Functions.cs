using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Notepad.Functional
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

        public static bool IsNull(object value)
        {
            return value == null;
        }

        public static bool NonNull(object value)
        {
            return value != null;
        }
    }

    public enum NotepadConstants
    {
        CW_DEFAULTHEIGHT = 477,
        CW_DEFAULTWIDTH = 915,
        CW_DEFAULT_MENU_BAR_HEIGHT = 24
    }
}
