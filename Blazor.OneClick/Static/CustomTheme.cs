using MudBlazor;

namespace Blazor.OneClick.Static
{
    public static class CustomTheme
    {
        public static MudTheme MyTheme => new()
        {
            PaletteLight = new PaletteLight()
            {
                Primary = "#372ca1",
                Secondary = "#888ea8",
                Tertiary = "#081344"
            },
            PaletteDark = new PaletteDark()
            {
                Primary = "#897feb",
                Secondary = "#242f3d",
                Tertiary = "#17212b",
            },
            //Typography = new Typography()
            //{
               
            //}
        };
    }
}
