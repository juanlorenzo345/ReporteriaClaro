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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Application.Models
// Info archivo:
//     Nombre: ViewEquipoModel.cs
//     Fecha creación: 2021/11/08 at 04:18 PM
//     Fecha modificación: 2021/11/08 at 04:18 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------

#endregion

using System;

namespace ReporteriaClaro.Application.Models.View
{
	public class ViewRecepcionModel : ViewModelBase<int>
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

		public decimal HeaderId
		{
			get;
			set;
		}

		public string NumeroReferencia
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

		public string Tecnologia
		{
			get;
			set;
		}

		public string Tipo
		{
			get;
			set;
		}

		public string Subtipo
		{
			get;
			set;
		}

		public string Categoria
		{
			get;
			set;
		}

		public string Subcategoria
		{
			get;
			set;
		}
	}
}