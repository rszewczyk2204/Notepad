using System;

namespace Notepad.Presenter.Notepad.Interface
{
    public interface INotepadPresenterView
    {
        void ZoomInButtonClicked(object sender, EventArgs e);

        void ZoomOutButtonClicked(object sender, EventArgs e);

        void RestoreDefaultZoomButtonClicked(object sender, EventArgs e);

        void StatusBarButtonClicked(object sender, EventArgs e);

        void WordWrapButtonClicked(object sender, EventArgs e);
    }
}
