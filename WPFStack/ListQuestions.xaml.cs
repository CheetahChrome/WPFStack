using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFStack
{
    /// <summary>
    /// Interaction logic for ListQuestions.xaml
    /// </summary>
    public partial class ListQuestions : Page
    {
        public ListQuestions()
        {
            InitializeComponent();
            DataContext = new MainVm();


        }
    }
}
