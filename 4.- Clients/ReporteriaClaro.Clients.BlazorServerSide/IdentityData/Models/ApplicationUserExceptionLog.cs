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
//     Nombre: ApplicationUserExceptionLog.cs
//     Fecha creación: 2021/10/25 at 10:01 AM
//     Fecha modificación: 2021/10/25 at 10:01 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReporteriaClaro.Clients.BlazorServerSide.IdentityData.Models
{
	public class ApplicationUserExceptionLog
	{
		[Key]
		public int Id
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
		[Column(TypeName = "varchar(MAX)")]
		public string Message
		{
			get;
			set;
		}

		[Required]
		[Column(TypeName = "varchar(200)")]
		public string Type
		{
			get;
			set;
		}

		[Required]
		[Column(TypeName = "varchar(MAX)")]
		public string Source
		{
			get;
			set;
		}

		[Required]
		[Column(TypeName = "varchar(2048)")]
		public string Url
		{
			get;
			set;
		}

		[Required]
		public DateTime CreatedAt
		{
			get;
			set;
		}
	}
}