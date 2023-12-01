using System.Collections.Generic;
using TradeSoftTask.MVVM.View.Windows;
using TradeSoftTask.Providers;
using TradeSoftTask.Utilities;

namespace TradeSoftTask.MVVM.ViewModel.Windows;

class FindConnectionViewModel
{
    private static FindConnectionViewModel? Instance;

    private static Boolean IsProductFound = false;

    private static UInt64 SearchSteps;

    private static Dictionary<String, List<String>> SearchResults { get; set; } = new Dictionary<String, List<String>>();

    public String OriginalProductKey { get; set; } = String.Empty;

    public String ConnectedProductKey { get; set; } = String.Empty;

    public UInt32 RecursionDepth { get; set; } = 5;

    public FindConnectionViewModel()
    {
        Instance = this;
    }

    public static void ControlStateChangeEvent(Object obj)
    {
        if (obj is not FrameworkElement tergetControl) return;

        switch (tergetControl.Tag ?? String.Empty)
        {
            case "CloseWindow":
                FindConnectionWindow.Instance.Close();
                break;
            case "InitSearch":
                FindConnection();
                break;
            default: break;
        }
    }

    private static void FindConnection()
    {
        SearchResults.Clear(); IsProductFound = false; SearchSteps = 0;

        var searchHistory = new List<String>();
        FindConnectionRecursive(
            Instance?.OriginalProductKey ?? String.Empty,
            RegexUtils.NormalizeString(Instance?.ConnectedProductKey ?? String.Empty),
            Instance?.RecursionDepth ?? 0, 
            ref searchHistory);

        if(!IsProductFound)
        {
            Logger.ShowMessage($"Искомый товар {Instance?.OriginalProductKey} не найден за {SearchSteps} шагов!");
            FindConnectionWindow.Instance?.Close();
            return;
        }

        WindowsUtils.ShowOwnerWindows(new RoutesWindow(SearchResults));
    }

    private static void FindConnectionRecursive(String currentKey, String targetKey, UInt32 depth, ref List<String> searchHistory)
    {
        if (depth == 0 || String.IsNullOrEmpty(currentKey) || String.IsNullOrEmpty(targetKey)) return;

        var connections = PostgreSQLProvider.GetProductModelsByKey(RegexUtils.NormalizeString(currentKey)); if (connections is null) return;

        foreach (var connection in connections)
        {
            if (searchHistory is null) searchHistory = new List<String>();

            searchHistory.Add($"{currentKey} -> {connection.Article2}/{connection.Manufacturer2}");

            if (RegexUtils.NormalizeString(connection.Article2 + connection.Manufacturer2) == targetKey)
            {
                IsProductFound = true;
                SearchResults.Add($"Маршрут {SearchResults.Count + 1}", searchHistory);
                searchHistory = null;
                return;
            }

            if (connection.Confidence == 0) continue;

            FindConnectionRecursive(connection.Article2 + connection.Manufacturer2, targetKey, depth - 1, ref searchHistory);
        }

        if (searchHistory.Count > 0) searchHistory.RemoveAt(searchHistory.Count - 1);

        SearchSteps++;
    }
}