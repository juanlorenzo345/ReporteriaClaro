using System;
using System.Collections.Generic;
using System.Linq;
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Input.Update;
using ReporteriaMovistar.Domain.Models.Entities;
using ReporteriaMovistar.Infrastructure.Business.Csv.Models;
using ReporteriaMovistar.Infrastructure.Business.Extensions;

namespace ReporteriaMovistar.Application.Models.Transfer
{
	public static partial class DespachoEncabezadoEntityConverter
	{
		public static DespachoEncabezadoEntity ToEntity(this NewEncabezadoDespachoModel model)
		{
			DespachoEncabezadoEntity entity = new DespachoEncabezadoEntity()
			{
				Guia = model.Guia,
				Fecha = model.Fecha.Value,
				EstadoId = model.Estado.Id
			};

			entity.SetCreatedInfo(model);
			return entity;
		}

		/*public static List<DespachoEncabezadoEntity> ToEntitiesWithRelated(this List<DespachoCsvModel> model, DateTime fechaCreacion, string usuarioCreacion)
		{
			List<DespachoEncabezadoEntity> entities = model.Where(d => !string.IsNullOrWhiteSpace(d.Guia)).GroupBy(d => d.Guia.Trim()).Select(g =>
			new DespachoEncabezadoEntity()
			{
				Fecha = g.First().Fecha,
				Guia = g.Key.Trim(),
				EstadoId = 1, //TODO: Reemplazar valor de prueba por final.
				FechaCreacionRegistro = fechaCreacion,
				UsuarioCreacionRegistro = usuarioCreacion,
				Activo = true,
				DespachoDetalleEntities = new List<DespachoDetalleEntity>()
			}).ToList();

			foreach (DespachoEncabezadoEntity entity in entities)
			{
				entity.DespachoDetalleEntities = model.Where(d => d.Guia.Trim() == entity.Guia).Select(d =>
				new DespachoDetalleEntity()
				{
					EquipoId = 3, //TODO: Reemplazar aquí!!
					Caja = d.Caja,
					Pallet = d.Pallet,
					FechaCreacionRegistro = fechaCreacion,
					UsuarioCreacionRegistro = usuarioCreacion,
					Activo = true
				}).ToList();
			}

			return entities;
		}*/

		public static void UpdateEntityFromModel(this DespachoEncabezadoEntity entity, UpdateEncabezadoDespachoModel model)
		{
			entity.Guia = model.Guia;
			entity.Fecha = model.Fecha.Value;
			entity.EstadoId = model.Estado.Id;
			entity.SetModifiedInfo(model);
		}
	}
}