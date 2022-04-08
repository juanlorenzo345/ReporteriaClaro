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
//     Nombre: UpdateModelBaseExtensions.cs
//     Fecha creación: 2021/11/02 at 04:42 PM
//     Fecha modificación: 2021/11/02 at 04:42 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Input.Update;

namespace ReporteriaClaro.Infrastructure.Business.Extensions
{
	internal static class UpdateModelBaseExtensions
	{
		internal static void SetModifiedInfo<TEntity, TKey>(this TEntity entity, UpdateModelBase<TKey> model) where TEntity : new()
		{
			entity.GetType().GetProperty(nameof(model.FechaModificacionRegistro))?.SetValue(entity, model.FechaModificacionRegistro);
			entity.GetType().GetProperty(nameof(model.UsuarioModificacionRegistro))?.SetValue(entity, model.UsuarioModificacionRegistro);
		}

		internal static void SetModifiedInfo<TEntity>(this TEntity entity, NewModelBase model) where TEntity : new()
		{
			entity.GetType().GetProperty("FechaModificacionRegistro")?.SetValue(entity, model.FechaCreacionRegistro);
			entity.GetType().GetProperty("UsuarioModificacionRegistro")?.SetValue(entity, model.UsuarioCreacionRegistro);
		}
	}
}