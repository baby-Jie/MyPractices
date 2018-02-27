using MyPractises.Windows;
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

namespace MyPractises
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDonet_Click(object sender, RoutedEventArgs e)
        {
            DotNetWin win = new DotNetWin();
            win.ShowDialog();
        }

        private void btnBehavior_Click(object sender, RoutedEventArgs e)
        {
            InteractionsTestWin win = new InteractionsTestWin();
            win.ShowDialog();
        }

        private void btnCrudInXml_Click(object sender, RoutedEventArgs e)
        {
            XmlCRUDWin  win = new XmlCRUDWin();
            win.ShowDialog();
        }

        private void btnSelector_Click(object sender, RoutedEventArgs e)
        {
            StyleAndDatatemplateSelectorWin win = new StyleAndDatatemplateSelectorWin();
            win.ShowDialog();
        }

        private void btnShape_Click(object sender, RoutedEventArgs e)
        {
            ShapeWindow win = new ShapeWindow();
            win.ShowDialog();
        }

        private void btnAccessKey_Click(object sender, RoutedEventArgs e)
        {
            AccessKeyWin win = new AccessKeyWin();
            win.ShowDialog(); 
        }

        private void btnScrollBarTemp_Click(object sender, RoutedEventArgs e)
        {
            ScrollBarTempWin win = new ScrollBarTempWin();
              win.ShowDialog();
        }

        private void btnValueConverter_Click(object sender, RoutedEventArgs e)
        {
            ValueConverterWin win = new ValueConverterWin();
            win.ShowDialog();
        }

        private void btnValidationRules_Click(object sender, RoutedEventArgs e)
        {
            ValidationRulesWin win = new ValidationRulesWin();
            win.ShowDialog();
        }

        private void btnImproveListPerformance_Click(object sender, RoutedEventArgs e)
        {
            ImprovePerformanceOfItemsControlWin win = new ImprovePerformanceOfItemsControlWin();
            win.ShowDialog();
        }

        private void btnAlternationItemStyle_Click(object sender, RoutedEventArgs e)
        {
            ListBoxAlternationWin win = new ListBoxAlternationWin();
            win.ShowDialog();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            ViewWin win = new ViewWin();
            win.ShowDialog();
        }

        private void btnEventBindCommand_Click(object sender, RoutedEventArgs e)
        {
            EventBindingCommandWin win = new EventBindingCommandWin();
            win.ShowDialog();
        }

        private void btnListBoxBinding_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItemBindingByConverter win = new ListBoxItemBindingByConverter();
            win.ShowDialog();
        }

        private void btnZoomImage_Click(object sender, RoutedEventArgs e)
        {
            ImageZoomWin win = new ImageZoomWin();
            win.ShowDialog();
        }

        private void btnWpf_Click(object sender, RoutedEventArgs e)
        {
            WpfWin win = new WpfWin();
            win.ShowDialog();
        }

        private void btnTemplatedBinding_Click(object sender, RoutedEventArgs e)
        {
            TemplateBindingWin win = new TemplateBindingWin();
            win.ShowDialog();
        }

        private void btnToolTips_Click(object sender, RoutedEventArgs e)
        {
            ToolTipWin win = new ToolTipWin();
            win.ShowDialog();
        }

        private void btnMini_Shutdown_Click(object sender, RoutedEventArgs e)
        {
            MiniAndShutdownWin win = new MiniAndShutdownWin();
            win.ShowDialog();
        }

        private void btnCodeButton_Click(object sender, RoutedEventArgs e)
        {
            ButtonCodeWin win = new ButtonCodeWin();
            win.ShowDialog();
        }

        private void btnSetValue_Click(object sender, RoutedEventArgs e)
        {
            DependencyPropertySetValueWin win = new DependencyPropertySetValueWin();
            win.ShowDialog();
        }

        private void btnDatePicker_Click(object sender, RoutedEventArgs e)
        {
            DatePickerWin win = new DatePickerWin();
            win.ShowDialog();
        }

        private void btnCatchImage_Click(object sender, RoutedEventArgs e)
        {
            CatchImageWin win = new CatchImageWin();
            win.ShowDialog();
        }
    }
}
