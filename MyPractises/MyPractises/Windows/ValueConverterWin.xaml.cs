﻿using System;
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
using System.Windows.Shapes;

namespace MyPractises.Windows
{
    /// <summary>
    /// Interaction logic for ValueConverterWin.xaml
    /// </summary>
    public partial class ValueConverterWin : Window
    {
        public ValueConverterWin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tbkTestVisible.Visibility = Visibility.Collapsed;
        }
    }
}
