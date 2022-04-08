
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Input.Update;
using ReporteriaMovistar.Domain.Models.Entities;
using ReporteriaMovistar.Infrastructure.Business.Extensions;

namespace ReporteriaMovistar.Application.Models.Transfer
{

    public static partial class EquipoMarcaEntityConverter
    {
		public static EquipoMarcaEntity ToEntity(this NewMarcaEquipoModel model)
		{
			EquipoMarcaEntity entity = new EquipoMarcaEntity()
			{
				Nombre = model.Nombre
			};

			entity.SetCreatedInfo(model);
			return entity;
		}

		public static void UpdateEntityFromModel(this EquipoMarcaEntity entity, UpdateMarcaEquipoModel model)
		{
			entity.Nombre = model.Nombre;
			entity.SetModifiedInfo(model);
		}
	}
}
