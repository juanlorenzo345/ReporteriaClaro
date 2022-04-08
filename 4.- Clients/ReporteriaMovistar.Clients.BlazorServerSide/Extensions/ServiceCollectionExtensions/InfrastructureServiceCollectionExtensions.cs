#region Header
//  ---------------------------------------------------------------------------------------------------
// |                                                                                                   |
// |             __                         __               __       ______ __     _  __              |
// |            / /   ____   ____ _ __  __ / /_ ___   _____ / /_     / ____// /_   (_)/ /___           |
// |           / /   / __ \ / __ `// / / // __// _ \ / ___// __ \   / /    / __ \ / // // _ \          |
// |          / /___/ /_/ // /_/ // /_/ // /_ /  __// /__ / / / /  / /___ / / / // // //  __/          |
// |         /_____/\____/ \__, / \__, / \__/ \___/ \___//_/ /_/   \____//_/ /_//_//_/ \___/           |
// |                      /____/ /____/                                                                |
// |                                                                                                   |
//  ---------------------------------------------------------------------------------------------------
// 
// Usuario: cristian.ulloa
// Solución/Proyecto: TsaDotNet / TsaDotNet.Server.BlazorWasm
// Info archivo:
//     Nombre: InfrastructureServiceCollectionExtensions.cs
//     Fecha creación: 2021/10/20 at 09:33 AM
//     Fecha modificación: 2021/10/20 at 09:33 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using Microsoft.Extensions.DependencyInjection;
using ReporteriaMovistar.Application.Interfaces.Services.Data;
using ReporteriaMovistar.Clients.BlazorServerSide.Data;
using ReporteriaMovistar.Infrastructure.Business.Services.Data;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Extensions.ServiceCollectionExtensions
{
	internal static class InfrastructureServiceCollectionExtensions
	{
		internal static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
		{
			services.AddSeguridadServices();
			services.AddMantenimientoServices();
			services.AddNegocioServices();
			services.AddDataListServices();
			return services;
		}

		private static IServiceCollection AddSeguridadServices(this IServiceCollection services)
		{
			services.AddScoped<IUsuarioService, UsuarioService>();
			services.AddScoped<IRolService, RolService>();
			services.AddScoped<IUsuarioApiService, UsuarioApiService>();
			services.AddScoped<ILogAccesoUsuarioService, LogAccesoUsuarioService>();
			services.AddScoped<ILogExcepcionUsuarioService, LogExcepcionUsuarioService>();
			return services;
		}

		private static IServiceCollection AddMantenimientoServices(this IServiceCollection services)
		{
			services.AddScoped<IEtapaService, EtapaService>();
			services.AddScoped<ISecuenciaEtapaService, SecuenciaEtapaService>();
			services.AddScoped<ITecnologiaEquipoService, TecnologiaEquipoService>();
			services.AddScoped<IZonaService, ZonaService>();
			services.AddScoped<IMarcaEquipoService, MarcaEquipoService>();
			services.AddScoped<IModeloEquipoService, ModeloEquipoService>();
			services.AddScoped<IEstadoDespachoService, EstadoDespachoService>();
			services.AddScoped<IColorEquipoService, ColorEquipoService>();
			services.AddScoped<IConfiguracionEquipoService, ConfiguracionEquipoService>();
			services.AddScoped<IEstadoEtapaService, EstadoEtapaService>();
			services.AddScoped<IEstadoComponenteService, EstadoComponenteService>();
			services.AddScoped<IOperarioService, OperarioService>();
			return services;
		}

		private static IServiceCollection AddNegocioServices(this IServiceCollection services)
		{
			services.AddScoped<IEquipoService, EquipoService>();
			services.AddScoped<IMovimientoEquipoService, MovimientoEquipoService>();
			services.AddScoped<IPronosticoService, PronosticoService>();
			services.AddScoped<IEncabezadoDespachoService, EncabezadoDespachoService>();
			services.AddScoped<IDetalleDespachoService, DetalleDespachoService>();
			services.AddScoped<IMovimientoEmpaqueADespachoService, MovimientoEmpaqueADespachoService>();
			services.AddScoped<IMovimientoEtiquetadoACalidadService, MovimientoEtiquetadoACalidadService>();
			return services;
		}

		private static IServiceCollection AddDataListServices(this IServiceCollection services)
		{
			services.AddScoped<EquipoData>();
			services.AddScoped<EstadoComponenteData>();
			services.AddScoped<EstadoDespachoData>();
			services.AddScoped<EstadoEtapaData>();
			services.AddScoped<EtapaData>();
			services.AddScoped<MarcaEquipoData>();
			services.AddScoped<TecnologiaData>();
			services.AddScoped<ZonaData>();
			services.AddScoped<OperarioData>();
			return services;
		}
	}
}