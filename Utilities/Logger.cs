namespace TradeSoftTask.Utilities;

static class Logger
{
    public static void ShowMessage(String message)
    {
        if (String.IsNullOrEmpty(message)) return;

        MessageBox.Show(message);
    }
}