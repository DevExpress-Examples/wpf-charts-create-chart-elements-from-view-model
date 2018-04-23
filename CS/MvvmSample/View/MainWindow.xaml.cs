using MvvmSample.ViewModel;
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

namespace MvvmSample {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
    }

    public class SeriesTypeTemplateSelector: DataTemplateSelector {
        public DataTemplate AreaTemplate { get; set; }
        public DataTemplate BarTemplate { get; set; }
        public DataTemplate LineTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            SeriesViewModel seriesVM = item as SeriesViewModel;
            if(seriesVM == null) return base.SelectTemplate(item, container);

            switch (seriesVM.Type) {
                case SeriesType.Area:   return AreaTemplate;
                case SeriesType.Bar:    return BarTemplate;
                case SeriesType.Line:   return LineTemplate;
                default:                return base.SelectTemplate(item, container);
            }
        }
    }
}
