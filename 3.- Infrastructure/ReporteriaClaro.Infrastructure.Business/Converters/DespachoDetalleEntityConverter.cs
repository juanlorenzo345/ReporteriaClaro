
using System.Collections.Generic;
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Input.Update;
using ReporteriaClaro.Domain.Models.Entities;
using ReporteriaClaro.Infrastructure.Business.Extensions;

namespace ReporteriaClaro.Application.Models.Transfer
{

	public static partial class DespachoDetalleEntityConverter
	{
		public static DespachoDetalleEntity ToEntity(this NewDetalleDespachoModel model)
		{
			DespachoDetalleEntity entity = new DespachoDetalleEntity()
			{
				EncabezadoId = model.IdEncabezado,
				EquipoId = model.Equipo.Id,
				Caja = model.Caja,
				Pallet = model.Pallet,
			};

			entity.SetCreatedInfo(model);
			return entity;
		}

		public static void UpdateEntityFromModel(this DespachoDetalleEntity entity, UpdateDetalleDespachoModel model)
		{
			entity.EncabezadoId = model.EncabezadoId;
			entity.EquipoId = model.Equipo.Id;
			entity.Caja = model.Caja;
			entity.Pallet = model.Pallet;
			entity.SetModifiedInfo(model);
		}
	}
}