namespace Notepad.Model.DialogBox
{
    partial class FindDialogBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ReplaceButton = new System.Windows.Forms.Button();
            this.ReplaceAllButtons = new System.Windows.Forms.Button();
            this.FindTextBox = new System.Windows.Forms.TextBox();
            this.ReplaceTextBox = new System.Windows.Forms.TextBox();
            this.CloseFindButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReplaceButton
            // 
            this.ReplaceButton.Location = new System.Drawing.Point(476, 38);
            this.ReplaceButton.Name = "ReplaceButton";
            this.ReplaceButton.Size = new System.Drawing.Size(75, 23);
            this.ReplaceButton.TabIndex = 0;
            this.ReplaceButton.Text = "Replace";
            this.ReplaceButton.UseVisualStyleBackColor = true;
            // 
            // ReplaceAllButtons
            // 
            this.ReplaceAllButtons.Location = new System.Drawing.Point(566, 38);
            this.ReplaceAllButtons.Name = "ReplaceAllButtons";
            this.ReplaceAllButtons.Size = new System.Drawing.Size(75, 23);
            this.ReplaceAllButtons.TabIndex = 1;
            this.ReplaceAllButtons.Text = "Replace All";
            this.ReplaceAllButtons.UseVisualStyleBackColor = true;
            // 
            // FindTextBox
            // 
            this.FindTextBox.Location = new System.Drawing.Point(12, 12);
            this.FindTextBox.Name = "FindTextBox";
            this.FindTextBox.Size = new System.Drawing.Size(478, 20);
            this.FindTextBox.TabIndex = 2;
            // 
            // ReplaceTextBox
            // 
            this.ReplaceTextBox.Location = new System.Drawing.Point(12, 38);
            this.ReplaceTextBox.Name = "ReplaceTextBox";
            this.ReplaceTextBox.Size = new System.Drawing.Size(458, 20);
            this.ReplaceTextBox.TabIndex = 3;
            // 
            // CloseFindButton
            // 
            this.CloseFindButton.Location = new System.Drawing.Point(610, 9);
            this.CloseFindButton.Name = "CloseFindButton";
            this.CloseFindButton.Size = new System.Drawing.Size(31, 23);
            this.CloseFindButton.TabIndex = 4;
            this.CloseFindButton.Text = "X";
            this.CloseFindButton.UseVisualStyleBackColor = true;
            this.CloseFindButton.Click += new System.EventHandler(this.CloseButtonClicked);
            // 
            // FindDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(649, 64);
            this.ControlBox = false;
            this.Controls.Add(this.CloseFindButton);
            this.Controls.Add(this.ReplaceTextBox);
            this.Controls.Add(this.FindTextBox);
            this.Controls.Add(this.ReplaceAllButtons);
            this.Controls.Add(this.ReplaceButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindDialogBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReplaceButton;
        private System.Windows.Forms.Button ReplaceAllButtons;
        private System.Windows.Forms.TextBox FindTextBox;
        private System.Windows.Forms.TextBox ReplaceTextBox;
        private System.Windows.Forms.Button CloseFindButton;
    }
}