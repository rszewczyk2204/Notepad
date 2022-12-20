using System;
using System.Drawing;

namespace Notepad.View.Interface
{
    public interface INotepadView
    {
        string InputText { get; set; }
        string TitleBarText { get; set; }
        int TextBoxSelectionStart { get; set; }
        int TextBoxSelectionLength { get; set; }
        string DefaultText { get; set; }
        Font Font { get; set; }

        event EventHandler NewFormButtonClickedEvent;
        event EventHandler TextBoxTextChangedEvent;
        event EventHandler NewWindowButtonClickedEvent;
        event EventHandler OpenFileButtonClickedEvent;
        event EventHandler SaveButtonClickedEvent;
        event EventHandler SaveAsButtonClickedEvent;
        event EventHandler PageSetupButtonClickedEvent;
        event EventHandler PrintButtonClickedEvent;
        event EventHandler ExitButtonClickedEvent;

        event EventHandler TimeDateButtonClickedEvent;
        event EventHandler FontButtonClickedEvent;
    }
}
