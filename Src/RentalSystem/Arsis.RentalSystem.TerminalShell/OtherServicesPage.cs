using System.Collections.Generic;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;
using Arsis.RentalSystem.TerminalShell.BLL;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;
using Arsis.RentalSystem.TerminalShell.BLL.Services;

using System.IO;

using Arsis.RentalSystem.TerminalShell.Configuration;

using Image = System.Windows.Controls.Image;

namespace Arsis.RentalSystem.TerminalShell
{
    /// <summary>
    /// Interaction logic for OtherServicesPage.xaml
    /// </summary>
    public partial class OtherServicesPage
    {
        public OtherServicesPage()
        {
            InitializeComponent();

			var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			TerminalConfiguration currentTerminalConfig = configuration.GetSection("terminal.configuration") as TerminalConfiguration;

			if (currentTerminalConfig != null)
			{
				if (!currentTerminalConfig.RentalServiceEnable && currentTerminalConfig.OtherServiceEnable && !currentTerminalConfig.ParkingServiceEnable)
				{
					btnBack.Visibility = Visibility.Hidden;
				}
			}

            ServicesService servicesService = new ServicesService();
            IList<Service> services = servicesService.GetServices();

            foreach (Service service in services)
            {
                Button button = new Button { Tag = service.Id };
                button.Style = (Style)FindResource("ServiceButtonStyle");
                StackPanel panel = new StackPanel
                                       {
                                           Orientation = Orientation.Horizontal,
                                           HorizontalAlignment = HorizontalAlignment.Left,
                                           VerticalAlignment = VerticalAlignment.Center
                                       };

                Image image = new Image
                {
                    Width = 0,
                    Margin = new Thickness(5,0,5,0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.None
                };

                TextBlock textBlock = new TextBlock
                {
                    //Margin = new Thickness(0, 0, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextWrapping = TextWrapping.Wrap,
                    Text = service.Name
                };

                BitmapImage bitmapImage = new BitmapImage();
                if (service.Picture != null)
                {
                    using (MemoryStream memStream = new MemoryStream(service.Picture))
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.DecodePixelWidth = 128;
                        bitmapImage.DecodePixelHeight = 128;
                        bitmapImage.StreamSource = memStream;
                        bitmapImage.EndInit();
                        bitmapImage.Freeze();

                        //FormattedText text = new FormattedText(service.Name.Replace(" ", Environment.NewLine),
                        //CultureInfo.GetCultureInfo("ru-ru"),
                        //FlowDirection.LeftToRight,
                        //new Typeface(FontFamily, FontStyles.Normal, FontWeights.Normal, new FontStretch()),
                        //32,
                        //Brushes.Blue);
                        //text.TextAlignment=TextAlignment.Center;

                        //DrawingVisual drawingVisual = new DrawingVisual();
                        //DrawingContext drawingContext = drawingVisual.RenderOpen();
                        //drawingContext.DrawImage(bitmapImage, new Rect(0, 0, bitmapImage.DecodePixelWidth, bitmapImage.DecodePixelHeight));
                        //drawingContext.DrawText(text, new Point(bitmapImage.DecodePixelWidth / 2.0, bitmapImage.DecodePixelHeight / 5.0));
                        //drawingContext.Close();

                        //RenderTargetBitmap rtb = new RenderTargetBitmap(bitmapImage.DecodePixelWidth, bitmapImage.DecodePixelHeight, 96, 96, PixelFormats.Pbgra32);
                        //rtb.Render(drawingVisual);
                        //BitmapFrame frame = BitmapFrame.Create(rtb);

                        //ImageSourceConverter isc = new ImageSourceConverter();
                        //BitmapSource bs = (BitmapSource)isc.ConvertFrom(null, null, service.Picture);
                        //imgImage.Source = bs;}
                        image.Source = bitmapImage;
                        image.Width = bitmapImage.Width;
                        image.Height = bitmapImage.Height;
                        if (image.Width > 128)
                            image.Width = 128;
                        if (image.Height > 128)
                            image.Height = 128;
                        panel.Children.Add(image);
                    }
                }
                textBlock.Width = button.Width - image.Width - image.Margin.Left - image.Margin.Right
                    - textBlock.Margin.Left - textBlock.Margin.Right 
                    - textBlock.Padding.Left - textBlock.Padding.Right
                    - button.Padding.Left - button.Padding.Right 
                    - button.Margin.Left - button.Margin.Right
                    - button.BorderThickness.Left - button.BorderThickness.Right;
                panel.Children.Add(textBlock);
                button.Content = panel;
                button.Click += ButtonOnClick;
                workPanel.AddButton(button);
            }
            workPanel.Show();
        }

        private void ButtonOnClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Application.Current.Properties[Constants.ParameterServiceId] = ((Button)sender).Tag;
                Application.Current.Properties[Constants.ParameterServicePlaceNumber] = null; //сбросим номер места

                bool usePlaceNumber = false;
                if (Application.Current.Properties[Constants.ParameterServiceId] is int)
                {
                    IServicesService servicesService = AppRuntime.Instance.Container.GetComponent<IServicesService>();
                    ServiceInformation serviceInformation = servicesService.GetServiceInformation((int)Application.Current.Properties[Constants.ParameterServiceId]);
                    if (serviceInformation != null)
                    {
                        usePlaceNumber = serviceInformation.UsePlaceNumber;
                    }
                }

                NavigationService navigationService = NavigationService.GetNavigationService(this);
                if (navigationService != null)
                {
                    navigationService.Navigate(usePlaceNumber
                                                   ? Constants.UriOtherServicePlaceSelectPage
                                                   : Constants.UriOtherServicePayPage);
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(Constants.UriMainPage);
            }
        }
    }
}
