using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.View.Interface
{
    public interface INotepadEdit
    {
        void TimeDateButtonClicked(object sender, EventArgs e);

        void FontButtonClicked(object sender, EventArgs e);
    }
}
