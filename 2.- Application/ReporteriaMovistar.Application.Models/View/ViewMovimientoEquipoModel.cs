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
//     Nombre: ViewMovimientoEquipoModel.cs
//     Fecha creación: 2021/11/09 at 10:49 AM
//     Fecha modificación: 2021/11/09 at 10:49 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------

#endregion

using System;

namespace ReporteriaMovistar.Application.Models.View
{
	public class ViewMovimientoEquipoModel : ViewModelBase<int>
	{
		public DateTime Fecha
		{
			get;
			set;
		}

		public string Esn
		{
			get;
			set;
		}

		public string Marca
		{
			get;
			set;
		}

		public string Modelo
		{
			get;
			set;
		}

		public string Color
		{
			get;
			set;
		}

		public string Origen
		{
			get;
			set;
		}

		public string Destino
		{
			get;
			set;
		}

		public string Operario
		{
			get;
			set;
		}

		public string OperarioDevolucion
		{
			get;
			set;
		}

		public string Observacion
		{
			get;
			set;
		}

		//HACK: Es necesario hacer override a GetHashCode y Equals para utilizar multiselección en las tablas de MudBlazor.

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			ViewMovimientoEquipoModel other = (ViewMovimientoEquipoModel)obj;
			return other != null && other.Id == Id;
		}
	}
}