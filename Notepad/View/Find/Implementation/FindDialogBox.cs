using Notepad.View.Interface.Find;
using System;
using System.Windows.Forms;

namespace Notepad.Model.DialogBox
{
    public partial class FindDialogBox : Form, IFindEvents, IFindMethods
    {
        public event EventHandler CloseButtonClickedEvent;

        public FindDialogBox()
        {
            InitializeComponent();
            FindTextBox.Text = "Find";
            FindTextBox.Focus();
        }

        public void CloseButtonClicked(object sender, EventArgs e)
        {
            CloseButtonClickedEvent.Invoke(this, e);
        }
    }
}
