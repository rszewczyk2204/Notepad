using System;
using System.Windows.Forms;

namespace Notepad.View.Notepad.Interface
{
    public interface INotepadMethods
    {
        void TextBoxTextChanged(object sender, EventArgs e);
        void TextBoxClicked(object sender, EventArgs e);
    }
}
