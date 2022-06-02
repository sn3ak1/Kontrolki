using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Kontrolki
{
    public partial class PasswordValidator : UserControl
    {
        public int MinChars { get; set; }
        public char[] SpecialCharacters { get; set; }

        public event EventHandler<BoolEventArgs> AtLeastCharacters;
        public event EventHandler<BoolEventArgs> AtLeast1SpecialCharacter;
        public event EventHandler<BoolEventArgs> AtLeast1CapitalLetter;
        public event EventHandler<BoolEventArgs> AtLeast1Digit;
        
        public PasswordValidator()
        {
            InitializeComponent();
            textBox1.PasswordChar = '*';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AtLeastCharacters?.Invoke(this, new BoolEventArgs(textBox1.Text.Length>=MinChars));
            AtLeast1SpecialCharacter?.Invoke(this, 
                new BoolEventArgs(SpecialCharacters.Any(x=>textBox1.Text.Contains(x))));
            AtLeast1CapitalLetter?.Invoke(this, new BoolEventArgs(textBox1.Text.Any(char.IsUpper)));
            AtLeast1Digit?.Invoke(this, new BoolEventArgs(textBox1.Text.Any(char.IsDigit)));
        }
    }
    
    public class BoolEventArgs : EventArgs
    {
        public BoolEventArgs(bool b)
        {
            B = b;
        }

        public bool B { get; }
    }
}