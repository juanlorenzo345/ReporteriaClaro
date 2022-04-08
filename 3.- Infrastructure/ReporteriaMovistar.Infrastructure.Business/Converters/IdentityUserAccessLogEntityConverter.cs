
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Domain.Models.Entities;

namespace ReporteriaMovistar.Application.Models.Transfer
{

    public static partial class IdentityUserAccessLogEntityConverter
    {
	    public static IdentityUserAccessLogEntity ToEntity(this NewLogAccesoUsuarioModel model)
	    {
		    return new IdentityUserAccessLogEntity()
		    {
			    UserId = model.IdUsuario,
			    IpAddress = model.DireccionIp,
			    AccessAt = model.FechaAcceso,
				SuccessfulLogin = model.LoginSatisfactorio,
				Detail = model.Detalle
		    };
	    }
	}
}
