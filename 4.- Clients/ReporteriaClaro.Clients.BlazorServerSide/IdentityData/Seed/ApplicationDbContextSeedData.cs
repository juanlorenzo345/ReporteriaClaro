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
//     Nombre: ApplicationDbContextSeedData.cs
//     Fecha creación: 2021/10/01 at 05:33 PM
//     Fecha modificación: 2021/10/01 at 05:33 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using Microsoft.EntityFrameworkCore;
using ReporteriaClaro.Clients.BlazorServerSide.IdentityData.Models;

namespace ReporteriaClaro.Clients.BlazorServerSide.IdentityData.Seed
{
	internal static class ApplicationDbContextSeedData
	{
		private const string IdRolSuperAdministrador = "4FFF1CF5-C12A-4764-9DC2-7C622050DACF";

		private const string IdSuperAdministrador = "76DE897E-595E-47CF-8DDC-E0216DE47E94";

		private const string UsuarioCreacion = "EF Core seed";

		private static DateTime fechaCreacion;

		static ApplicationDbContextSeedData()
		{
			fechaCreacion = new DateTime(2021, 10, 25, 12, 0, 0);
		}

		internal static void SeedInitialIdentityData(ModelBuilder builder)
		{
			builder.Entity<ApplicationRole>().HasData(GetInitialRoles());
			builder.Entity<ApplicationUser>().HasData(GetInitialUsers());
			builder.Entity<ApplicationUserRole>().HasData(GetInitialUserRoles());
		}
		
		private static ApplicationUserRole[] GetInitialUserRoles()
		{
			return new ApplicationUserRole[]
			{
				new ApplicationUserRole()
				{
					RoleId = IdRolSuperAdministrador,
					UserId = IdSuperAdministrador,
					CreatedAt = fechaCreacion,
					CreatedBy = UsuarioCreacion
				}
			};
		}

		private static ApplicationUser[] GetInitialUsers()
		{
			string fullName = "Super administrador";
			string userName = "superadmin";
			string password = "LogytechChile@2021";

			ApplicationUser admin = new ApplicationUser
			{
				Id = IdSuperAdministrador,
				FullName = fullName,
				NormalizedFullName = fullName.ToUpper(),
				UserName = userName,
				NormalizedUserName = userName.ToUpper(),
				CreatedAt = fechaCreacion,
				CreatedBy = UsuarioCreacion,
				Active = true
			};

			ApplicationPasswordHasher hasher = new ApplicationPasswordHasher();
			admin.PasswordHash = hasher.HashPassword(admin, password);

			return new ApplicationUser[]
			{
				admin
			};
		}

