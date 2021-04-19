using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFStack
{
    /// <summary>
    /// Interaction logic for SlideInWindow.xaml
    /// </summary>
    public partial class SlideInWindow : Window
    {

        public MainVm ViewModel { get; set; }
        public SlideInWindow()
        {
            InitializeComponent();

            if (!DesignerProperties.GetIsInDesignMode(this))
                DataContext = ViewModel = new MainVm();

        }

        private void DoCustomerDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (ViewModel.SelectedPassage == null)
                return;

            ThicknessAnimation slideIn = new ThicknessAnimation();
            slideIn.From = new Thickness(this.ActualWidth, 10, 10, 10);
            slideIn.To = new Thickness(100, 10, 10, 10);
            slideIn.Duration = new Duration(TimeSpan.FromSeconds(.8));
            Storyboard.SetTargetName(slideIn, custDetailSection.Name);
            Storyboard.SetTargetProperty(slideIn, new PropertyPath(Border.MarginProperty));

            custDetailSection.Margin = slideIn.From.Value;
            custDetailSection.Visibility = System.Windows.Visibility.Visible;

            Storyboard sb = new Storyboard();
            sb.Completed += (o, ar) =>
            {
                imageToRight.Opacity = 1.0;
            };
            sb.Children.Add(slideIn);
            sb.Begin(this);


        }

        private void DoHideCustDetail(object sender, RoutedEventArgs e)
        {
            ThicknessAnimation slideIn = new ThicknessAnimation();
            slideIn.From = new Thickness(100, 10, 10, 10);
            slideIn.To = new Thickness(this.ActualWidth, 10, 10, 10);
            slideIn.Duration = new Duration(TimeSpan.FromSeconds(.5));
            Storyboard.SetTargetName(slideIn, custDetailSection.Name);
            Storyboard.SetTargetProperty(slideIn, new PropertyPath(Border.MarginProperty));

            custDetailSection.Margin = slideIn.From.Value;

            Storyboard sb = new Storyboard();
            sb.Children.Add(slideIn);
            imageToRight.Opacity = .5;
            sb.Completed += (o, ar) =>
            {
                imageToRight.Opacity = .1; 
                custDetailSection.Visibility = Visibility.Collapsed;
            };
            sb.Begin(this);
        }
    }
}
