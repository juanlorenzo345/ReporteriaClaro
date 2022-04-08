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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Infrastructure.Business
// Info archivo:
//     Nombre: DatabaseServiceBase.cs
//     Fecha creación: 2021/10/27 at 10:02 AM
//     Fecha modificación: 2021/10/27 at 10:02 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using ReporteriaClaro.Application.Models.Validation;
using ReporteriaClaro.Domain.Interfaces.Repositories;
using ReporteriaClaro.Infrastructure.Data.DataProviders;
using ReporteriaClaro.Infrastructure.Data.Repositories;

namespace ReporteriaClaro.Infrastructure.Business.Services
{
	public class DatabaseServiceBase
	{
		protected readonly string NombreEntidadNoEncontrada;

		protected readonly string MensajeEntidadNoEncontrada;

		protected readonly IDbContextFactory<ReporteriaClaroDbContext> DbContextFactory;

		protected IUnitOfWorkFactory UnitOfWorkFactory;

		protected DatabaseServiceBase(IDbContextFactory<ReporteriaClaroDbContext> dbContextFactory) : this(dbContextFactory, string.Empty)
		{

		}

		protected DatabaseServiceBase(IDbContextFactory<ReporteriaClaroDbContext> dbContextFactory, string nombreEntidadNoEncontrada)
		{
			this.DbContextFactory = dbContextFactory;
			this.NombreEntidadNoEncontrada = nombreEntidadNoEncontrada;
			string nombreFinalEntidad = !string.IsNullOrWhiteSpace(this.NombreEntidadNoEncontrada) ? $"{this.NombreEntidadNoEncontrada} " : "";
			this.MensajeEntidadNoEncontrada = $"No se pudo encontrar {nombreFinalEntidad}con el ID especificado.";
		}

		protected void InitializeUnitOfWork(ReporteriaClaroDbContext dbContext)
		{
			if (dbContext is null)
			{
				throw new ArgumentNullException(nameof(dbContext), $"El contexto no puede ser null.");
			}

			this.UnitOfWorkFactory = new EntityFrameworkUnitOfWorkFactory(dbContext);
		}

		protected async Task<IEnumerable<string>> ValidateAsync<TObject, TValidator>(TObject model, TValidator validator) where TValidator : AbstractValidatorMudBlazorBase<TObject> where TObject : class
		{
			if (model is null)
			{
				return new List<string> { "Modelo con valor null recibido." };
			}

			ValidationResult validationResult = await validator.ValidateAsync(model);

			if (!validationResult.IsValid)
			{
				return new List<string> { validationResult.Errors[0].ErrorMessage };
			}

			return null;
		}
	}
}