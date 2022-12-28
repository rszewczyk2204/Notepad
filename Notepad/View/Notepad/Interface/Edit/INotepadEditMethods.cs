using System;

namespace Notepad.View.Notepad.Interface.Edit
{
    public interface INotepadEdit
    {
        void FindButtonClicked(object sender, EventArgs e);

        void TimeDateButtonClicked(object sender, EventArgs e);

        void FontButtonClicked(object sender, EventArgs e);
    }
}
