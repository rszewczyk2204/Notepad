using Notepad.Presenter.Notepad.Interface;
using System;
using System.Windows.Forms;

namespace Notepad.Presenter.Notepad.Implementation
{
    public partial class NotepadPresenter : INotepadPresenterView
    {
        public void StatusBarButtonClicked(object sender, EventArgs e)
        {
            TableLayoutPanel tableLayoutPanel1 = sender as TableLayoutPanel;
            if (tableLayoutPanel1.Visible)
            {
                tableLayoutPanel1.Visible = false;
            }
            else
            {
                tableLayoutPanel1.Visible = true;
            }
        }

        public void WordWrapButtonClicked(object sender, EventArgs e)
        {
            RichTextBox richTextBox = sender as RichTextBox;

            if (richTextBox.WordWrap)
            {
                richTextBox.WordWrap = false;
            }
            else
            {
                richTextBox.WordWrap = true; 
            }
        }
    }
}
