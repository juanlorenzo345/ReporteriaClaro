
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Input.Update;
using ReporteriaMovistar.Domain.Models.Entities;
using ReporteriaMovistar.Infrastructure.Business.Extensions;

namespace ReporteriaMovistar.Application.Models.Transfer
{

    public static partial class OperarioEntityConverter
    {
	    public static OperarioEntity ToEntity(this NewOperarioModel model)
	    {
		    OperarioEntity entity = new OperarioEntity()
			{
				Nombre = model.Nombre
			};

			entity.SetCreatedInfo(model);
			return entity;
		}

	    public static void UpdateEntityFromModel(this OperarioEntity entity, UpdateOperarioModel model)
	    {
		    entity.Nombre = model.Nombre;
		    entity.SetModifiedInfo(model);
	    }
	}
}
