
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Input.Update;
using ReporteriaMovistar.Domain.Models.Entities;
using ReporteriaMovistar.Infrastructure.Business.Extensions;

namespace ReporteriaMovistar.Application.Models.Transfer
{

    public static partial class ComponenteEstadoEntityConverter
    {
	    public static ComponenteEstadoEntity ToEntity(this NewEstadoComponenteModel model)
	    {
		    ComponenteEstadoEntity entity = new ComponenteEstadoEntity()
		    {
				Nombre = model.Nombre,
				Posicion = model.Posicion
			};

		    entity.SetCreatedInfo(model);
		    return entity;
	    }

	    public static void UpdateEntityFromModel(this ComponenteEstadoEntity entity, UpdateEstadoComponenteModel model)
	    {
		    entity.Nombre = model.Nombre;
		    entity.Posicion = model.Posicion;
		    entity.SetModifiedInfo(model);
	    }
	}
}
