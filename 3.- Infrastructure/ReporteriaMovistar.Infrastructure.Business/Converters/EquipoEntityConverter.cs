﻿
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Input.Update;
using ReporteriaMovistar.Domain.Models.Entities;
using ReporteriaMovistar.Infrastructure.Business.Extensions;

namespace ReporteriaMovistar.Application.Models.Transfer
{

    public static partial class EquipoEntityConverter
    {
	    public static void UpdateEntityFromModel(this EquipoEntity entity, NewDetalleDespachoModel model)
	    {
		    entity.Derivada = model.Derivada;
		    entity.Pintura = model.Pintura;
		    entity.ProcesoFinalizado = model.ProcesoFinalizado;
		    entity.FuentePoderEstadoId = model.EstadoFuentePoder.Id;
		    entity.UtpEstadoId = model.EstadoUtp.Id;
		    entity.ControlRemotoEstadoId = model.EstadoControlRemoto.Id;
		    entity.HdmiEstadoId = model.EstadoHdmi.Id;
		    entity.RcaEstadoId = model.EstadoRca.Id;
		    entity.SetModifiedInfo(model);
	    }

		public static void UpdateEntityFromModel(this EquipoEntity entity, UpdateDetalleDespachoModel model)
	    {
		    entity.Derivada = model.Derivada;
		    entity.Pintura = model.Pintura;
		    entity.ProcesoFinalizado = model.ProcesoFinalizado;
		    entity.FuentePoderEstadoId = model.EstadoFuentePoder.Id;
		    entity.UtpEstadoId = model.EstadoUtp.Id;
		    entity.ControlRemotoEstadoId = model.EstadoControlRemoto.Id;
		    entity.HdmiEstadoId = model.EstadoHdmi.Id;
		    entity.RcaEstadoId = model.EstadoRca.Id;
            entity.SetModifiedInfo(model);
        }
    }
}
