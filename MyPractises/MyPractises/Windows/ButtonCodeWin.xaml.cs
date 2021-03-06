﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
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
    /// Interaction logic for ButtonCodeWin.xaml
    /// </summary>
    public partial class ButtonCodeWin : Window
    {
        public ButtonCodeWin()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("button1");

        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("button2");
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            ButtonAutomationPeer peer =
  new ButtonAutomationPeer(btn1);

            IInvokeProvider invokeProv =
              peer.GetPattern(PatternInterface.Invoke)
              as IInvokeProvider;

            invokeProv.Invoke();
        }
    }
}
