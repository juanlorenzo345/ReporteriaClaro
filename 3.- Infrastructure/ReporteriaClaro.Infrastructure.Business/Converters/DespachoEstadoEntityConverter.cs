
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Input.Update;
using ReporteriaClaro.Domain.Models.Entities;
using ReporteriaClaro.Infrastructure.Business.Extensions;

namespace ReporteriaClaro.Application.Models.Transfer
{

    public static partial class DespachoEstadoEntityConverter
    {
	    public static DespachoEstadoEntity ToEntity(this NewEstadoDespachoModel model)
	    {
		    DespachoEstadoEntity entity = new DespachoEstadoEntity()
		    {
				Nombre = model.Nombre,
				Posicion = model.Posicion
			};

		    entity.SetCreatedInfo(model);
		    return entity;
	    }

	    public static void UpdateEntityFromModel(this DespachoEstadoEntity entity, UpdateEstadoDespachoModel model)
	    {
		    entity.Nombre = model.Nombre;
		    entity.Posicion = model.Posicion;
		    entity.SetModifiedInfo(model);
	    }
	}
}
