using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFStack
{
    /// <summary>
    /// Interaction logic for ListBoxQuestions.xaml
    /// </summary>
    public partial class ListBoxQuestions : Window
    {
        public ListBoxQuestions()
        {
          //  InitializeComponent();
        }

private void LbFiles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
{
    var sourceList = lbFiles.ItemsSource
                            .OfType<object>()
                            .ToList();

    var moveLast = sourceList[sourceList.Count - 1];

    sourceList.RemoveAt(sourceList.Count - 1);

    var newList = new List<object>() { moveLast };

    newList.AddRange(sourceList);

    lbFiles.ItemsSource = newList;

//    lbFiles.UpdateLayout();
}
    }


   



}



