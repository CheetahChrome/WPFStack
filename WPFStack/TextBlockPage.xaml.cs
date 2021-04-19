using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFStack
{
    /// <summary>
    /// Interaction logic for TextBlockPage.xaml
    /// </summary>
    public partial class TextBlockPage : Page
    {
        public TextBlockPage()
        {
            InitializeComponent();

            var txt = "Alpha Beta Gamma";
            var target = "Beta";

            var listOfruns = Regex.Split(txt, target)
                                  .Select( words => new Run() { Text = words })
                                  .Aggregate(new List<Run>(), (runs, run) =>
                                  {
                                      runs.Add(run);
                                      runs.Add(new Run() { Foreground = Brushes.Blue, Text = target });
                                      return runs;
                                  }) ;


            tbResult.Inlines.AddRange(listOfruns);

            DataContext = new MainVm();


        }
    }
}
