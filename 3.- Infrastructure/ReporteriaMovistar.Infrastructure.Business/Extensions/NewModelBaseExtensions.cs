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
// Solución/Proyecto: ReporteriaMovistar / ReporteriaMovistar.Infrastructure.Business
// Info archivo:
//     Nombre: NewModelBaseExtensions.cs
//     Fecha creación: 2021/11/04 at 03:05 PM
//     Fecha modificación: 2021/11/04 at 03:05 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using ReporteriaMovistar.Application.Models.Input.Insert;

namespace ReporteriaMovistar.Infrastructure.Business.Extensions
{
	internal static class NewModelBaseExtensions
	{
		internal static void SetCreatedInfo<TEntity>(this TEntity entity, NewModelBase model) where TEntity : new()
		{
			entity.GetType().GetProperty(nameof(model.FechaCreacionRegistro))?.SetValue(entity, model.FechaCreacionRegistro);
			entity.GetType().GetProperty(nameof(model.UsuarioCreacionRegistro))?.SetValue(entity, model.UsuarioCreacionRegistro);
			entity.GetType().GetProperty(nameof(model.Activo))?.SetValue(entity, model.Activo);
		}
	}
}