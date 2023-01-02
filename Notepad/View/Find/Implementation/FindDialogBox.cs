using Notepad.Presenter.Find.Implementation;
using Notepad.View.Interface.Find;
using Notepad.View.Notepad.Interface.Events;
using System;
using System.Windows.Forms;
using static Notepad.Functional.Utility;

namespace Notepad.Model.DialogBox
{
    public partial class FindDialogBox : Form, IFindEvents, IFindMethods
    {
        public event EventHandler CloseButtonClickedEvent;

        private readonly INotepadEvents notepad;
        private readonly IFindPresenter presenter;

        public FindDialogBox(INotepadEvents notepad)
        {
            this.notepad = notepad;
            this.presenter = new FindPresenter(this);

            InitializeComponent();
            RoundCorners();
            FindTextBox.Text = "Find";
        }

        public void CloseButtonClicked(object sender, EventArgs e)
        {
            CloseButtonClickedEvent.Invoke(this, e);
        }

        private void RoundCorners()
        {
            IntPtr hWnd = this.Handle;
            var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
            var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
            DwmSetWindowAttribute(hWnd, attribute, ref preference, sizeof(uint));
        }
    }
}
