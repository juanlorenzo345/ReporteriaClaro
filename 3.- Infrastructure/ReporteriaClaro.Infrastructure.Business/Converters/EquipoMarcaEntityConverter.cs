
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Input.Update;
using ReporteriaClaro.Domain.Models.Entities;
using ReporteriaClaro.Infrastructure.Business.Extensions;

namespace ReporteriaClaro.Application.Models.Transfer
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
