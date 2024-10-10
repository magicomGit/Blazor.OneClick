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
                Tertiary = "#fff",
               Dark = "#9396a5",
                AppbarBackground = "#0e1726"
               
            },
            PaletteDark = new PaletteDark()
            {
                Primary = "#897feb",
                Secondary = "#242f3d",
                Tertiary = "#1a1c2d",
                Background = "#060818",
                Surface = "#0e1726",
                Dark = "#060818",
                AppbarBackground = "#060818",
                
            },
           
            //Typography = new Typography()
            //{
               
            //}
        };
    }
}
