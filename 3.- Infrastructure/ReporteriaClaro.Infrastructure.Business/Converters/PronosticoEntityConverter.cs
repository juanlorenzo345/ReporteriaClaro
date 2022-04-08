
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Input.Update;
using ReporteriaClaro.Domain.Models.Entities;
using ReporteriaClaro.Infrastructure.Business.Extensions;

namespace ReporteriaClaro.Application.Models.Transfer
{

    public static partial class PronosticoEntityConverter
    {
	    public static PronosticoEntity ToEntity(this NewPronosticoModel model)
	    {
		    PronosticoEntity entity = new PronosticoEntity()
		    {
				Mes = (byte)model.Periodo.Value.Month,
				Ano = (short)model.Periodo.Value.Year,
				Estimacion = model.Estimacion,
				TecnologiaId = model.Tecnologia.Id,
			};

		    entity.SetCreatedInfo(model);
		    return entity;
	    }

	    public static void UpdateEntityFromModel(this PronosticoEntity entity, UpdatePronosticoModel model)
	    {
		    entity.Mes = (byte) model.Periodo.Value.Month;
		    entity.Ano = (short) model.Periodo.Value.Year;
		    entity.Estimacion = model.Estimacion;
		    entity.TecnologiaId = model.Tecnologia.Id;
		    entity.SetModifiedInfo(model);
	    }
	}
}
