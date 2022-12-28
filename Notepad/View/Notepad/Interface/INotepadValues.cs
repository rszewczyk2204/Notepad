using System.Drawing;

namespace Notepad.View.Interface
{
    public interface INotepadValues
    {
        string InputText { get; set; }
        string TitleBarText { get; set; }
        int TextBoxSelectionStart { get; set; }
        int TextBoxSelectionLength { get; set; }
        string DefaultText { get; set; }
        Font Font { get; set; }
    }
}
