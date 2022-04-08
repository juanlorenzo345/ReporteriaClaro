
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Input.Update;
using ReporteriaClaro.Domain.Models.Entities;
using ReporteriaClaro.Infrastructure.Business.Extensions;

namespace ReporteriaClaro.Application.Models.Transfer
{

    public static partial class EtapaEntityConverter
    {
	    public static EtapaEntity ToEntity(this NewEtapaModel model)
	    {
		    EtapaEntity entity = new EtapaEntity()
		    {
			    Nombre = model.Nombre,
				Posicion = model.Posicion,
				ZonaId = model.Zona.Id,
		    };

			entity.SetCreatedInfo(model);
			return entity;
	    }

	    public static void UpdateEntityFromModel(this EtapaEntity entity, UpdateEtapaModel model)
	    {
		    entity.Nombre = model.Nombre;
		    entity.Posicion = model.Posicion;
		    entity.ZonaId = model.Zona.Id;
		    entity.SetModifiedInfo(model);
	    }
	}
}
