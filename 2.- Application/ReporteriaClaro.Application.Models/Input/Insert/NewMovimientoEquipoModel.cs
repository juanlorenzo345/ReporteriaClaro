﻿#region Header

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
//     Nombre: NewMovimientoEquipoModel.cs
//     Fecha creación: 2021/10/27 at 05:25 PM
//     Fecha modificación: 2021/10/27 at 05:25 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using ReporteriaClaro.Application.Models.Input.Choice;

namespace ReporteriaClaro.Application.Models.Input.Insert
{
	public class NewMovimientoEquipoModel : NewModelBase
	{
		public DateTime? Fecha
		{
			get;
			set;
		} = DateTime.Now;

		public TimeSpan? Hora
		{
			get;
			set;
		} = DateTime.Now.TimeOfDay;

		public ChoiceEtapaModel EtapaOrigen
		{
			get;
			set;
		} = new ChoiceEtapaModel() { Id = -1, Nombre = string.Empty, Zona = string.Empty };

		public string Esn
		{
			get;
			set;
		}

		public ChoiceEquipoModel Equipo
		{
			get;
			set;
		} = new ChoiceEquipoModel() { Id = -1, Esn = string.Empty, Marca = string.Empty, Modelo = string.Empty, Color = string.Empty };

		public ChoiceEtapaModel EtapaDestino
		{
			get;
			set;
		} = new ChoiceEtapaModel() { Id = -1, Nombre = string.Empty, Zona = string.Empty };

		public ChoiceOperarioModel Operario
		{
			get;
			set;
		} = new ChoiceOperarioModel() { Id = -1, Nombre = string.Empty };

		public ChoiceOperarioModel OperarioDevolucion
		{
			get;
			set;
		} = new ChoiceOperarioModel() { Id = -1, Nombre = string.Empty };

		public string Observacion
		{
			get;
			set;
		}
	}
}