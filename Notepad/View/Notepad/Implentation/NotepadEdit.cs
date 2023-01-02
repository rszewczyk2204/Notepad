using Notepad.View.Notepad.Interface.Edit;
using Notepad.View.Notepad.Interface.Events;
using System;

namespace Notepad.View.Notepad.Implentation
{
    public partial class Notepad : INotepadEdit, INotepadEvents
    {
        public event EventHandler UndoButtonClickedEvent;
        public event EventHandler CutButtonClickedEvent;
        public event EventHandler CopyButtonClickedEvent;
        public event EventHandler DeleteButtonClickedEvent;
        public event EventHandler FindButtonClickedEvent;
        public event EventHandler TimeDateButtonClickedEvent;
        public event EventHandler FontButtonClickedEvent;

        public void UndoButtonClicked(object sender, EventArgs e)
        {
            UndoButtonClickedEvent.Invoke(textBox1, e);
        }

        public void CutButtonClicked(object sender, EventArgs e)
        {
            CutButtonClickedEvent.Invoke(textBox1, e);
        }

        public void DeleteButtonClicked(object sender, EventArgs e)
        {
            DeleteButtonClickedEvent.Invoke(textBox1, e);
        }

        public void FindButtonClicked(object sender, EventArgs eventArgs)
        {
            FindButtonClickedEvent.Invoke(this, eventArgs);
        }

        public void TimeDateButtonClicked(object sender, EventArgs eventArgs)
        {
            TimeDateButtonClickedEvent.Invoke(this, eventArgs);
        }

        public void FontButtonClicked(object sender, EventArgs eventArgs)
        {
            FontButtonClickedEvent.Invoke(this, eventArgs);
        }
    }
}