		private static ApplicationRole[] GetInitialRoles()
		{
			return new ApplicationRole[]
			{
				new ApplicationRole()
				{
					Id = IdRolSuperAdministrador,
					Name = Roles.SuperAdministrador,
					NormalizedName = Roles.SuperAdministrador.ToUpper(),
					ConcurrencyStamp = "31B69BDF-BFF8-4776-9E6F-30514259C5BF",
					AvailableAsAdmin = false,
					AvailableAsSuperAdmin = false,
					CreatedAt = fechaCreacion,
					CreatedBy = UsuarioCreacion
				},
				new ApplicationRole()
				{
					Id = "8F74F0E7-02CC-46D7-B26B-4E8C7606C5C1",
					Name = Roles.Administrador,
					NormalizedName = Roles.Administrador.ToUpper(),
					ConcurrencyStamp = "B4CD1FE1-A213-497E-AB65-FFFB57621542",
					AvailableAsAdmin = false,
					AvailableAsSuperAdmin = true,
					CreatedAt = fechaCreacion,
					CreatedBy = UsuarioCreacion
				},
				new ApplicationRole()
				{
					Id = "CE6FF9B8-1886-4E6A-866F-4EC8478C04D3",
					Name = Roles.Diagnostico,
					NormalizedName = Roles.Diagnostico.ToUpper(),
					ConcurrencyStamp = "EC939B6D-1ED3-4343-BBCA-6CC8CF318B57",
					AvailableAsAdmin = true,
					AvailableAsSuperAdmin = true,
					CreatedAt = fechaCreacion,
					CreatedBy = UsuarioCreacion
				},
				new ApplicationRole()
				{
					Id = "54AF55A9-2FCB-4EB0-B57B-D832D496054E",
					Name = Roles.Limpieza,
					NormalizedName = Roles.Limpieza.ToUpper(),
					ConcurrencyStamp = "DF1464D9-0915-4133-A5C0-1D128417D274",
					AvailableAsAdmin = true,
					AvailableAsSuperAdmin = true,
					CreatedAt = fechaCreacion,
					CreatedBy = UsuarioCreacion
				},
				new ApplicationRole()
				{
					Id = "05C5A29F-08CE-4AB7-8094-2C755BF7E09F",
					Name = Roles.Pintura,
					NormalizedName = Roles.Pintura.ToUpper(),
					ConcurrencyStamp = "F27D77F6-B766-4117-BFFF-CCC4CE853443",
					AvailableAsAdmin = true,
					AvailableAsSuperAdmin = true,
					CreatedAt = fechaCreacion,
					CreatedBy = UsuarioCreacion
				},
				new ApplicationRole()
				{
					Id = "6B1E4A23-7B9C-4F45-9E11-7F0DAF73866E",
					Name = Roles.QuickResponse,
					NormalizedName = Roles.QuickResponse.ToUpper(),
					ConcurrencyStamp = "A5B01380-5A1B-453E-8326-96007F236E3F",
					AvailableAsAdmin = true,
					AvailableAsSuperAdmin = true,
					CreatedAt = fechaCreacion,
					CreatedBy = UsuarioCreacion
				},
				new ApplicationRole()
				{
					Id = "9DF85B90-93AE-4D31-8AF3-4BC0CE59DA13",
					Name = Roles.Etiquetado,
					NormalizedName = Roles.Etiquetado.ToUpper(),
					ConcurrencyStamp = "3DF4AC0A-0B3A-4CCE-8211-98EE5AC0E537",
					AvailableAsAdmin = true,
					AvailableAsSuperAdmin = true,
					CreatedAt = fechaCreacion,
					CreatedBy = UsuarioCreacion
				},
				new ApplicationRole()
				{
					Id = "2025A47B-4690-4AF7-A37D-D21D96B757E1",
					Name = Roles.ControlCalidad,
					NormalizedName = Roles.ControlCalidad.ToUpper(),
					ConcurrencyStamp = "D369638A-14F0-41FE-BAA2-EF44E8C58983",
					AvailableAsAdmin = true,
					AvailableAsSuperAdmin = true,
					CreatedAt = fechaCreacion,
					CreatedBy = UsuarioCreacion
				},
				new ApplicationRole()
				{
					Id = "4E57555F-6201-46C2-B0C9-189843465678",
					Name = Roles.Empaque,
					NormalizedName = Roles.Empaque.ToUpper(),
					ConcurrencyStamp = "E5191C7B-669D-4DE6-B71B-151B5EEC55FA",
					AvailableAsAdmin = true,
					AvailableAsSuperAdmin = true,
					CreatedAt = fechaCreacion,
					CreatedBy = UsuarioCreacion
				},
				new ApplicationRole()
				{
					Id = "4AF1C08B-1CB4-4DFB-8AA4-73CE164B21D1",
					Name = Roles.Despacho,
					NormalizedName = Roles.Despacho.ToUpper(),
					ConcurrencyStamp = "21ECDB87-E257-4D4B-B2DC-207CBAB8278D",
					AvailableAsAdmin = true,
					AvailableAsSuperAdmin = true,
					CreatedAt = fechaCreacion,
					CreatedBy = UsuarioCreacion
				}
			};
		}
	}
}