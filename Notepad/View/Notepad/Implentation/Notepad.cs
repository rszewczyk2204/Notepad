using Notepad.Presenter.Notepad.Implementation;
using Notepad.Presenter.Notepad.Interface;
using Notepad.View.Notepad.Interface;
using Notepad.View.Notepad.Interface.Events;
using System;
using System.Drawing;
using System.Windows.Forms;
using static Notepad.Functional.Utility;

namespace Notepad.View.Notepad.Implentation
{
    public partial class Notepad : Form, INotepadEvents, INotepadMethods
    {
        private bool _isTitleUpdated;
        private bool _isNewlyCreated = false;
        private string _absoluteFilePath;

        private readonly INotepadPresenter notepadPresenter;

        public event EventHandler TextSelectedEvent;

        public Notepad()
        {
            notepadPresenter = new NotepadPresenter(this);
            InitializeComponent();
            Text = "Untitled - Notepad";
            textBox1.Focus();
            textBox2.Text = "Ln 1, Col 1";
            DefaultText = textBox1.Text;
            menuStrip1.Renderer = new MyRenderer();
            IsUndoButtonEnabled = false;
        }

        protected override void OnActivated(EventArgs e)
        {
            UseImmersiveDarkMode(this.Handle, true);
            base.OnActivated(e);
        }

        public void TextBoxTextChanged(object sender, EventArgs e)
        {
            TextBoxTextChangedEvent.Invoke(this, e);
        }

        public void TextSelected(object sender, EventArgs e)
        {
            TextSelectedEvent.Invoke(this, e);
        }

        public string DefaultText { get; set; }

        public bool IsTitleUpdated
        {
            set => _isTitleUpdated = value;
            get => _isTitleUpdated;
        }

        public string InputText
        {
            get
            {
                return textBox1.Text;
            }

            set
            {
                textBox1.Text = value;
            }
        }

        public string TitleBarText
        {
            get
            {
                return Text;
            }
            set
            {
                Text = value;
            }
        }

        public int TextBoxSelectionStart
        {
            get
            {
                return textBox1.SelectionStart;
            }
            set
            {
                textBox1.SelectionStart = value;
            }
        }

        public int TextBoxSelectionLength 
        {
            get
            {
                return textBox1.SelectionLength;
            }
            set
            {
                textBox1.SelectionStart = value;
            }
        }

        public new Font Font
        {
            get
            {
                return textBox1.Font;
            }
            set
            {
                textBox1.Font = value;
            }
        }

        public bool IsNewlyCreated
        {
            get => _isNewlyCreated;
            set => _isNewlyCreated = value;
        }

        public string AbsoluteFilePath
        {
            get => _absoluteFilePath;
            set => _absoluteFilePath = value;
        }

        public bool IsUndoButtonEnabled
        {
            set => undoToolStripMenuItem.Enabled = value;
        }

        public bool IsCutButtonEnabled
        {
            set => cutToolStripMenuItem.Enabled = value;
        }

        public int SelectionLength
        {
            get => textBox1.SelectionLength;
        }

        public bool IsCopyButtonEnabled
        {
            set => copyToolStripMenuItem.Enabled = value;
        }

        public bool IsDeleteButtonEnabled
        {
            set => deleteToolStripMenuItem.Enabled = value;
        }
    }
}
