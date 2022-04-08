
using ReporteriaMovistar.Application.Models.Input.Delete;
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Input.Update;
using ReporteriaMovistar.Domain.Models.Entities;

namespace ReporteriaMovistar.Application.Models.Transfer
{

    public static partial class ApiUserEntityConverter
    {
	    public static ApiUserEntity ToEntity(this NewUsuarioApiModel model, string keyHash)
	    {
		    return new ApiUserEntity()
		    {
			    Comments = model.Comentario,
			    KeyHash = keyHash,
				CreatedAt = model.FechaCreacionRegistro,
				CreatedBy = model.UsuarioCreacionRegistro,
				Active = model.Activo
		    };
	    }

	    public static void UpdateEntityFromModel(this ApiUserEntity entity, UpdateUsuarioApiModel model)
	    {
		    entity.Comments = model.Comentario;
		    entity.ModifiedAt = model.FechaModificacionRegistro;
		    entity.ModifiedBy = model.UsuarioModificacionRegistro;
	    }

	    public static void UpdateEntityFromModel(this ApiUserEntity entity, DeleteUsuarioApiModel model)
	    {
		    entity.DeactivatedReason = model.Razon;
		    entity.DeactivatedAt = model.FechaEliminacionRegistro;
		    entity.DeactivatedBy = model.UsuarioEliminacionRegistro;
		    entity.Active = false;
	    }
	}
}
