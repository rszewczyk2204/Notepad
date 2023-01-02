using Notepad.Presenter.Notepad.Interface;
using System.Windows.Forms;
using System;
using Notepad.Model.DialogBox;

using static Notepad.Functional.Functions;

namespace Notepad.Presenter.Notepad.Implementation
{
    public partial class NotepadPresenter : INotepadPresenterEdit
    {
        public void UndoButtonClicked(object sender, EventArgs e)
        {
            RichTextBox inputTextBox = sender as RichTextBox;
            inputTextBox.Undo();
        }

        public void CutButtonClicked(object sender, EventArgs e)
        {
            RichTextBox inputTextBox = sender as RichTextBox;
            inputTextBox.Cut();
        }

        public void DeleteButtonClicked(object sender, EventArgs e)
        {
            RichTextBox inputTextBox = sender as RichTextBox;
            inputTextBox.SelectedText = "";
        }

        public void FindButtonClicked(object sender, EventArgs eventArgs)
        {
            View.Notepad.Implentation.Notepad notepad = sender as View.Notepad.Implentation.Notepad;

            FindDialogBox findDialogBox = new FindDialogBox(notepad);
            findDialogBox.ShowDialog();
        }


        public void TimeDateButtonClicked(object sender, EventArgs eventArgs)
        {
            View.Notepad.Implentation.Notepad notepad = sender as View.Notepad.Implentation.Notepad;

            String formattedDate = GetDate(DateTime.Now);
            var selectionStart = notepad.TextBoxSelectionStart;
            notepad.InputText = notepad.InputText.Insert(selectionStart, formattedDate);
            notepad.TextBoxSelectionStart = selectionStart + formattedDate.Length;
        }

        public void FontButtonClicked(object sender, EventArgs eventArgs)
        {
            View.Notepad.Implentation.Notepad notepad = sender as View.Notepad.Implentation.Notepad;

            FontDialog fontDialog = new FontDialog();

            var result = fontDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                notepad.Font = fontDialog.Font;
            }
        }
    }
}
