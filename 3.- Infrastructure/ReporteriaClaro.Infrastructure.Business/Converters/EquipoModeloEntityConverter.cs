
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Input.Update;
using ReporteriaClaro.Domain.Models.Entities;
using ReporteriaClaro.Infrastructure.Business.Extensions;

namespace ReporteriaClaro.Application.Models.Transfer
{

    public static partial class EquipoModeloEntityConverter
    {
		public static EquipoModeloEntity ToEntity(this NewModeloEquipoModel model)
		{
			EquipoModeloEntity entity = new EquipoModeloEntity()
			{
				Nombre = model.Nombre,
				MarcaId = model.Marca.Id,
				TecnologiaId = model.Tecnologia.Id
			};

			entity.SetCreatedInfo(model);
			return entity;
		}

		public static void UpdateEntityFromModel(this EquipoModeloEntity entity, UpdateModeloEquipoModel model)
		{
			entity.Nombre = model.Nombre;
			entity.MarcaId = model.Marca.Id;
			entity.TecnologiaId = model.Tecnologia.Id;
			entity.SetModifiedInfo(model);
		}
	}
}
