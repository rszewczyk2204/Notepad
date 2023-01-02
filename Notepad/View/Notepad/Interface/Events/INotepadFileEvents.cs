using System;

namespace Notepad.View.Notepad.Interface.Events
{
    public partial interface INotepadEvents
    {
        event EventHandler NewFormButtonClickedEvent;
        event EventHandler NewWindowButtonClickedEvent;
        event EventHandler OpenFileButtonClickedEvent;
        event EventHandler SaveButtonClickedEvent;
        event EventHandler SaveAsButtonClickedEvent;
        event EventHandler PageSetupButtonClickedEvent;
        event EventHandler PrintButtonClickedEvent;
        event EventHandler ExitButtonClickedEvent;
    }
}
