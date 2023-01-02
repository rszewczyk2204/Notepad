using System;

namespace Notepad.Presenter.Notepad.Interface
{
    public interface INotepadPresenterEdit
    {
        void UndoButtonClicked(object sender, EventArgs eventArgs);

        void CutButtonClicked(object sender, EventArgs eventArgs);

        void CopyButtonClicked(object sender, EventArgs eventArgs);

        void PasteButtonClicked(object sender, EventArgs eventArgs);

        void DeleteButtonClicked(object sender, EventArgs eventArgs);

        void FindButtonClicked(object sender, EventArgs eventArgs);

        void TimeDateButtonClicked(object sender, EventArgs eventArgs);

        void FontButtonClicked(object sender, EventArgs eventArgs);
    }
}
