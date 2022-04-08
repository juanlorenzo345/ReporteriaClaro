#region Header
//  ---------------------------------------------------------------------------------------------------
// |                                                                                                   |
// |             __                         __               __       ______ __     _  __              |
// |            / /   ____   ____ _ __  __ / /_ ___   _____ / /_     / ____// /_   (_)/ /___           |
// |           / /   / __ \ / __ `// / / // __// _ \ / ___// __ \   / /    / __ \ / // // _ \          |
// |          / /___/ /_/ // /_/ // /_/ // /_ /  __// /__ / / / /  / /___ / / / // // //  __/          |
// |         /_____/\____/ \__, / \__, / \__/ \___/ \___//_/ /_/   \____//_/ /_//_//_/ \___/           |
// |                      /____/ /____/                                                                |
// |                                                                                                   |
//  ---------------------------------------------------------------------------------------------------
// 
// Usuario: cristian.ulloa
// Solución/Proyecto: ReporteriaMovistar / ReporteriaMovistar.Clients.BlazorServerSide
// Info archivo:
//     Nombre: MudBlazorThemeConfiguration.cs
//     Fecha creación: 2021/10/25 at 09:17 AM
//     Fecha modificación: 2021/10/25 at 09:17 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using MudBlazor;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Configuration
{
	public class MudBlazorThemeConfiguration : MudTheme
	{
		#region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="MudBlazorThemeConfiguration"/>.
		/// </summary>
		public MudBlazorThemeConfiguration()
		{
			base.Palette = new Palette()
			{
				Black = "#000000FF",
				White = "#FFFFFFFF",
				Primary = "#0593E1FF",
				PrimaryContrastText = "#FFFFFFFF",
				Secondary = "#FF4081FF",
				SecondaryContrastText = "#FFFFFFFF",
				Tertiary = "#1EC8A5FF",
				TertiaryContrastText = "#FFFFFFFF",
				Info = "#2196F3FF",
				InfoContrastText = "#FFFFFFFF",
				Success = "#00C853FF",
				SuccessContrastText = "#FFFFFFFF",
				Warning = "#FF9800FF",
				WarningContrastText = "#FFFFFFFF",
				Error = "#F44336FF",
				ErrorContrastText = "#FFFFFFFF",
				Dark = "#424242FF",
				DarkContrastText = "#FFFFFFFF",
				TextPrimary = "#000000FF",
				TextSecondary = "#00000089",
				TextDisabled = "#00000060",
				ActionDefault = "#00000089",
				ActionDisabled = "#00000042",
				ActionDisabledBackground = "#0000001E",
				Background = "#FFFFFFFF",
				BackgroundGrey = "#F5F5F5FF",
				Surface = "#FFFFFFFF",
				DrawerBackground = "#0593E1FF",
				DrawerText = "#FFFFFFFF",
				DrawerIcon = "#616161FF",
				AppbarBackground = "#0593E1FF",
				AppbarText = "#FFFFFFFF",
				LinesDefault = "#0000001E",
				LinesInputs = "#BDBDBDFF",
				TableLines = "#E0E0E0FF",
				TableStriped = "#00000005",
				TableHover = "#0000000A",
				Divider = "#E0E0E0FF",
				DividerLight = "#000000CC",
				PrimaryDarken = "rgb(62,44,221)",
				PrimaryLighten = "rgb(118,106,231)",
				SecondaryDarken = "rgb(255,31,105)",
				SecondaryLighten = "rgb(255,102,153)",
				TertiaryDarken = "rgb(25,169,140)",
				TertiaryLighten = "rgb(42,223,187)",
				InfoDarken = "rgb(12,128,223)",
				InfoLighten = "rgb(71,167,245)",
				SuccessDarken = "rgb(0,163,68)",
				SuccessLighten = "rgb(0,235,98)",
				WarningDarken = "rgb(214,129,0)",
				WarningLighten = "rgb(255,167,36)",
				ErrorDarken = "rgb(242,28,13)",
				ErrorLighten = "rgb(246,96,85)",
				DarkDarken = "rgb(46,46,46)",
				DarkLighten = "rgb(87,87,87)",
				HoverOpacity = 0.06D,
				GrayDefault = "#9E9E9E",
				GrayLight = "#BDBDBD",
				GrayLighter = "#E0E0E0",
				GrayDark = "#757575",
				GrayDarker = "#616161",
				OverlayDark = "rgba(33,33,33,0.4980392156862745)",
				OverlayLight = "rgba(255,255,255,0.4980392156862745)"
			};

			base.Shadows = new Shadow()
			{
				Elevation = new string[]
				{
					"none",
					"0px 2px 1px -1px rgba(0,0,0,0.2),0px 1px 1px 0px rgba(0,0,0,0.14),0px 1px 3px 0px rgba(0,0,0,0.12)",
					"0px 3px 1px -2px rgba(0,0,0,0.2),0px 2px 2px 0px rgba(0,0,0,0.14),0px 1px 5px 0px rgba(0,0,0,0.12)",
					"0px 3px 3px -2px rgba(0,0,0,0.2),0px 3px 4px 0px rgba(0,0,0,0.14),0px 1px 8px 0px rgba(0,0,0,0.12)",
					"0px 2px 4px -1px rgba(0,0,0,0.2),0px 4px 5px 0px rgba(0,0,0,0.14),0px 1px 10px 0px rgba(0,0,0,0.12)",
					"0px 3px 5px -1px rgba(0,0,0,0.2),0px 5px 8px 0px rgba(0,0,0,0.14),0px 1px 14px 0px rgba(0,0,0,0.12)",
					"0px 3px 5px -1px rgba(0,0,0,0.2),0px 6px 10px 0px rgba(0,0,0,0.14),0px 1px 18px 0px rgba(0,0,0,0.12)",
					"0px 4px 5px -2px rgba(0,0,0,0.2),0px 7px 10px 1px rgba(0,0,0,0.14),0px 2px 16px 1px rgba(0,0,0,0.12)",
					"0px 5px 5px -3px rgba(0,0,0,0.2),0px 8px 10px 1px rgba(0,0,0,0.14),0px 3px 14px 2px rgba(0,0,0,0.12)",
					"0px 5px 6px -3px rgba(0,0,0,0.2),0px 9px 12px 1px rgba(0,0,0,0.14),0px 3px 16px 2px rgba(0,0,0,0.12)",
					"0px 6px 6px -3px rgba(0,0,0,0.2),0px 10px 14px 1px rgba(0,0,0,0.14),0px 4px 18px 3px rgba(0,0,0,0.12)",
					"0px 6px 7px -4px rgba(0,0,0,0.2),0px 11px 15px 1px rgba(0,0,0,0.14),0px 4px 20px 3px rgba(0,0,0,0.12)",
					"0px 7px 8px -4px rgba(0,0,0,0.2),0px 12px 17px 2px rgba(0,0,0,0.14),0px 5px 22px 4px rgba(0,0,0,0.12)",
					"0px 7px 8px -4px rgba(0,0,0,0.2),0px 13px 19px 2px rgba(0,0,0,0.14),0px 5px 24px 4px rgba(0,0,0,0.12)",
					"0px 7px 9px -4px rgba(0,0,0,0.2),0px 14px 21px 2px rgba(0,0,0,0.14),0px 5px 26px 4px rgba(0,0,0,0.12)",
					"0px 8px 9px -5px rgba(0,0,0,0.2),0px 15px 22px 2px rgba(0,0,0,0.14),0px 6px 28px 5px rgba(0,0,0,0.12)",
					"0px 8px 10px -5px rgba(0,0,0,0.2),0px 16px 24px 2px rgba(0,0,0,0.14),0px 6px 30px 5px rgba(0,0,0,0.12)",
					"0px 8px 11px -5px rgba(0,0,0,0.2),0px 17px 26px 2px rgba(0,0,0,0.14),0px 6px 32px 5px rgba(0,0,0,0.12)",
					"0px 9px 11px -5px rgba(0,0,0,0.2),0px 18px 28px 2px rgba(0,0,0,0.14),0px 7px 34px 6px rgba(0,0,0,0.12)",
					"0px 9px 12px -6px rgba(0,0,0,0.2),0px 19px 29px 2px rgba(0,0,0,0.14),0px 7px 36px 6px rgba(0,0,0,0.12)",
					"0px 10px 13px -6px rgba(0,0,0,0.2),0px 20px 31px 3px rgba(0,0,0,0.14),0px 8px 38px 7px rgba(0,0,0,0.12)",
					"0px 10px 13px -6px rgba(0,0,0,0.2),0px 21px 33px 3px rgba(0,0,0,0.14),0px 8px 40px 7px rgba(0,0,0,0.12)",
					"0px 10px 14px -6px rgba(0,0,0,0.2),0px 22px 35px 3px rgba(0,0,0,0.14),0px 8px 42px 7px rgba(0,0,0,0.12)",
					"0px 11px 14px -7px rgba(0,0,0,0.2),0px 23px 36px 3px rgba(0,0,0,0.14),0px 9px 44px 8px rgba(0,0,0,0.12)",
					"0px 11px 15px -7px rgba(0,0,0,0.2),0px 24px 38px 3px rgba(0,0,0,0.14),0px 9px 46px 8px rgba(0,0,0,0.12)",
					"0 5px 5px -3px rgba(0,0,0,.06), 0 8px 10px 1px rgba(0,0,0,.042), 0 3px 14px 2px rgba(0,0,0,.036)"
				}
			};

			base.LayoutProperties = new LayoutProperties()
			{
				DefaultBorderRadius = "4px",
				DrawerMiniWidthLeft = "56px",
				DrawerMiniWidthRight = "56px",
				DrawerWidthLeft = "240px",
				DrawerWidthRight = "240px",
				DrawerHeightTop = "320px",
				DrawerHeightBottom = "320px",
				AppbarHeight = "64px"

			};

			base.ZIndex = new ZIndex()
			{
				Drawer = 1100,
				AppBar = 1200,
				Dialog = 1300,
				Popover = 1400,
				Snackbar = 1500,
				Tooltip = 1600
			};
		}

		#endregion
	}
}