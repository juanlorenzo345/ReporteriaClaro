
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Domain.Models.Entities;

namespace ReporteriaClaro.Application.Models.Transfer
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
