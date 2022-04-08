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
//     Nombre: ViewDetalleDespachoModel.cs
//     Fecha creación: 2021/11/11 at 12:47 PM
//     Fecha modificación: 2021/11/11 at 12:47 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

namespace ReporteriaClaro.Application.Models.View
{
	public class ViewDetalleDespachoModel : ViewModelBase<int>
	{
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

		public int Caja
		{
			get;
			set;
		}

		public int Pallet
		{
			get;
			set;
		}

		public string Derivada
		{
			get;
			set;
		}

		public bool Pintura
		{
			get;
			set;
		}

		public bool ProcesoFinalizado
		{
			get;
			set;
		}

		public string FuentePoder
		{
			get;
			set;
		}

		public string Utp
		{
			get;
			set;
		}

		public string ControlRemoto
		{
			get;
			set;
		}

		public string Hdmi
		{
			get;
			set;
		}

		public string Rca
		{
			get;
			set;
		}
	}
}