
using ReporteriaClaro.Application.Models.Input.Update;
using ReporteriaClaro.Domain.Models.Entities;

namespace ReporteriaClaro.Application.Models.Transfer
{

    public static partial class IdentityUserEntityConverter
    {
	    public static void SetActivationInfo(this IdentityUserEntity entity, UpdateActivacionUsuarioModel model)
	    {
		    entity.Active = model.Activo;
		    entity.Reason = model.Razon;
		    entity.DeactivatedAt = model.FechaDesactivacion;
		    entity.DeactivatedBy = model.UsuarioDesactivacion;
	    }
	}
}
