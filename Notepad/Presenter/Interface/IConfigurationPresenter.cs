using System;

namespace Notepad.Presenter.Interface
{
    public interface IConfigurationPresenter
    {
        void NewFormButtonClicked(object sender, EventArgs eventArgs);

        void TextBoxTextChanged(object sender, EventArgs eventArgs);

        void NewWindowButtonClicked(object sender, EventArgs eventArgs);

        void OpenFileButtonClicked(object sender, EventArgs eventArgs);

        void SaveButtonClicked(object sender, EventArgs eventArgs);

        void SaveAsButtonClicked(object sender, EventArgs eventArgs);

        void PageSetupButtonClicked(object sender, EventArgs eventArgs);

        void PrintButtonClicked(object sender, EventArgs eventArgs);

        void ExitButtonClicked(object sender, EventArgs eventArgs);

        void TimeDateButtonClicked(object sender, EventArgs eventArgs);

        void FontButtonClicked(object sender, EventArgs eventArgs);
    }
}
