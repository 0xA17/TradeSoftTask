using TradeSoftTask.MVVM.ViewModel.Windows;
using TradeSoftTask.Providers;

namespace TradeSoftTask;

public partial class MainWindow : Window
{
    public static MainWindow Instance { get; private set; }

    public MainWindow()
    {
        InitializeComponent();
        Instance = this;
    }

    private void Window_MouseDown(Object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if(e.LeftButton == System.Windows.Input.MouseButtonState.Pressed) this.DragMove();
    }

    private async void Button_Click(Object sender, RoutedEventArgs e)
    {
        await MainViewModel.ControlStateChangeEvent(sender);
    }

    private void DataGrid_SelectionChanged(Object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        MainViewModel.GridChangeEvent(sender);
    }
}