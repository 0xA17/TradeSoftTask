using System.Windows.Media.Effects;

namespace TradeSoftTask.Utilities;

static class WindowsUtils
{
    public static Boolean ShowOwnerWindows(Window childWindow)
    {
        return ShowOwnerWindows(MainWindow.Instance, childWindow);
    }

    public static Boolean ShowOwnerWindows(Window ownerWindow, Window childWindow)
    {
        if (childWindow is null || ownerWindow is null) return false;

        childWindow.Owner = ownerWindow;
        childWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        AddBlurEffectForWindow(ownerWindow);
        childWindow.ShowDialog();

        return true;
    }

    public static void AddBlurEffectForWindow(Window win)
    {
        if (win is null) return;

        var blurEffect = new BlurEffect();

        blurEffect.Radius = 8;
        win.Effect = blurEffect;
    }
}