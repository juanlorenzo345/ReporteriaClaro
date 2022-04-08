
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Input.Update;
using ReporteriaClaro.Domain.Models.Entities;
using ReporteriaClaro.Infrastructure.Business.Extensions;

namespace ReporteriaClaro.Application.Models.Transfer
{

    public static partial class EtapaEstadoEntityConverter
    {
	    public static EtapaEstadoEntity ToEntity(this NewEstadoEtapaModel model)
	    {
		    EtapaEstadoEntity entity = new EtapaEstadoEntity()
		    {
				Nombre = model.Nombre,
				Posicion = model.Posicion,
			};

		    entity.SetCreatedInfo(model);
		    return entity;
		}

	    public static void UpdateEntityFromModel(this EtapaEstadoEntity entity, UpdateEstadoEtapaModel model)
	    {
		    entity.Nombre = model.Nombre;
		    entity.Posicion = model.Posicion;
		    entity.SetModifiedInfo(model);
	    }
	}
}
