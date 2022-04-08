
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Input.Update;
using ReporteriaMovistar.Domain.Models.Entities;
using ReporteriaMovistar.Infrastructure.Business.Extensions;

namespace ReporteriaMovistar.Application.Models.Transfer
{

    public static partial class EquipoConfiguracionEntityConverter
    {
	    public static EquipoConfiguracionEntity ToEntity(this NewConfiguracionEquipoModel model)
	    {
		    EquipoConfiguracionEntity entity = new EquipoConfiguracionEntity()
		    {
				Nombre = model.Nombre,
				Detalle = model.Detalle,
				TecnologiaId = model.Tecnologia.Id
			};

		    entity.SetCreatedInfo(model);
		    return entity;
	    }

	    public static void UpdateEntityFromModel(this EquipoConfiguracionEntity entity, UpdateConfiguracionEquipoModel model)
	    {
		    entity.Nombre = model.Nombre;
		    entity.Detalle = model.Detalle;
		    entity.TecnologiaId = model.Tecnologia.Id;
		    entity.SetModifiedInfo(model);
	    }
	}
}
