using System;
using MudBlazor;
using MudBlazor.Utilities;

namespace Dima.Web;

public static class Configuration
{
    public static MudTheme Theme = new ()
    {
        Typography= new Typography
        {
            Default = new DefaultTypography
            {
                
            },
        },
        PaletteLight = new PaletteLight
        {
            Primary = "#1efa2d",
            Secondary = Colors.LightGreen.Darken3,
            Background = Colors.Gray.Lighten4,
            AppbarBackground = new MudColor("#1efa2d"),
            AppbarText = Colors.Shades.Black,
            TextPrimary = Colors.Shades.Black,
            PrimaryContrastText = Colors.Shades.Black,
            DrawerText = Colors.Shades.Black,
            DrawerBackground = Colors.LightGreen.Lighten4,
        },
        PaletteDark = new PaletteDark
        {
            Primary = Colors.LightGreen.Accent3,
            Secondary = Colors.LightGreen.Darken3,
            AppbarBackground = Colors.LightGreen.Accent3,
            AppbarText = Colors.Shades.Black,
        }
    };
}
