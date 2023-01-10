using System;

namespace Notepad.View.Interface.Find
{
    internal interface IFindMethods
    {
        void FindButtonClicked(object sender, EventArgs e);

        void FindPreviousButtonClicked(object sender, EventArgs e);

        void CloseButtonClicked(object sender, EventArgs eventArgs);
    }
}
