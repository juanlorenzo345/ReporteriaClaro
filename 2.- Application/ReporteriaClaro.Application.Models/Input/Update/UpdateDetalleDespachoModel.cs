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
//     Nombre: UpdateDetalleDespachoModel.cs
//     Fecha creación: 2021/11/12 at 10:23 AM
//     Fecha modificación: 2021/11/12 at 10:23 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using ReporteriaClaro.Application.Models.Input.Choice;

namespace ReporteriaClaro.Application.Models.Input.Update
{
	public class UpdateDetalleDespachoModel : UpdateModelBase<int>
	{
		public int EncabezadoId
		{
			get;
			set;
		}

		public ChoiceEquipoModel Equipo
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

		public ChoiceEstadoComponenteModel EstadoFuentePoder
		{
			get;
			set;
		}

		public ChoiceEstadoComponenteModel EstadoUtp
		{
			get;
			set;
		}

		public ChoiceEstadoComponenteModel EstadoControlRemoto
		{
			get;
			set;
		}

		public ChoiceEstadoComponenteModel EstadoHdmi
		{
			get;
			set;
		}

		public ChoiceEstadoComponenteModel EstadoRca
		{
			get;
			set;
		}
	}
}