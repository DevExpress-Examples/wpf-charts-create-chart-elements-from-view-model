<!-- default file list -->
*Files to look at*:

* [WeatherInfo.cs](./CS/MvvmSample/Model/WeatherInfo.cs) (VB: [WeatherInfo.vb](./VB/MvvmSample/Model/WeatherInfo.vb))
* **[MainWindow.xaml](./CS/MvvmSample/View/MainWindow.xaml) (VB: [MainWindow.xaml.vb](./VB/MvvmSample/View/MainWindow.xaml.vb))**
* [MainWindow.xaml.cs](./CS/MvvmSample/View/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MvvmSample/View/MainWindow.xaml.vb))
* [ChartViewModel.cs](./CS/MvvmSample/ViewModel/ChartViewModel.cs) (VB: [ChartViewModel.vb](./VB/MvvmSample/ViewModel/ChartViewModel.vb))
* [MainViewModel.cs](./CS/MvvmSample/ViewModel/MainViewModel.cs) (VB: [MainViewModel.vb](./VB/MvvmSample/ViewModel/MainViewModel.vb))
<!-- default file list end -->
# How to bind a chart to its ViewModel


To generate a chart element collection from a chart's View Model, bind the element's <strong>ItemsSource  </strong>to the View Model's property. Then specify the element's <strong>ItemTemplate</strong> or <strong>ItemTemplateSelector</strong> to bind the element's properties to the element view model's properties. For example, to bind a chart's legend collection, use <strong>LegendItemsSource </strong>and to configure generated legend, use <strong>LegendItemTemplate.</strong>

<br/>


