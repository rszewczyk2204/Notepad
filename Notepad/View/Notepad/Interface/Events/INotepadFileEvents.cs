using Notepad.View.Interface;
using System;

namespace Notepad.View.Notepad.Interface.Events
{
    public partial interface INotepad : INotepadValues
    {
        event EventHandler NewFormButtonClickedEvent;
        event EventHandler TextBoxTextChangedEvent;
        event EventHandler NewWindowButtonClickedEvent;
        event EventHandler OpenFileButtonClickedEvent;
        event EventHandler SaveButtonClickedEvent;
        event EventHandler SaveAsButtonClickedEvent;
        event EventHandler PageSetupButtonClickedEvent;
        event EventHandler PrintButtonClickedEvent;
        event EventHandler ExitButtonClickedEvent;
    }
}
