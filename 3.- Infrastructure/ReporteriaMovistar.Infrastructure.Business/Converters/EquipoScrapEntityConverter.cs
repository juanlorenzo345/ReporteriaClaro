
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Domain.Models.Entities;

namespace ReporteriaMovistar.Application.Models.Transfer
{

    public static partial class EquipoScrapEntityConverter
    {
		public static EquipoScrapEntity ToEntity(this NewEquipoScrapModel model)
		{
			return new EquipoScrapEntity()
			{
				Id = model.Id,
				Fecha = model.Fecha.Value,
				Origen = model.Origen,
				Detalle = model.Detalle,
				FechaCreacionRegistro = model.FechaCreacionRegistro,
				UsuarioCreacionRegistro = model.UsuarioCreacionRegistro,
				Activo = model.Activo
			};
		}
	}
}
