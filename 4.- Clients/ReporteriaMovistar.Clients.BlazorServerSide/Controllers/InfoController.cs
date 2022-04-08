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
//     Nombre: InfoController.cs
//     Fecha creación: 2021/12/03 at 12:25 PM
//     Fecha modificación: 2021/12/03 at 12:26 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion


using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Controllers
{
	[Route("info")]
	public class InfoController : ControllerBase
	{
		[HttpGet("ipaddress")]
		public string GetIpAddress()
		{
			IPAddress remoteIpAddress = this.HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
			
			if (remoteIpAddress is null)
			{
				return string.Empty;
			}

			return remoteIpAddress.ToString();
		}
	}
}