﻿using System;

namespace Notepad.View.Notepad.Interface.View
{
    public interface INotepadView
    {
        void StatusBarButtonClicked(object sender, EventArgs e);
        void WordWrapButtonClicked(object sender, EventArgs e);
    }
}
