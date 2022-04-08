﻿
using System.Collections.Generic;
using System.Linq;
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Domain.Models.Entities;
using ReporteriaClaro.Infrastructure.Business.Extensions;

namespace ReporteriaClaro.Application.Models.Transfer
{

    public static partial class EquipoMovimientoEntityConverter
    {
	    public static List<EquipoMovimientoEntity> ToEntities(this NewBulkMovimientoEquipoModel model)
	    {
		    return model.Movimientos.Select(m =>
		    {
			    EquipoMovimientoEntity entity = new EquipoMovimientoEntity()
			    {
				    Fecha = m.Fecha.Value.Date.Add(m.Hora.Value),
				    EquipoId = m.Equipo.Id,
				    EtapaOrigenId = m.EtapaOrigen.Id,
				    EtapaDestinoId = m.EtapaDestino.Id,
				    OperarioId = m.Operario.Id,
					OperarioDevolucionId = m.EtapaDestino.EsEtapaAnterior ? m.OperarioDevolucion.Id : null,
				    Observacion = m.Observacion,
			    };
			    entity.SetCreatedInfo(m);
			    return entity;
		    }).ToList();
	    }
	}
}
