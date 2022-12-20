using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using Notepad.View.Interface;
using System.Drawing.Printing;
using Notepad.Presenter.Interface;

using static Notepad.Functional.Functions;

namespace Notepad.Presenter.Implementation
{
    internal class ConfigurationPresenter : IConfigurationPresenter
    {
        string AbsoluteFilePath { get; set; }
        public bool IsTitleUpdated { get; set; } = false;
        public bool IsContentNotLoaded { get; set; } = true;
        public bool IsNewlyCreated { get; set; } = true;

        private readonly INotepadView configurationView;

        public ConfigurationPresenter(INotepadView configurationView)
        {
            this.configurationView = configurationView;
            this.configurationView.NewFormButtonClickedEvent += NewFormButtonClicked;
            this.configurationView.TextBoxTextChangedEvent += TextBoxTextChanged;
            this.configurationView.NewWindowButtonClickedEvent += NewWindowButtonClicked;
            this.configurationView.OpenFileButtonClickedEvent += OpenFileButtonClicked;
            this.configurationView.SaveButtonClickedEvent += SaveButtonClicked;
            this.configurationView.SaveAsButtonClickedEvent += SaveAsButtonClicked;
            this.configurationView.PageSetupButtonClickedEvent += PageSetupButtonClicked;
            this.configurationView.PrintButtonClickedEvent += PrintButtonClicked;
            this.configurationView.ExitButtonClickedEvent += ExitButtonClicked;

            this.configurationView.TimeDateButtonClickedEvent += TimeDateButtonClicked;
            this.configurationView.FontButtonClickedEvent += FontButtonClicked;
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
                var result = MessageBox.Show("Do you want to save changes to " + configurationView.TitleBarText.Substring(1).Split('-')[0], "Notepad", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    var res = saveFileDialog.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, configurationView.InputText);
                        configurationView.TitleBarText = saveFileDialog.FileName + " - Notepad";
                    }
                }
            }
            else
            {
                configurationView.TitleBarText = "Untitled - Notepad";
                configurationView.DefaultText = String.Empty;
                configurationView.InputText = String.Empty;
                IsNewlyCreated = true;
            }
        }

        public void TextBoxTextChanged(object sender, EventArgs eventArgs)
        {
            var TextBoxText = configurationView.InputText;
            var DefaultText = configurationView.DefaultText;
            var TitleBarText = configurationView.TitleBarText;

            if ((TextBoxText != DefaultText) && !IsTitleUpdated)
            {
                configurationView.TitleBarText = "*" + TitleBarText;
                IsTitleUpdated = true;
            }

            if (TextBoxText == DefaultText && TitleBarText.StartsWith("*"))
            {
                IsTitleUpdated = false;
                configurationView.TitleBarText = TitleBarText.Substring(1);
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
                configurationView.InputText = Encoding.UTF8.GetString(File.ReadAllBytes(openFileDialog.FileName));
                configurationView.DefaultText = configurationView.InputText;
                configurationView.TitleBarText = GetNameFromAbsolutePath(openFileDialog.FileName) + " - Notepad";
                IsTitleUpdated = false;
                IsNewlyCreated = false;
                configurationView.TextBoxSelectionLength = 0;
                configurationView.TextBoxSelectionStart = configurationView.InputText.Length;
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
                    File.WriteAllText(saveFileDialog.FileName, configurationView.InputText);
                    configurationView.TitleBarText = saveFileDialog.FileName + " - Notepad";
                    IsNewlyCreated = false;
                }
            }
            else
            {
                File.WriteAllText(AbsoluteFilePath, configurationView.InputText);
                configurationView.TitleBarText = configurationView.TitleBarText.Substring(1);
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
                File.WriteAllText(saveFileDialog.FileName, configurationView.InputText);
                configurationView.TitleBarText = saveFileDialog.FileName + " - Notepad";
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
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void ExitButtonClicked(object sender, EventArgs eventArgs)
        {
            Application.Exit();
        }

        public void TimeDateButtonClicked(object sender, EventArgs eventArgs)
        {
            DateTime date = DateTime.Now;

            var selectionStart = configurationView.TextBoxSelectionStart;
            configurationView.InputText = configurationView.InputText.Insert(selectionStart, date.ToString());
            configurationView.TextBoxSelectionStart = selectionStart + date.ToString().Length;
        }

        public void FontButtonClicked(object sender, EventArgs eventArgs) 
        {
            FontDialog fontDialog = new FontDialog();

            var result = fontDialog.ShowDialog();

            if (result == DialogResult.OK) 
            {
                configurationView.Font = fontDialog.Font;
            }
        }


    }
}
