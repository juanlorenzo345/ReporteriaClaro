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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Infrastructure.Business
// Info archivo:
//     Nombre: PagerInfoExtensions.cs
//     Fecha creación: 2021/10/27 at 01:04 PM
//     Fecha modificación: 2021/10/27 at 01:04 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

namespace ReporteriaClaro.Infrastructure.Business.Extensions
{
	internal static class PagerInfoExtensions
	{
		internal static Domain.Models.Pagination.PagerInfo ToDomainPager(this Application.Models.Pagination.PagerInfo pagerInfo)
		{
			return new Domain.Models.Pagination.PagerInfo(pagerInfo.Page, pagerInfo.PageSize);
		}
	}
}