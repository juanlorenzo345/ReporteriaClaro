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
// Solución/Proyecto: ReporteriaMovistar / ReporteriaMovistar.Application.Models
// Info archivo:
//     Nombre: DeleteModelBase.cs
//     Fecha creación: 2021/10/25 at 08:39 AM
//     Fecha modificación: 2021/10/25 at 08:39 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;

namespace ReporteriaMovistar.Application.Models.Input.Delete
{
	public class DeleteModelBase<TKey>
	{
		#region Properties and Indexers

		public bool Activo
		{
			get => false;
		}

		public DateTime FechaEliminacionRegistro
		{
			get;
			set;
		}

		public TKey Id
		{
			get;
			set;
		}

		public string UsuarioEliminacionRegistro
		{
			get;
			set;
		}

		#endregion
	}
}