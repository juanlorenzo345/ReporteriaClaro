using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReporteriaClaro.Clients.ApiPowerBi.Database;
using ReporteriaClaro.Clients.ApiPowerBi.DataProviders;
using ReporteriaClaro.Clients.ApiPowerBi.Models;
using ReporteriaClaro.Clients.ApiPowerBi.Repositories.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReporteriaClaro.Clients.ApiPowerBi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
	    private IDbContextFactory<ReporteriaClaroDbContext> dbContextFactory;

	    public EquipoController(IDbContextFactory<ReporteriaClaroDbContext> dbContextFactory)
	    {
		    this.dbContextFactory = dbContextFactory;
	    }

	    [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<VWDetallePronosticoEquipoPowerBiEntity>>> DetallePronosticoEquipos()
        {
	        await using (ReporteriaClaroDbContext dbContext = this.dbContextFactory.CreateDbContext())
	        {
		        DatabaseService databaseService = new DatabaseService(this.dbContextFactory);
		        databaseService.InitializeUnitOfWork(dbContext);
		        using (IUnitOfWork unitOfWork = databaseService.UnitOfWorkFactory.Create())
		        {
			        return Ok(await unitOfWork.VWDetallePronosticoEquipoPowerBiEntities.GetAllAsync());
		        }
	        }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<VWHistorialMovimientoEquipoPowerBiEntity>>> HistorialMovimientoEquipos()
        {
			await using (ReporteriaClaroDbContext dbContext = this.dbContextFactory.CreateDbContext())
			{
				DatabaseService databaseService = new DatabaseService(this.dbContextFactory);
				databaseService.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = databaseService.UnitOfWorkFactory.Create())
				{
					return Ok(await unitOfWork.VWHistorialMovimientoEquipoPowerBiEntities.GetAllAsync());
				}
			}
		}

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<VWRechazoLimpiezaPowerBiEntity>>> RechazosLimpieza()
        {
	        await using (ReporteriaClaroDbContext dbContext = this.dbContextFactory.CreateDbContext())
	        {
		        DatabaseService databaseService = new DatabaseService(this.dbContextFactory);
		        databaseService.InitializeUnitOfWork(dbContext);
		        using (IUnitOfWork unitOfWork = databaseService.UnitOfWorkFactory.Create())
		        {
			        return Ok(await unitOfWork.VWRechazoLimpiezaPowerBiEntities.GetAllAsync());
		        }
	        }
		}

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<VWUltimoEstadoEquipoPowerBiEntity>>> UltimoEstadoEquipos()
        {
	        await using (ReporteriaClaroDbContext dbContext = this.dbContextFactory.CreateDbContext())
	        {
		        DatabaseService databaseService = new DatabaseService(this.dbContextFactory);
		        databaseService.InitializeUnitOfWork(dbContext);
		        using (IUnitOfWork unitOfWork = databaseService.UnitOfWorkFactory.Create())
		        {
			        return Ok(await unitOfWork.VWUltimoEstadoEquipoPowerBiEntities.GetAllAsync());
		        }
	        }
		}

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<VWEstadoLimpiezaPowerBiEntity>>> EstadoLimpiezaEquipos()
        {
	        await using (ReporteriaClaroDbContext dbContext = this.dbContextFactory.CreateDbContext())
	        {
		        DatabaseService databaseService = new DatabaseService(this.dbContextFactory);
		        databaseService.InitializeUnitOfWork(dbContext);
		        using (IUnitOfWork unitOfWork = databaseService.UnitOfWorkFactory.Create())
		        {
			        return Ok(await unitOfWork.VWEstadoLimpiezaPowerBiEntities.GetAllAsync());
		        }
	        }
        }
	}
}
