
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Input.Update;
using ReporteriaClaro.Domain.Models.Entities;
using ReporteriaClaro.Infrastructure.Business.Extensions;

namespace ReporteriaClaro.Application.Models.Transfer
{

    public static partial class ZonaEntityConverter
    {
	    public static ZonaEntity ToEntity(this NewZonaModel model)
	    {
		    ZonaEntity entity = new ZonaEntity()
		    {
			    Nombre = model.Nombre,
		    };

			entity.SetCreatedInfo(model);
			return entity;
	    }

	    public static void UpdateEntityFromModel(this ZonaEntity entity, UpdateZonaModel model)
	    {
		    entity.Nombre = model.Nombre;
			entity.SetModifiedInfo(model);
	    }
	}
}
