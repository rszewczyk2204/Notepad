using Notepad.Model.DialogBox;
using Notepad.View.Interface.Find;
using System;

namespace Notepad.Presenter.Find.Implementation
{
    public class FindPresenter : IFindPresenter
    {
        private readonly IFindEvents findEvents;

        public FindPresenter(IFindEvents findEvents)
        {
            this.findEvents = findEvents;

            this.findEvents.CloseButtonClickedEvent += CloseButtonClicked;
        }

        public void CloseButtonClicked(object sender, EventArgs eventArgs)
        {
            FindDialogBox findDialogBox = sender as FindDialogBox;
            findDialogBox.Close();
        }
    }
}
