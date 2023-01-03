using System;

namespace Notepad.Presenter.Notepad.Interface
{
    public interface INotepadPresenterView
    {
        void StatusBarButtonClicked(object sender, EventArgs e);

        void WordWrapButtonClicked(object sender, EventArgs e);
    }
}
