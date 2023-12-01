using TradeSoftTask.MVVM.ViewModel.Windows;

namespace TradeSoftTask.MVVM.View.Windows;

public partial class FindConnectionWindow : Window
{
    public static FindConnectionWindow Instance { get; private set; }

    public FindConnectionWindow()
    {
        InitializeComponent();
        Instance = this;
    }

    private void Button_Click(Object sender, RoutedEventArgs e)
    {
        FindConnectionViewModel.ControlStateChangeEvent(sender);
    }
}