using System;

namespace Notepad.View.Notepad.Interface.Events
{
    public partial interface INotepadEvents
    {
        event EventHandler UndoButtonClickedEvent;
        event EventHandler CutButtonClickedEvent;
        event EventHandler CopyButtonClickedEvent;
        event EventHandler PasteButtonClickedEvent;
        event EventHandler DeleteButtonClickedEvent;
        event EventHandler FindButtonClickedEvent;
        event EventHandler TimeDateButtonClickedEvent;
        event EventHandler FontButtonClickedEvent;
    }
}
