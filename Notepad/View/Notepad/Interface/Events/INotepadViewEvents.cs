using System;

namespace Notepad.View.Notepad.Interface.Events
{
    public partial interface INotepadEvents
    {
        event EventHandler StatusBarButtonClickedEvent;
        event EventHandler WordWrapButtonClickedEvent;
    }
}
