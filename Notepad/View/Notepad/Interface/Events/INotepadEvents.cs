using System;

namespace Notepad.View.Notepad.Interface.Events
{
    public partial interface INotepadEvents
    {
        event EventHandler TextBoxTextChangedEvent;
        event EventHandler TextSelectedEvent;
        event EventHandler TextBoxClickedEvent;
    }
}
