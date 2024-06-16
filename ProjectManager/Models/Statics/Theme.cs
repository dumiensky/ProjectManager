using MudBlazor;

namespace ProjectManager.Models.Statics;

public class Theme
{
	public static readonly MudTheme Default = new()
	{
		Palette = new PaletteLight
		{
			Background = Colors.Grey.Lighten5
		},
		PaletteDark = new PaletteDark()
	};
}