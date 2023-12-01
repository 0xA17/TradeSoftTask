using System.Collections.Generic;

namespace TradeSoftTask.MVVM.Model;

public class ProductModel
{
    public Int32 Id { get; set; }
    public String Article1 { get; set; }
    public String Manufacturer1 { get; set; }
    public String Article2 { get; set; }
    public String Manufacturer2 { get; set; }
    public Int32 Confidence { get; set; }
}