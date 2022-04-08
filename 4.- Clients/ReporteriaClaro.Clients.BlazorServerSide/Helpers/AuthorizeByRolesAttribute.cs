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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Clients.BlazorServerSide
// Info archivo:
//     Nombre: AuthorizeByRolesAttribute.cs
//     Fecha creación: 2021/11/08 at 04:32 PM
//     Fecha modificación: 2021/11/08 at 04:32 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using Microsoft.AspNetCore.Authorization;

namespace ReporteriaClaro.Clients.BlazorServerSide.Helpers
{
	public class AuthorizeByRolesAttribute : AuthorizeAttribute
	{
		public AuthorizeByRolesAttribute(params string[] roles) : base()
		{
			Roles = string.Join(",", roles);
		}
	}
}