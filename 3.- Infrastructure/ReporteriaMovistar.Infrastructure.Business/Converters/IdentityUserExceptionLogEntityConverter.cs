
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Domain.Models.Entities;

namespace ReporteriaMovistar.Application.Models.Transfer
{

    public static partial class IdentityUserExceptionLogEntityConverter
    {
	    public static IdentityUserExceptionLogEntity ToEntity(this NewLogExcepcionUsuarioModel model)
	    {
		    return new IdentityUserExceptionLogEntity()
		    {
			    UserId = model.IdUsuario,
			    Message = model.Mensaje,
				Type = model.Tipo,
				Source = model.Origen,
				Url = model.Url,
			    CreatedAt = model.FechaCreacionRegistro
		    };
	    }
    }
}
