using Notepad.Presenter.Notepad.Interface;
using System;
using System.Windows.Forms;
using static Notepad.Functional.Utility;

namespace Notepad.Presenter.Notepad.Implementation
{
    public partial class NotepadPresenter : INotepadPresenterView
    {
        public void ZoomInButtonClicked(object sender, EventArgs e)
        {
            RichTextBox richTextBox = sender as RichTextBox;
            richTextBox.Font = new System.Drawing.Font(richTextBox.Font.FontFamily.Name, richTextBox.Font.Size + 1);
        }

        public void ZoomOutButtonClicked(object sender, EventArgs e)
        {
            RichTextBox richTextBox = sender as RichTextBox;
            richTextBox.Font = new System.Drawing.Font(richTextBox.Font.FontFamily.Name, richTextBox.Font.Size - 1);
        }

        public void RestoreDefaultZoomButtonClicked(object sender, EventArgs e)
        {
            RichTextBox richTextBox = sender as RichTextBox;
            richTextBox.Font = new System.Drawing.Font(richTextBox.Font.FontFamily.Name, DefaultFontSize);
        }

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
