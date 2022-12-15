using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Notepad : Form
    {
        private string DefaultText { get; set; }
        private bool IsTitleUpdated { get; set; } = false;
        private bool IsContentNotLoaded { get; set; } = true;
        private bool IsNewlyCreated { get; set; } = true;

        public Notepad()
        {
            InitializeComponent();
            this.Text = "Untitled - Notepad";
            this.textBox1.Focus();
            this.textBox2.Text = "Ln 1, Col 1";
            DefaultText = this.textBox1.Text;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if ((textBox1.Text != DefaultText) && !IsTitleUpdated)
            {
                this.Text = "*" + this.Text;
                IsTitleUpdated = true;
            }

            if (textBox1.Text == DefaultText && Text.StartsWith("*"))
            {
                IsTitleUpdated = false;
                this.Text = this.Text.Substring(1);
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsTitleUpdated)
            {
                var result = MessageBox.Show("Do you want to save changes to " + this.Text.Substring(1).Split('-')[0], "Notepad", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    var res = this.saveFileDialog1.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
                        this.Text = saveFileDialog1.FileName + " - Notepad";
                    }
                }
                else if (result == DialogResult.No)
                {
                    this.textBox1.Clear();
                }
            }
            else
            {
                this.Text = "Untitled - Notepad";
                this.DefaultText = String.Empty;
                this.textBox1.Text = String.Empty;
                this.IsNewlyCreated = true;
            }
        }

        private void NewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("MyNotepad.exe");
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = this.openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.textBox1.Text = System.Text.Encoding.UTF8.GetString(File.ReadAllBytes(openFileDialog1.FileName));
                this.DefaultText = this.textBox1.Text;
                this.Text = Functions.GetNameFromAbsolutePath(openFileDialog1.FileName) + " - Notepad";
                this.textBox1.SelectionStart = this.textBox1.Text.Length;
                this.textBox1.SelectionLength = 0;
                this.IsContentNotLoaded = false;
                this.IsTitleUpdated = false;
                this.IsNewlyCreated = false;
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsNewlyCreated)
            {
                var res = this.saveFileDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
                    this.Text = saveFileDialog1.FileName + " - Notepad";
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (IsTitleUpdated)
            {
                var result = MessageBox.Show("Do you want to save changes to " + this.Text.Substring(1).Split('-')[0], "Notepad", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    var res = this.saveFileDialog1.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsNewlyCreated)
            {
                this.saveFileDialog1.FileName = ".txt";
            }
            else
            {
                this.saveFileDialog1.FileName = this.Text;
            }
            var result = this.saveFileDialog1.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    {
                        File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
                        this.Text = Functions.GetNameFromAbsolutePath(saveFileDialog1.FileName) + " - Notepad";
                    }
                    break;
                default: break;
            }
        }

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.printPreviewDialog1.ShowDialog();
        }

        private void PageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();

            pageSetupDialog1.PrinterSettings = new System.Drawing.Printing.PrinterSettings();

            pageSetupDialog1.ShowNetwork = false;

            DialogResult result = pageSetupDialog1.ShowDialog();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsTitleUpdated)
            {
                var result = MessageBox.Show("Do you want to save changes to " + this.Text.Substring(1).Split('-')[0], "Notepad", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    var res = this.saveFileDialog1.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
                    }
                }
                if (result == DialogResult.No)
                {
                    Process.GetCurrentProcess().Kill();
                }
            }
            else
            {
                Process.GetCurrentProcess().Kill();
            }
        }

        private void TimeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var time = DateTime.Now;
            var selectionIndex = textBox1.SelectionStart;
            textBox1.Text = textBox1.Text.Insert(selectionIndex, time.ToString());
            textBox1.SelectionStart = selectionIndex + time.ToString().Length;
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void FindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fontDialog = new FontDialog();

            switch (fontDialog.ShowDialog())
            {
                case DialogResult.OK:
                    this.textBox1.Font = fontDialog.Font;
                    break;
                default: break;
            }
        }
    }
}
