using System.Collections.Generic;
using TradeSoftTask.MVVM.ViewModel.Windows;

namespace TradeSoftTask.MVVM.View.Windows;

public partial class RoutesWindow : Window
{
    public static RoutesWindow Instance;
    public RoutesWindow(Dictionary<String, List<String>> searchResults)
    {
        InitializeComponent();
        Instance = this;
        DataContext = new RoutesWindowViewModel(searchResults);
    }

    private void Button_Click(Object sender, RoutedEventArgs e)
    {
        Close();
    }
}
