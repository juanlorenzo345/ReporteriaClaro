
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Input.Update;
using ReporteriaMovistar.Domain.Models.Entities;
using ReporteriaMovistar.Infrastructure.Business.Extensions;

namespace ReporteriaMovistar.Application.Models.Transfer
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
