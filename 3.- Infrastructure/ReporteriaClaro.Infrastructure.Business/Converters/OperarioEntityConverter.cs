
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Input.Update;
using ReporteriaClaro.Domain.Models.Entities;
using ReporteriaClaro.Infrastructure.Business.Extensions;

namespace ReporteriaClaro.Application.Models.Transfer
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
