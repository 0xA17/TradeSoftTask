
using TradeSoftTask.Utilities;

namespace TradeSoftTask.MVVM.Model;

static class ProductWorkModel
{
    public static Boolean IsCurrentProductKey(String productKey, String article, String manufacturer)
    {
        if(String.IsNullOrEmpty(productKey) || String.IsNullOrEmpty(article) || String.IsNullOrEmpty(manufacturer)) return false;

        return productKey.Contains(RegexUtils.NormalizeString(article)) &&
               productKey.Contains(RegexUtils.NormalizeString(manufacturer)) &&
               RegexUtils.IsStringEmpty(productKey, RegexUtils.NormalizeString(article), manufacturer.ToLower());
    }
}