using System.Drawing;

namespace ZaylandShop.ProductCatalog.Utils.Extensions;

public static class ColorExtension
{
    public static string ConvertToHex(this Color color)
    {
        return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
    }
    
    public static string ConvertToRGB(this Color color)
    {
        return "RGB(" + color.R + "," +color.G + "," + color.B + ")";
    }
}