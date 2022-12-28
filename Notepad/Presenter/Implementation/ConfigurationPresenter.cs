using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing.Printing;
using Notepad.Presenter.Interface;
using Notepad.Model.DialogBox;

using static Notepad.Functional.Functions;
using Notepad.View.Notepad.Interface.Events;

namespace Notepad.Presenter.Implementation
{
    internal class ConfigurationPresenter : IConfigurationPresenter
    {
        string AbsoluteFilePath { get; set; }
        public bool IsTitleUpdated { get; set; } = false;
        public bool IsContentNotLoaded { get; set; } = true;
        public bool IsNewlyCreated { get; set; } = true;

        private readonly INotepad notepad;

        public ConfigurationPresenter(INotepad notepad)
        {
            this.notepad = notepad;
            this.notepad.NewFormButtonClickedEvent += NewFormButtonClicked;
            this.notepad.TextBoxTextChangedEvent += TextBoxTextChanged;
            this.notepad.NewWindowButtonClickedEvent += NewWindowButtonClicked;
            this.notepad.OpenFileButtonClickedEvent += OpenFileButtonClicked;
            this.notepad.SaveButtonClickedEvent += SaveButtonClicked;
            this.notepad.SaveAsButtonClickedEvent += SaveAsButtonClicked;
            this.notepad.PageSetupButtonClickedEvent += PageSetupButtonClicked;
            this.notepad.PrintButtonClickedEvent += PrintButtonClicked;
            this.notepad.ExitButtonClickedEvent += ExitButtonClicked;

            this.notepad.FindButtonClickedEvent += FindButtonClicked;
            this.notepad.TimeDateButtonClickedEvent += TimeDateButtonClicked;
            this.notepad.FontButtonClickedEvent += FontButtonClicked;
        }

        public void NewFormButtonClicked(object sender, EventArgs eventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Save as"
            };

            if (IsTitleUpdated)
            {
                var result = MessageBox.Show("Do you want to save changes to " + notepad.TitleBarText.Substring(1).Split('-')[0], "Notepad", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    var res = saveFileDialog.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, notepad.InputText);
                        notepad.TitleBarText = saveFileDialog.FileName + " - Notepad";
                    }
                }
            }
            else
            {
                notepad.TitleBarText = "Untitled - Notepad";
                notepad.DefaultText = String.Empty;
                notepad.InputText = String.Empty;
                IsNewlyCreated = true;
            }
        }

        public void TextBoxTextChanged(object sender, EventArgs eventArgs)
        {
            var TextBoxText = notepad.InputText;
            var DefaultText = notepad.DefaultText;
            var TitleBarText = notepad.TitleBarText;

            if ((TextBoxText != DefaultText) && !IsTitleUpdated)
            {
                notepad.TitleBarText = "*" + TitleBarText;
                IsTitleUpdated = true;
            }

            if (TextBoxText == DefaultText && TitleBarText.StartsWith("*"))
            {
                IsTitleUpdated = false;
                notepad.TitleBarText = TitleBarText.Substring(1);
            }
        }

        public void NewWindowButtonClicked(object sender, EventArgs eventArgs)
        {
            Process.Start("MyNotepad.exe");
        }

        public void OpenFileButtonClicked(object sender, EventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                DefaultExt = "txt",
                Filter = "Text documents (*.txt)|*.txt|All files (*.*)|*.*"
            };

            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                notepad.InputText = Encoding.UTF8.GetString(File.ReadAllBytes(openFileDialog.FileName));
                notepad.DefaultText = notepad.InputText;
                notepad.TitleBarText = GetNameFromAbsolutePath(openFileDialog.FileName) + " - Notepad";
                IsTitleUpdated = false;
                IsNewlyCreated = false;
                notepad.TextBoxSelectionLength = 0;
                notepad.TextBoxSelectionStart = notepad.InputText.Length;
                AbsoluteFilePath = openFileDialog.FileName;
            }
        }

        public void SaveButtonClicked(object sender, EventArgs eventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Save"
            };

            if (IsNewlyCreated)
            {
                var res = saveFileDialog.ShowDialog();
                if (res == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, notepad.InputText);
                    notepad.TitleBarText = saveFileDialog.FileName + " - Notepad";
                    IsNewlyCreated = false;
                }
            }
            else
            {
                File.WriteAllText(AbsoluteFilePath, notepad.InputText);
                notepad.TitleBarText = notepad.TitleBarText.Substring(1);
            }
        }

        public void SaveAsButtonClicked(object sender, EventArgs eventArgs) 
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Save"
            };

            var res = saveFileDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, notepad.InputText);
                notepad.TitleBarText = saveFileDialog.FileName + " - Notepad";
            }
        }

        public void PageSetupButtonClicked(object sender, EventArgs eventArgs) 
        {
            PageSetupDialog pageSetupDialog = new PageSetupDialog
            {
                PageSettings = new PageSettings(),
                PrinterSettings = new PrinterSettings(),
                ShowNetwork = false
            };

            pageSetupDialog.ShowDialog();
        }

        public void PrintButtonClicked(object sender, EventArgs eventArgs)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.ShowDialog();
        }

        public void FindButtonClicked(object sender, EventArgs eventArgs)
        {
            FindDialogBox findDialogBox = new FindDialogBox();
            findDialogBox.ShowDialog();
        }

        /// <summary>
        /// Right now it forcefully closes the whole app without saving any content to a new file or a file the content was loaded from
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void ExitButtonClicked(object sender, EventArgs eventArgs)
        {
            Application.Exit();
        }

        public void TimeDateButtonClicked(object sender, EventArgs eventArgs)
        {
            DateTime date = DateTime.Now;

            var selectionStart = notepad.TextBoxSelectionStart;
            notepad.InputText = notepad.InputText.Insert(selectionStart, date.ToString());
            notepad.TextBoxSelectionStart = selectionStart + date.ToString().Length;
        }

        public void FontButtonClicked(object sender, EventArgs eventArgs) 
        {
            FontDialog fontDialog = new FontDialog();

            var result = fontDialog.ShowDialog();

            if (result == DialogResult.OK) 
            {
                notepad.Font = fontDialog.Font;
            }
        }

        public void ButtonHoveredOver(object sender, EventArgs eventArgs)
        {
            //ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            //toolStripMenuItem.BackColor = Color.Gray;
            //toolStripMenuItem.ForeColor = Color.Black;
        }
    }
}
