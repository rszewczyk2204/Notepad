using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing.Printing;

using static Notepad.Functional.Functions;
using Notepad.Presenter.Notepad.Interface;

namespace Notepad.Presenter.Notepad.Implementation
{
    public partial class NotepadPresenter : INotepadPresenterFile
    {

        public void NewFormButtonClicked(object sender, EventArgs eventArgs)
        {
            View.Notepad.Implentation.Notepad notepad = sender as View.Notepad.Implentation.Notepad;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Save as"
            };

            if (notepad.IsTitleUpdated)
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
                notepad.InputText = String.Empty;
                notepad.DefaultText = String.Empty;
                notepad.TitleBarText = "Untitled - Notepad";
                notepad.IsNewlyCreated = true;
            }
        }

        public void NewWindowButtonClicked(object sender, EventArgs eventArgs)
        {
            Process.Start("MyNotepad.exe");
        }

        public void OpenFileButtonClicked(object sender, EventArgs eventArgs)
        {
            View.Notepad.Implentation.Notepad notepad = sender as View.Notepad.Implentation.Notepad;

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
                notepad.IsTitleUpdated = false;
                notepad.IsNewlyCreated = false;
                notepad.TextBoxSelectionLength = 0;
                notepad.TextBoxSelectionStart = notepad.InputText.Length;
                notepad.AbsoluteFilePath = openFileDialog.FileName;
            }
        }

        public void SaveButtonClicked(object sender, EventArgs eventArgs)
        {
            View.Notepad.Implentation.Notepad notepad = sender as View.Notepad.Implentation.Notepad;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Save"
            };

            if (notepad.IsNewlyCreated)
            {
                var res = saveFileDialog.ShowDialog();
                if (res == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, notepad.InputText);
                    notepad.TitleBarText = saveFileDialog.FileName + " - Notepad";
                    notepad.IsNewlyCreated = false;
                }
            }
            else
            {
                File.WriteAllText(notepad.AbsoluteFilePath, notepad.InputText);
                notepad.TitleBarText = notepad.TitleBarText.Substring(1);
            }
        }

        public void SaveAsButtonClicked(object sender, EventArgs eventArgs) 
        {
            View.Notepad.Implentation.Notepad notepad = sender as View.Notepad.Implentation.Notepad;

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

        /// <summary>
        /// Right now it forcefully closes the whole app without saving any content to a new file or a file the content was loaded from
        /// </summary>
        /// <param name="sender">Callee passed as a parameter</param>
        /// <param name="eventArgs">Event arguments passed to method with a callee</param>
        public void ExitButtonClicked(object sender, EventArgs eventArgs)
        {
            Application.Exit();
        }
    }
}
