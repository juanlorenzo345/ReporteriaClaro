
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Input.Update;
using ReporteriaClaro.Domain.Models.Entities;
using ReporteriaClaro.Infrastructure.Business.Extensions;

namespace ReporteriaClaro.Application.Models.Transfer
{

    public static partial class EtapaSecuenciaEntityConverter
    {
	    public static EtapaSecuenciaEntity ToEntity(this NewSecuenciaEtapaModel model)
	    {
		    EtapaSecuenciaEntity entity = new EtapaSecuenciaEntity()
		    {
			    EtapaId = model.EtapaOrigen.Id,
				EtapaAnteriorPosteriorId = model.EtapaDestino.Id,
				EsEtapaAnterior = model.EsEtapaAnterior
		    };

		    entity.SetCreatedInfo(model);
		    return entity;
	    }

	    /*public static void UpdateEntityFromModel(this EtapaSecuenciaEntity entity, UpdateSecuenciaEtapaModel model)
	    {
		    entity.Nombre = model.Nombre;
		    entity.Posicion = model.Posicion;
		    entity.SetModifiedInfo(model);
	    }*/
	}
}
