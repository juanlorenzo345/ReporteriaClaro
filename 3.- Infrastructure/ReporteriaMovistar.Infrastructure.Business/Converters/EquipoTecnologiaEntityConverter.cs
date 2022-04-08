
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Input.Update;
using ReporteriaMovistar.Domain.Models.Entities;
using ReporteriaMovistar.Infrastructure.Business.Extensions;

namespace ReporteriaMovistar.Application.Models.Transfer
{

    public static partial class EquipoTecnologiaEntityConverter
    {
	    public static EquipoTecnologiaEntity ToEntity(this NewTecnologiaEquipoModel model)
	    {
		    EquipoTecnologiaEntity entity = new EquipoTecnologiaEntity()
		    {
			    Nombre = model.Nombre,
		    };

		    entity.SetCreatedInfo(model);
		    return entity;
	    }

	    public static void UpdateEntityFromModel(this EquipoTecnologiaEntity entity, UpdateTecnologiaEquipoModel model)
	    {
		    entity.Nombre = model.Nombre;
		    entity.SetModifiedInfo(model);
	    }
	}
}
