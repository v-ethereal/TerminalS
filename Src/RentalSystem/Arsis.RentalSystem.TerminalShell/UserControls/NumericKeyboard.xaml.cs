using System.Windows;

namespace Arsis.RentalSystem.TerminalShell.UserControls
{
    /// <summary>
    /// Interaction logic for NumericKeyboard.xaml
    /// </summary>
    public partial class NumericKeyboard
    {
    	private int capacity = 8;
        #region Constructor

        public NumericKeyboard()
        {
            InitializeComponent();
        }



        #endregion

        #region Properties

		/// <summary>
		/// разрядность цифровой клавиатуры
		/// </summary>
    	public int Capacity
    	{
    		get { return capacity; }
    		set { capacity = value; }
    	}

    	/// <summary>
        /// Вовзращает введенное значение
        /// </summary>
        public string Value
        {
            get { return tbxValue.Text; }
        }

        #endregion

        public event KeyPressedEventHandler KeyPressed;

        #region Private Methods

        private void btnNr1_Click(object sender, RoutedEventArgs e)
        {
			if (tbxValue.Text.Length < capacity)
            {
                tbxValue.Text += "1";
            }

            KeyPressedEventHandler eventHandler = KeyPressed;
            if (eventHandler != null)
                eventHandler(sender, new KeyPressedEventArgs());
        }

        private void btnNr2_Click(object sender, RoutedEventArgs e)
        {
			if (tbxValue.Text.Length < capacity)
            {
                tbxValue.Text += "2";
            }

            KeyPressedEventHandler eventHandler = KeyPressed;
            if (eventHandler != null)
                eventHandler(sender, new KeyPressedEventArgs());
        }

        private void btnNr3_Click(object sender, RoutedEventArgs e)
        {
			if (tbxValue.Text.Length < capacity)
            {
                tbxValue.Text += "3";
            }

            KeyPressedEventHandler eventHandler = KeyPressed;
            if (eventHandler != null)
                eventHandler(sender, new KeyPressedEventArgs());
        }

        private void btnNr4_Click(object sender, RoutedEventArgs e)
        {
			if (tbxValue.Text.Length < capacity)
            {
                tbxValue.Text += "4";
            }

            KeyPressedEventHandler eventHandler = KeyPressed;
            if (eventHandler != null)
                eventHandler(sender, new KeyPressedEventArgs());
        }

        private void btnNr5_Click(object sender, RoutedEventArgs e)
        {
			if (tbxValue.Text.Length < capacity)
            {
                tbxValue.Text += "5";
            }

            KeyPressedEventHandler eventHandler = KeyPressed;
            if (eventHandler != null)
                eventHandler(sender, new KeyPressedEventArgs());
        }

        private void btnNr6_Click(object sender, RoutedEventArgs e)
        {
			if (tbxValue.Text.Length < capacity)
            {
                tbxValue.Text += "6";
            }

            KeyPressedEventHandler eventHandler = KeyPressed;
            if (eventHandler != null)
                eventHandler(sender, new KeyPressedEventArgs());
        }

        private void btnNr7_Click(object sender, RoutedEventArgs e)
        {
			if (tbxValue.Text.Length < capacity)
            {
                tbxValue.Text += "7";
            }

            KeyPressedEventHandler eventHandler = KeyPressed;
            if (eventHandler != null)
                eventHandler(sender, new KeyPressedEventArgs());
        }

        private void btnNr8_Click(object sender, RoutedEventArgs e)
        {
			if (tbxValue.Text.Length < capacity)
            {
                tbxValue.Text += "8";
            }

            KeyPressedEventHandler eventHandler = KeyPressed;
            if (eventHandler != null)
                eventHandler(sender, new KeyPressedEventArgs());
        }

        private void btnNr9_Click(object sender, RoutedEventArgs e)
        {
			if (tbxValue.Text.Length < capacity)
            {
                tbxValue.Text += "9";
            }

            KeyPressedEventHandler eventHandler = KeyPressed;
            if (eventHandler != null)
                eventHandler(sender, new KeyPressedEventArgs());
        }

        private void btnNr0_Click(object sender, RoutedEventArgs e)
        {
			if (tbxValue.Text.Length < capacity)
            {
                tbxValue.Text += "0";
            }

            KeyPressedEventHandler eventHandler = KeyPressed;
            if (eventHandler != null)
                eventHandler(sender, new KeyPressedEventArgs());
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbxValue.Clear();

            KeyPressedEventHandler eventHandler = KeyPressed;
            if (eventHandler != null)
                eventHandler(sender, new KeyPressedEventArgs());
        }

        private void btnBackSpace_Click(object sender, RoutedEventArgs e)
        {
            if (tbxValue.Text.Length != 0)
            {
                tbxValue.Text = tbxValue.Text.Remove(tbxValue.Text.Length - 1, 1);
            }

            KeyPressedEventHandler eventHandler = KeyPressed;
            if (eventHandler != null)
                eventHandler(sender, new KeyPressedEventArgs());
        }

        #endregion
    }
}