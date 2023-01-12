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
            #region FileRegion
            this._notepad.NewFormButtonClickedEvent += NewFormButtonClicked;
            this._notepad.NewWindowButtonClickedEvent += NewWindowButtonClicked;
            this._notepad.OpenFileButtonClickedEvent += OpenFileButtonClicked;
            this._notepad.SaveButtonClickedEvent += SaveButtonClicked;
            this._notepad.SaveAsButtonClickedEvent += SaveAsButtonClicked;
            this._notepad.PageSetupButtonClickedEvent += PageSetupButtonClicked;
            this._notepad.PrintButtonClickedEvent += PrintButtonClicked;
            this._notepad.ExitButtonClickedEvent += ExitButtonClicked;
            #endregion

            #region GeneralRegion
            this._notepad.TextBoxTextChangedEvent += TextBoxTextChanged;
            this._notepad.TextSelectedEvent += TextSelected;
            this._notepad.TextBoxClickedEvent += TextBoxClicked;
            #endregion

            #region EditRegion
            this._notepad.UndoButtonClickedEvent += UndoButtonClicked;
            this._notepad.CopyButtonClickedEvent += CopyButtonClicked;
            this._notepad.CutButtonClickedEvent += CutButtonClicked;
            this._notepad.PasteButtonClickedEvent += PasteButtonClicked;
            this._notepad.DeleteButtonClickedEvent += DeleteButtonClicked;
            this._notepad.FindButtonClickedEvent += FindButtonClicked;
            this._notepad.TimeDateButtonClickedEvent += TimeDateButtonClicked;
            this._notepad.FontButtonClickedEvent += FontButtonClicked;
            #endregion

            #region ViewRegion
            this._notepad.ZoomInButtonClickedEvent += ZoomInButtonClicked;
            this._notepad.ZoomOutButtonClickedEvent += ZoomOutButtonClicked;
            this._notepad.RestoreDefaultZoomButtonClickedEvent += RestoreDefaultZoomButtonClicked;
            this._notepad.StatusBarButtonClickedEvent += StatusBarButtonClicked;
            this._notepad.WordWrapButtonClickedEvent += WordWrapButtonClicked;
            #endregion
        }

        public void TextBoxTextChanged(object sender, EventArgs e)
        {
            View.Notepad.Implentation.Notepad notepad = sender as View.Notepad.Implentation.Notepad;

            if ((notepad.InputText != notepad.DefaultText) && !notepad.IsTitleUpdated)
            {
                notepad.TitleBarText = "*" + notepad.TitleBarText;
                notepad.IsTitleUpdated = true;
                notepad.IsUndoButtonEnabled = true;
                notepad.IsFindButtonEnabled = true;
                notepad.IsFindNextButtonEnabled = true;
                notepad.IsFindPreviousButtonEnabled = true;
            }

            if ((notepad.InputText == notepad.DefaultText) && notepad.TitleBarText.StartsWith("*"))
            {
                notepad.IsUndoButtonEnabled = false;
                notepad.IsTitleUpdated = false;
                notepad.IsFindButtonEnabled = false;
                notepad.IsFindNextButtonEnabled = false;
                notepad.IsFindPreviousButtonEnabled = false;
                notepad.TitleBarText = notepad.TitleBarText.Substring(1);
            }

            var subText = notepad.InputText.Substring(0, notepad.TextBoxSelectionStart);
            var arr = subText.Split('\n');
            int ln = arr.Length;

            int pos = arr[arr.Length - 1].Length + 1;

            notepad.CursorPositionText = "Ln " + ln + ", Col " + pos;
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

        public void TextBoxClicked(object sender, EventArgs eventArgs)
        {
            View.Notepad.Implentation.Notepad notepad = sender as View.Notepad.Implentation.Notepad;

            var subText = notepad.InputText.Substring(0, notepad.TextBoxSelectionStart);
            var arr = subText.Split('\n');
            int ln = arr.Length;

            int pos = arr[arr.Length - 1].Length + 1;

            notepad.CursorPositionText = "Ln " + ln + ", Col " + pos;
        }
    }
}
