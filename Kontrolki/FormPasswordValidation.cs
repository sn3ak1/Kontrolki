using System.Windows.Forms;

namespace Kontrolki
{
    public partial class FormPasswordValidation : Form
    {
        public FormPasswordValidation()
        {
            InitializeComponent();
            checkedListBox1.Items[0] = $"at least {passwordValidation1.MinChars} characters";

            passwordValidation1.AtLeastCharacters += 
                (o, e) => checkedListBox1.SetItemChecked(0,e.B);
            passwordValidation1.AtLeast1SpecialCharacter += 
                (o, e) => checkedListBox1.SetItemChecked(1, e.B);
            passwordValidation1.AtLeast1CapitalLetter +=
                (o, e) => checkedListBox1.SetItemChecked(2, e.B);
            passwordValidation1.AtLeast1Digit +=
                (o, e) => checkedListBox1.SetItemChecked(3, e.B);
        }
    }
}