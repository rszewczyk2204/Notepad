using Notepad.Presenter.Implementation;
using Notepad.Presenter.Interface;
using Notepad.View.Interface;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Notepad.View.Implentation
{
    public partial class Notepad : Form, INotepadView, INotepadFile, INotepadEdit
    {
        public string DefaultText { get; set; }

        public event EventHandler NewFormButtonClickedEvent;
        public event EventHandler TextBoxTextChangedEvent;
        public event EventHandler NewWindowButtonClickedEvent;
        public event EventHandler OpenFileButtonClickedEvent;
        public event EventHandler SaveButtonClickedEvent;
        public event EventHandler SaveAsButtonClickedEvent;
        public event EventHandler PageSetupButtonClickedEvent;
        public event EventHandler PrintButtonClickedEvent;
        public event EventHandler ExitButtonClickedEvent;

        public event EventHandler TimeDateButtonClickedEvent;
        public event EventHandler FontButtonClickedEvent;

        private readonly IConfigurationPresenter configurationPresenter;

        public Notepad()
        {
            configurationPresenter = new ConfigurationPresenter(this);
            InitializeComponent();
            Text = "Untitled - Notepad";
            textBox1.Focus();
            textBox2.Text = "Ln 1, Col 1";
            DefaultText = textBox1.Text;
        }

        public void TextBoxTextChanged(object sender, EventArgs e)
        {
            TextBoxTextChangedEvent.Invoke(this, e);
        }

        public void NewFormButtonClicked(object sender, EventArgs eventArgs)
        {
            NewFormButtonClickedEvent.Invoke(this, eventArgs);
        }

        public void NewWindowButtonClicked(object sender, EventArgs eventArgs)
        {
            NewWindowButtonClickedEvent.Invoke(this, eventArgs);
        }

        public void OpenFileButtonClicked(object sender, EventArgs eventArgs)
        {
            OpenFileButtonClickedEvent.Invoke(this, eventArgs);
        }

        public void SaveButtonClicked(object sender, EventArgs eventArgs)
        {
            SaveButtonClickedEvent.Invoke(this, eventArgs);
        }

        public void SaveAsButtonClicked(object sender, EventArgs eventArgs)
        {
            SaveAsButtonClickedEvent.Invoke(this, eventArgs);
        }

        public void PageSetupButtonClicked(object sender, EventArgs eventArgs)
        {
            PageSetupButtonClickedEvent.Invoke(this, eventArgs);
        }

        public void PrintButtonClicked(object sender, EventArgs eventArgs)
        {
            PrintButtonClickedEvent.Invoke(this, eventArgs);
        }

        public void ExitButtonClicked(object sender, EventArgs eventArgs)
        {
            ExitButtonClickedEvent.Invoke(this, eventArgs);
        }

        public void TimeDateButtonClicked(object sender, EventArgs eventArgs)
        {
            TimeDateButtonClickedEvent.Invoke(this, eventArgs);
        }

        public void FontButtonClicked(object sender, EventArgs eventArgs)
        {
            FontButtonClickedEvent.Invoke(this, eventArgs);
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

        public Font Font
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
    }
}
