
using System;
using System.Collections.Generic;
using System.Linq;
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Domain.Models.Entities;

namespace ReporteriaMovistar.Application.Models.Transfer
{

    public static partial class TempEquipoMovimientoCsvEntityConverter
    {
	    public static List<TempEquipoMovimientoCsvEntity> ToEntitiesWithRelated(this NewBulkMovimientoEquipoAEtapaPosteriorCsvModel model, DateTime fechaCreacion, string usuarioCreacion)
	    {
		    List<TempEquipoMovimientoCsvEntity> entities = model.Movimientos.Where(m => !string.IsNullOrWhiteSpace(m.Esn)).Select(m =>
		    new TempEquipoMovimientoCsvEntity()
		    {
			    Esn = m.Esn,
			    Fecha = m.Fecha,
			    Operario = m.Operario,
			    Observacion = m.Observacion,
			    FechaCreacionRegistro = fechaCreacion,
			    UsuarioCreacionRegistro = usuarioCreacion,
			    CargaExitosa = false
		    }).ToList();

		    return entities;
	    }
	}
}
