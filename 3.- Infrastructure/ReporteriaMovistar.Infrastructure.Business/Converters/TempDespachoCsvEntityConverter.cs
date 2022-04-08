
using System;
using System.Collections.Generic;
using System.Linq;
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Domain.Models.Entities;

namespace ReporteriaMovistar.Application.Models.Transfer
{

    public static partial class TempDespachoCsvEntityConverter
    {
	    public static List<TempDespachoCsvEntity> ToEntitiesWithRelated(this NewBulkDespachoCsvModel model, DateTime fechaCreacion, string usuarioCreacion)
	    {
		    List<TempDespachoCsvEntity> entities = model.Despachos.Where(d => !string.IsNullOrWhiteSpace(d.Guia)).Select(d =>
		    new TempDespachoCsvEntity()
		    {
			    Esn = d.Esn,
			    Fecha = d.Fecha,
			    Guia = d.Guia,
			    EstadoDespacho = d.EstadoDespacho,
				Operario = d.Operario,
				Caja = d.Caja,
				Pallet = d.Pallet,
				EstadoFuentePoder = d.FuentePoder,
				EstadoUtp = d.Utp,
				EstadoControlRemoto = d.ControlRemoto,
				EstadoHdmi = d.Hdmi,
				EstadoRca = d.Rca,
				Pintura = d.Pintura,
				Derivada = d.Derivada,
				ProcesoFinalizado = d.ProcesoFinalizado,
				FechaCreacionRegistro = fechaCreacion,
				UsuarioCreacionRegistro = usuarioCreacion,
				CargaExitosa = false
		    }).ToList();

		    return entities;
	    }
	}
}
