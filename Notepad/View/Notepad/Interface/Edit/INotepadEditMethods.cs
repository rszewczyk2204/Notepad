using System;

namespace Notepad.View.Notepad.Interface.Edit
{
    public interface INotepadEdit
    {
        void UndoButtonClicked(object sender, EventArgs e);

        void CutButtonClicked(object sender, EventArgs e);

        void DeleteButtonClicked(object sender, EventArgs e);

        void FindButtonClicked(object sender, EventArgs e);

        void TimeDateButtonClicked(object sender, EventArgs e);

        void FontButtonClicked(object sender, EventArgs e);
    }
}
