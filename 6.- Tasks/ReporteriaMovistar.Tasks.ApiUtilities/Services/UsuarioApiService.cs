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
// Solución/Proyecto: ReporteriaMovistar / ReporteriaMovistar.Tasks.ApiUtilities
// Info archivo:
//     Nombre: UsuarioApiService.cs
//     Fecha creación: 2021/11/26 at 01:04 PM
//     Fecha modificación: 2021/11/26 at 01:04 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using ReporteriaMovistar.Tasks.ApiUtilities.Entities;
using ReporteriaMovistar.Tasks.ApiUtilities.Helpers;
using ReporteriaMovistar.Tasks.ApiUtilities.Models;
using ReporteriaMovistar.Tasks.ApiUtilities.Repositories;
using ReporteriaMovistar.Tasks.ApiUtilities.Validators;

namespace ReporteriaMovistar.Tasks.ApiUtilities.Services
{
	internal class UsuarioApiService
	{
		private ApiUserRepository apiUserRepository;

		internal UsuarioApiService()
		{
			this.apiUserRepository = new ApiUserRepository();
		}

		internal async Task CrearUsuarioAsync()
		{
			NewUsuarioApiModel modelo = new NewUsuarioApiModel();
			NewUsuarioApiModelValidator validator = new NewUsuarioApiModelValidator();

			Console.WriteLine("Por favor, rellene los siguientes datos: ");
			Console.Write("Comentarios: ");
			modelo.Comentarios = Console.ReadLine();
			Console.Write("Usuario que crea registro: ");
			modelo.UsuarioCreacion = Console.ReadLine();
			modelo.FechaCreacion = DateTime.Now;
			string apiKey = CryptographyUtils.GenerateApiKey();
			modelo.HashLlave = CryptographyUtils.Hash(apiKey);

			ValidationResult resultadoValidacion = validator.Validate(modelo);

			if (!resultadoValidacion.IsValid)
			{
				resultadoValidacion.Errors.ForEach(v => Console.WriteLine(v.ErrorMessage));
				await CrearUsuarioAsync();
			}

			if (!await GuardarUsuarioBaseDatosAsync(modelo))
			{
				await CrearUsuarioAsync();
			}

			Console.WriteLine("La API key generada es:");
			Console.WriteLine(apiKey);
			Console.WriteLine("Recuerde guardar la API key antes de cerrar la aplicación.");
		}

		private async Task<bool> GuardarUsuarioBaseDatosAsync(NewUsuarioApiModel modelo)
		{
			try
			{
				return await this.apiUserRepository.CrearUsuarioAsync(ToEntity(modelo));
			}
			catch (Exception excepcion)
			{
				Console.WriteLine("No se pudo crear la API key.");
				Console.WriteLine(excepcion);
				Console.WriteLine("");
				return false;
			}
		}

		private static ApiUserEntity ToEntity(NewUsuarioApiModel modelo)
		{
			return new ApiUserEntity()
			{
				KeyHash = modelo.HashLlave,
				Comments = modelo.Comentarios,
				CreatedAt = modelo.FechaCreacion,
				CreatedBy = modelo.UsuarioCreacion,
				Active = true
			};
		}
	}
}