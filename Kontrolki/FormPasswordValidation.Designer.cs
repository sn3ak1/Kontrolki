namespace Kontrolki
{
    partial class FormPasswordValidation
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
            this.passwordValidation1 = new Kontrolki.PasswordValidator();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // passwordValidation1
            // 
            this.passwordValidation1.Location = new System.Drawing.Point(41, 25);
            this.passwordValidation1.MinChars = 8;
            this.passwordValidation1.Name = "passwordValidation1";
            this.passwordValidation1.Size = new System.Drawing.Size(150, 38);
            this.passwordValidation1.SpecialCharacters = new char[] {'.', ',', '!', '@', '#', '$'};
            this.passwordValidation1.TabIndex = 0;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {"at lest characters", "at least one special character", "at least one capital letter", "at least one digit"});
            this.checkedListBox1.Location = new System.Drawing.Point(41, 95);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(174, 79);
            this.checkedListBox1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 189);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.passwordValidation1);
            this.Name = "FormPasswordValidation";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.CheckedListBox checkedListBox1;

        private Kontrolki.PasswordValidator passwordValidation1;

        #endregion
    }
}