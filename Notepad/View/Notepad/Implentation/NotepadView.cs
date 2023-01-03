using Notepad.View.Notepad.Interface.Events;
using Notepad.View.Notepad.Interface.View;
using System;

namespace Notepad.View.Notepad.Implentation
{
    public partial class Notepad : INotepadView, INotepadEvents
    {
        public event EventHandler StatusBarButtonClickedEvent;
        public event EventHandler WordWrapButtonClickedEvent;

        public void StatusBarButtonClicked(object sender, EventArgs e)
        {
            StatusBarButtonClickedEvent.Invoke(this.tableLayoutPanel1, e);
            if(tableLayoutPanel1.Visible)
            {
                this.statusBaToolStripMenuItem.Checked = true;
            }
            else
            {
                this.statusBaToolStripMenuItem.Checked = false;
            }
        }

        public void WordWrapButtonClicked(object sender, EventArgs e)
        {
            WordWrapButtonClickedEvent.Invoke(this.textBox1, e);
            if (textBox1.WordWrap)
            {
                this.wordWrapToolStripMenuItem.Checked = true;
            }
            else
            {
                this.wordWrapToolStripMenuItem.Checked = false;
            }
        }
    }
}
