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
// Solución/Proyecto: TsaDotNet / TsaDotNet.Server.BlazorWasm
// Info archivo:
//     Nombre: ApplicationUserToken.cs
//     Fecha creación: 2021/10/15 at 03:04 PM
//     Fecha modificación: 2021/10/15 at 03:05 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ReporteriaClaro.Clients.BlazorServerSide.IdentityData.Models
{
	public class ApplicationUserToken : IdentityUserToken<string>
	{
		[Required]
		public DateTime CreatedAt
		{
			get;
			set;
		}

		[Required]
		[MaxLength(256)]
		public string CreatedBy
		{
			get;
			set;
		}

		public DateTime? ModifiedAt
		{
			get;
			set;
		}

		[MaxLength(256)]
		public string ModifiedBy
		{
			get;
			set;
		}

		public DateTime? DeactivatedAt
		{
			get;
			set;
		}

		[MaxLength(256)]
		public string DeactivatedBy
		{
			get;
			set;
		}
	}
}