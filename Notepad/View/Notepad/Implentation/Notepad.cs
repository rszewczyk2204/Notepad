using Notepad.Presenter.Implementation;
using Notepad.Presenter.Interface;
using Notepad.View.Notepad.Interface.Edit;
using Notepad.View.Notepad.Interface.Events;
using Notepad.View.Notepad.Interface.View;
using System;
using System.Drawing;
using System.Windows.Forms;
using static Notepad.Functional.Utility;

namespace Notepad.View.Notepad.Implentation
{
    public partial class Notepad : Form, INotepad, INotepadView, INotepadEdit
    {
        public string DefaultText { get; set; }

        public event EventHandler FindButtonClickedEvent;

        public event EventHandler TimeDateButtonClickedEvent;
        public event EventHandler FontButtonClickedEvent;

        public event EventHandler ButtonHoveredOverEvent;

        private readonly IConfigurationPresenter configurationPresenter;

        public Notepad()
        {
            configurationPresenter = new ConfigurationPresenter(this);
            InitializeComponent();
            Text = "Untitled - Notepad";
            textBox1.Focus();
            textBox2.Text = "Ln 1, Col 1";
            DefaultText = textBox1.Text;
            menuStrip1.Renderer = new MyRenderer();
        }

        public void FindButtonClicked(object sender, EventArgs eventArgs)
        {
            FindButtonClickedEvent.Invoke(this, eventArgs);
        }

        public void TimeDateButtonClicked(object sender, EventArgs eventArgs)
        {
            TimeDateButtonClickedEvent.Invoke(this, eventArgs);
        }

        public void FontButtonClicked(object sender, EventArgs eventArgs)
        {
            FontButtonClickedEvent.Invoke(this, eventArgs);
        }

        protected override void OnActivated(EventArgs e)
        {
            UseImmersiveDarkMode(this.Handle, true);
            base.OnActivated(e);
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

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }

        private class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.Gray; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.Gray; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.Gray; }
            }
            public override Color MenuItemBorder
            {
                get { return Color.Empty; }
            }
            public override Color MenuItemPressedGradientBegin => Color.Gray;
            public override Color MenuItemPressedGradientEnd => Color.Gray;
            public override Color MenuItemPressedGradientMiddle => Color.Gray;
        }
    }
}
