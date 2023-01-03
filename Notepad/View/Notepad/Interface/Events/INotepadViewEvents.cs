using System;

namespace Notepad.View.Notepad.Interface.Events
{
    public partial interface INotepadEvents
    {
        event EventHandler ZoomInButtonClickedEvent;
        event EventHandler ZoomOutButtonClickedEvent;
        event EventHandler RestoreDefaultZoomButtonClickedEvent;
        event EventHandler StatusBarButtonClickedEvent;
        event EventHandler WordWrapButtonClickedEvent;
    }
}
