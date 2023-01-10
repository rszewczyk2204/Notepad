using System;

namespace Notepad.View.Interface.Find
{
    public interface IFindEvents
    {
        event EventHandler ReplaceButtonClickedEvent;
        event EventHandler ReplaceAllButtonClickedEvent;
        event EventHandler CloseButtonClickedEvent;
    }
}
