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
        public event EventHandler ReplaceButtonClickedEvent;
        public event EventHandler ReplaceAllButtonClickedEvent;

        private readonly INotepadEvents notepad;
        private readonly IFindPresenter presenter;

        public FindDialogBox(INotepadEvents notepad)
        {
            this.notepad = notepad;
            this.presenter = new FindPresenter(this);

            InitializeComponent();
            RoundCorners(this.Handle);
            FindTextBox.Text = "Find";
        }

        public void CloseButtonClicked(object sender, EventArgs e)
        {
            CloseButtonClickedEvent.Invoke(this, e);
        }

        void IFindMethods.FindButtonClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void IFindMethods.FindPreviousButtonClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void IFindMethods.CloseButtonClicked(object sender, EventArgs eventArgs)
        {
            throw new NotImplementedException();
        }
    }
}
