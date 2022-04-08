
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Input.Update;
using ReporteriaMovistar.Domain.Models.Entities;
using ReporteriaMovistar.Infrastructure.Business.Extensions;

namespace ReporteriaMovistar.Application.Models.Transfer
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
