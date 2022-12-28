using Notepad.View.Notepad.Interface.Events;
using Notepad.View.Notepad.Interface.File;
using System;

namespace Notepad.View.Notepad.Implentation
{
    public partial class Notepad : INotepad, INotepadFile
    {
        public event EventHandler NewFormButtonClickedEvent;
        public event EventHandler TextBoxTextChangedEvent;
        public event EventHandler NewWindowButtonClickedEvent;
        public event EventHandler OpenFileButtonClickedEvent;
        public event EventHandler SaveButtonClickedEvent;
        public event EventHandler SaveAsButtonClickedEvent;
        public event EventHandler PageSetupButtonClickedEvent;
        public event EventHandler PrintButtonClickedEvent;
        public event EventHandler ExitButtonClickedEvent;

        public void TextBoxTextChanged(object sender, EventArgs e)
        {
            TextBoxTextChangedEvent.Invoke(this, e);
        }

        public void NewFormButtonClicked(object sender, EventArgs eventArgs)
        {
            NewFormButtonClickedEvent.Invoke(this, eventArgs);
        }

        public void NewWindowButtonClicked(object sender, EventArgs eventArgs)
        {
            NewWindowButtonClickedEvent.Invoke(this, eventArgs);
        }

        public void OpenFileButtonClicked(object sender, EventArgs eventArgs)
        {
            OpenFileButtonClickedEvent.Invoke(this, eventArgs);
        }

        public void SaveButtonClicked(object sender, EventArgs eventArgs)
        {
            SaveButtonClickedEvent.Invoke(this, eventArgs);
        }

        public void SaveAsButtonClicked(object sender, EventArgs eventArgs)
        {
            SaveAsButtonClickedEvent.Invoke(this, eventArgs);
        }

        public void PageSetupButtonClicked(object sender, EventArgs eventArgs)
        {
            PageSetupButtonClickedEvent.Invoke(this, eventArgs);
        }

        public void PrintButtonClicked(object sender, EventArgs eventArgs)
        {
            PrintButtonClickedEvent.Invoke(this, eventArgs);
        }

        public void ExitButtonClicked(object sender, EventArgs eventArgs)
        {
            ExitButtonClickedEvent.Invoke(this, eventArgs);
        }
    }
}
