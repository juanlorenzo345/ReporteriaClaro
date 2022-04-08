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
//     Nombre: ApplicationUserAccessLog.cs
//     Fecha creación: 2021/10/15 at 04:24 PM
//     Fecha modificación: 2021/10/15 at 04:24 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------

#endregion

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReporteriaClaro.Clients.BlazorServerSide.IdentityData.Models
{
	public class ApplicationUserAccessLog
	{
		[Key]
		public long Id
		{
			get;
			set;
		}

		[Required]
		[ForeignKey("User")]
		public string UserId
		{
			get;
			set;
		}

		public ApplicationUser User
		{
			get;
			set;
		}

		[Required]
		[Column(TypeName = "ipaddress")]
		public string IpAddress
		{
			get;
			set;
		}

		[Required]
		public DateTime AccessAt
		{
			get;
			set;
		}

		[Required]
		public bool SucessfulLogin
		{
			get;
			set;
		}

		[Column(TypeName = "varchar(100)")]
		public string Comment
		{
			get;
			set;
		}
	}
}