using Notepad.Presenter.Notepad.Interface;
using Notepad.View.Notepad.Interface.Events;
using System;

namespace Notepad.Presenter.Notepad.Implementation
{
    public partial class NotepadPresenter : INotepadPresenter
    {
        private readonly INotepadEvents _notepad;

        public NotepadPresenter(INotepadEvents notepad)
        {
            this._notepad = notepad;
            this._notepad.NewFormButtonClickedEvent += NewFormButtonClicked;
            this._notepad.NewWindowButtonClickedEvent += NewWindowButtonClicked;
            this._notepad.OpenFileButtonClickedEvent += OpenFileButtonClicked;
            this._notepad.SaveButtonClickedEvent += SaveButtonClicked;
            this._notepad.SaveAsButtonClickedEvent += SaveAsButtonClicked;
            this._notepad.PageSetupButtonClickedEvent += PageSetupButtonClicked;
            this._notepad.PrintButtonClickedEvent += PrintButtonClicked;
            this._notepad.ExitButtonClickedEvent += ExitButtonClicked;

            this._notepad.TextBoxTextChangedEvent += TextBoxTextChanged;
            this._notepad.TextSelectedEvent += TextSelected;

            this._notepad.UndoButtonClickedEvent += UndoButtonClicked;
            this._notepad.CopyButtonClickedEvent += CopyButtonClicked;
            this._notepad.CutButtonClickedEvent += CutButtonClicked;
            this._notepad.PasteButtonClickedEvent += PasteButtonClicked;
            this._notepad.DeleteButtonClickedEvent += DeleteButtonClicked;
            this._notepad.FindButtonClickedEvent += FindButtonClicked;
            this._notepad.TimeDateButtonClickedEvent += TimeDateButtonClicked;
            this._notepad.FontButtonClickedEvent += FontButtonClicked;

            this._notepad.StatusBarButtonClickedEvent += StatusBarButtonClicked;
            this._notepad.WordWrapButtonClickedEvent += WordWrapButtonClicked;
        }

        public void TextBoxTextChanged(object sender, EventArgs eventArgs)
        {
            View.Notepad.Implentation.Notepad notepad = sender as View.Notepad.Implentation.Notepad;

            if ((notepad.InputText != notepad.DefaultText) && !notepad.IsTitleUpdated)
            {
                notepad.TitleBarText = "*" + notepad.TitleBarText;
                notepad.IsTitleUpdated = true;
                notepad.IsUndoButtonEnabled = true;
                notepad.IsFindButtonEnabled = true;
                notepad.IsFindNextButtonEnabled = true;
            }

            if ((notepad.InputText == notepad.DefaultText) && notepad.TitleBarText.StartsWith("*"))
            {
                notepad.IsUndoButtonEnabled = false;
                notepad.IsTitleUpdated = false;
                notepad.IsFindButtonEnabled = false;
                notepad.IsFindNextButtonEnabled = false;
                notepad.TitleBarText = notepad.TitleBarText.Substring(1);
            }
        }

        public void TextSelected(object sender, EventArgs eventArgs)
        {
            View.Notepad.Implentation.Notepad notepad = sender as View.Notepad.Implentation.Notepad;

            if (notepad.SelectionLength > 0)
            {
                notepad.IsCopyButtonEnabled = true;
                notepad.IsCutButtonEnabled = true;
                notepad.IsDeleteButtonEnabled = true;
            }
            else
            {
                notepad.IsCopyButtonEnabled = false;
                notepad.IsCutButtonEnabled = false;
                notepad.IsDeleteButtonEnabled = false;
            }
        }
    }
}
