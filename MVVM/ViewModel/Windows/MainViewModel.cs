using System.Collections.ObjectModel;
using TradeSoftTask.Providers;
using System.Linq;
using TradeSoftTask.MVVM.Model;
using System.Threading.Tasks;
using TradeSoftTask.Utilities;
using System.Windows.Controls;
using TradeSoftTask.MVVM.View.Windows;

namespace TradeSoftTask.MVVM.ViewModel.Windows;

public class MainViewModel
{
    private static ProductModel? ProductForDelete;

    public static ObservableCollection<ProductModel> ProductModels { get; set; } = new ObservableCollection<ProductModel>();

    public MainViewModel()
    {
        PostgreSQLProvider.GetProducts()?.ForEach(x => ProductModels.Add(x));
    }

    public static void GridChangeEvent(Object obj)
    {
        if (obj is not DataGrid tergetControl) return;

        switch (tergetControl.Tag ?? String.Empty)
        {
            case "ProductModelsDataGrid":
                if(tergetControl.SelectedValue is ProductModel targetProduct)
                {
                    ProductForDelete = targetProduct;
                }
                break;
            default: break;
        }
    }

    public static async Task ControlStateChangeEvent(Object obj)
    {
        if (obj is not FrameworkElement tergetControl) return;

        switch (tergetControl.Tag ?? String.Empty)
        {
            case "InitClose":
                Application.Current.Shutdown();
                break;
            case "InitMinimize":
                MainWindow.Instance.WindowState = WindowState.Minimized;
                break;
            case "AddData":
                ProductModels.Add(new ProductModel());
                break;
            case "DeleteItem":
                await DeleteProduct();
                break;
            case "FindConnection":
                WindowsUtils.ShowOwnerWindows(new FindConnectionWindow());
                MainWindow.Instance.Effect = null;
                break;
            case "SaveData":
                if(!IsProductsValid())
                {
                    Logger.ShowMessage("Не все данные заполнены корректно!");
                    break;
                }
                await PostgreSQLProvider.ActualizeProducts(ProductModels.ToList());
                break;
            default: break;
        }
    }

    private static async Task DeleteProduct()
    {
        await PostgreSQLProvider.DeleteProduct(ProductForDelete);
        ProductModels.Remove(ProductForDelete);
    }

    private static Boolean IsProductsValid()
    {
        foreach (var item in ProductModels)
        {
            if (String.IsNullOrEmpty(item.Article1) ||
                String.IsNullOrEmpty(item.Article2) ||
                String.IsNullOrEmpty(item.Manufacturer1) ||
                String.IsNullOrEmpty(item.Manufacturer2))
            {
                return false;
            }
        }

        return true;
    }
}