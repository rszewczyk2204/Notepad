using System;

namespace Notepad.View.Notepad.Interface.View
{
    public interface INotepadView
    {
        void ZoomInButtonClicked(object sender, EventArgs e);
        void ZoomOutButtonClicked(object sender, EventArgs e);
        void RestoreDefaultZoomButtonClicked(object sender, EventArgs e);
        void StatusBarButtonClicked(object sender, EventArgs e);
        void WordWrapButtonClicked(object sender, EventArgs e);
    }
}
