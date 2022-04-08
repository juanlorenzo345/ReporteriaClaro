
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Input.Update;
using ReporteriaClaro.Domain.Models.Entities;
using ReporteriaClaro.Infrastructure.Business.Extensions;

namespace ReporteriaClaro.Application.Models.Transfer
{

    public static partial class EquipoColorEntityConverter
    {
		public static EquipoColorEntity ToEntity(this NewColorEquipoModel model)
		{
			EquipoColorEntity entity = new EquipoColorEntity()
			{
				Nombre = model.Nombre
			};

			entity.SetCreatedInfo(model);
			return entity;
		}

		public static void UpdateEntityFromModel(this EquipoColorEntity entity, UpdateColorEquipoModel model)
		{
			entity.Nombre = model.Nombre;
			entity.SetModifiedInfo(model);
		}
	}
}
