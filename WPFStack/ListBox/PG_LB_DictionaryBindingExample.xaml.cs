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

namespace WPFStack.ListBox
{
    /// <summary>
    /// Interaction logic for DictionaryBindingExample.xaml
    /// </summary>
    public partial class PG_LB_DictionaryBindingExample : Page
    {
        public PG_LB_DictionaryBindingExample()
        {
            InitializeComponent();
            
        }

        private void ShowIt(object sender, RoutedEventArgs e)
        {
if (lbTheDictionary.SelectedItem != null)
    MessageBox.Show(((KeyValuePair<string, string>) (lbTheDictionary.SelectedItem)).Key);
else
    MessageBox.Show("Select something");
        }

        //private void WhatisSelected(object sender, RoutedEventArgs e)
        //{

        //    if (lbTheDictionary.SelectedItem != null)
        //        MessageBox.Show(((KeyValuePair<string, string>)(lbTheDictionary.SelectedItem)).Key);

        //}
    }
}
