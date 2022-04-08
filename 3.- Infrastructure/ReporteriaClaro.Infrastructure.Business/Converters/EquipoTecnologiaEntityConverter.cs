
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Input.Update;
using ReporteriaClaro.Domain.Models.Entities;
using ReporteriaClaro.Infrastructure.Business.Extensions;

namespace ReporteriaClaro.Application.Models.Transfer
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
