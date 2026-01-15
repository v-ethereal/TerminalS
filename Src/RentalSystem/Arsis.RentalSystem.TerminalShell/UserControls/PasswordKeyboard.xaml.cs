using System.Windows;
using System.Windows.Controls;

namespace Arsis.RentalSystem.TerminalShell.UserControls
{
    /// <summary>
    /// Interaction logic for PasswordKeyboard.xaml
    /// </summary>
    public partial class PasswordKeyboard
    {
        private bool isCapital;

        public string Value
        {
            get { return pbxValue.Password; }
        }

        public PasswordKeyboard()
        {
            InitializeComponent();
        }

        public event KeyPressedEventHandler KeyPressed;

        private void btnSpace_Click(object sender, RoutedEventArgs e)
        {
            if (pbxValue.Password.Length < 20)
            {
                pbxValue.Password += " ";
            }

            KeyPressedEventHandler eventHandler = KeyPressed;
            if (eventHandler != null)
                eventHandler(sender, new KeyPressedEventArgs());
        }

        private void btnShift_Click(object sender, RoutedEventArgs e)
        {
            isCapital = !isCapital;
            RefreshKeyboard();

            KeyPressedEventHandler eventHandler = KeyPressed;
            if (eventHandler != null)
                eventHandler(sender, new KeyPressedEventArgs());
        }

        private void RefreshKeyboard()
        {
            if (isCapital)
            {
                btnr1c0.Content = "Q";
                btnr1c1.Content = "W";
                btnr1c2.Content = "E";
                btnr1c3.Content = "R";
                btnr1c4.Content = "T";
                btnr1c5.Content = "Y";
                btnr1c6.Content = "U";
                btnr1c7.Content = "I";
                btnr1c8.Content = "O";
                btnr1c9.Content = "P";

                btnr2c0.Content = "A";
                btnr2c1.Content = "S";
                btnr2c2.Content = "D";
                btnr2c3.Content = "F";
                btnr2c4.Content = "G";
                btnr2c5.Content = "H";
                btnr2c6.Content = "J";
                btnr2c7.Content = "K";
                btnr2c8.Content = "L";

                btnr3c0.Content = "Z";
                btnr3c1.Content = "X";
                btnr3c2.Content = "C";
                btnr3c3.Content = "V";
                btnr3c4.Content = "B";
                btnr3c5.Content = "N";
                btnr3c6.Content = "M";

            }
            else
            {
                btnr1c0.Content = "q";
                btnr1c1.Content = "w";
                btnr1c2.Content = "e";
                btnr1c3.Content = "r";
                btnr1c4.Content = "t";
                btnr1c5.Content = "y";
                btnr1c6.Content = "u";
                btnr1c7.Content = "i";
                btnr1c8.Content = "o";
                btnr1c9.Content = "p";

                btnr2c0.Content = "a";
                btnr2c1.Content = "s";
                btnr2c2.Content = "d";
                btnr2c3.Content = "f";
                btnr2c4.Content = "g";
                btnr2c5.Content = "h";
                btnr2c6.Content = "j";
                btnr2c7.Content = "k";
                btnr2c8.Content = "l";

                btnr3c0.Content = "z";
                btnr3c1.Content = "x";
                btnr3c2.Content = "c";
                btnr3c3.Content = "v";
                btnr3c4.Content = "b";
                btnr3c5.Content = "n";
                btnr3c6.Content = "m";
            }
        }

        private void ClickHandler(object sender, RoutedEventArgs e)
        {
            if (pbxValue.Password.Length < 20)
            {
                pbxValue.Password += ((Button)sender).Content;
            }

            KeyPressedEventHandler eventHandler = KeyPressed;
            if (eventHandler != null)
                eventHandler(sender, new KeyPressedEventArgs());
        }

        private void btnbsp_Click(object sender, RoutedEventArgs e)
        {
            if (pbxValue.Password.Length != 0)
            {
                pbxValue.Password = pbxValue.Password.Remove(pbxValue.Password.Length - 1, 1);
            }

            KeyPressedEventHandler eventHandler = KeyPressed;
            if (eventHandler != null)
                eventHandler(sender, new KeyPressedEventArgs());
        }
    }
}

