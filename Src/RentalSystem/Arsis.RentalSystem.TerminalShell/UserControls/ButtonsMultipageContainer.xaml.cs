using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace Arsis.RentalSystem.TerminalShell.UserControls
{
    /// <summary>
    /// Interaction logic for ButtonsMultipageContainer.xaml
    /// </summary>
    public partial class ButtonsMultipageContainer : UserControl
    {
        private const int buttonsPerPage = 12;
        private int currentPage;
        private readonly List<Button> buttonList;

        public ButtonsMultipageContainer()
        {
            InitializeComponent();
            buttonList = new List<Button>();
        }

        public int TotalPages
        {
            get
            {
                return buttonList.Count / buttonsPerPage + (buttonList.Count % buttonsPerPage > 0 ? 1 : 0);
            }
        }

        public bool IsFirstPage
        {
            get
            {
                return currentPage == 0;
            }
        }

        public bool IsLastPage
        {
            get
            {
                return currentPage == TotalPages - 1;
            }
        }

        public void AddButton(Button button)
        {
            buttonList.Add(button);
        }

        public void Show()
        {
            if (TotalPages > 1)
            {
                btPrev.Visibility = Visibility.Visible;
                btNext.Visibility = Visibility.Visible;
            }
            else
            {
                btPrev.Visibility = Visibility.Hidden;
                btNext.Visibility = Visibility.Hidden;
            }
            btPrev.IsEnabled = (!IsFirstPage);
            btNext.IsEnabled = (!IsLastPage);

            buttonsContainer.Children.Clear();
            for (int i=currentPage * buttonsPerPage; i<(currentPage+1) * buttonsPerPage; i++)
            {
                if (buttonList.Count <= i)
                    break;
                buttonsContainer.Children.Add(buttonList[i]);
            }
        }

        public void Next()
        {
            if (currentPage >= TotalPages - 1)
                return;
            currentPage += 1;
            Show();
        }

        public void Previous()
        {
            if (currentPage <= 0)
                return;
            currentPage -= 1;
            Show();
        }

        private void btPrevious_Click(object sender, RoutedEventArgs e)
        {
            Previous();
        }
        private void btNext_Click(object sender, RoutedEventArgs e)
        {
            Next();
        }


    }
}
