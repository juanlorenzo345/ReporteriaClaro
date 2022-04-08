
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Domain.Models.Entities;

namespace ReporteriaClaro.Application.Models.Transfer
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
