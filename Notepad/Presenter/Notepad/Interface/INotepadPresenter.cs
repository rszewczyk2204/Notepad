using System;
using System.Windows.Forms;

namespace Notepad.Presenter.Notepad.Interface
{
    public interface INotepadPresenter
    {
        void TextBoxTextChanged(object sender, EventArgs e);

        void TextSelected(object sender, EventArgs e);

        void TextBoxClicked(object sender, EventArgs e);
    }
}
