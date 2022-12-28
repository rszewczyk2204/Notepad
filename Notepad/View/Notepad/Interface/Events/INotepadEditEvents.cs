using System;

namespace Notepad.View.Notepad.Interface.Events
{
    public partial interface INotepad
    {
        event EventHandler FindButtonClickedEvent;
        event EventHandler TimeDateButtonClickedEvent;
        event EventHandler FontButtonClickedEvent;
    }
}
