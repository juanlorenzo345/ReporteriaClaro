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
//     Nombre: DeleteModelBaseExtensions.cs
//     Fecha creación: 2021/11/02 at 04:14 PM
//     Fecha modificación: 2021/11/02 at 04:14 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Linq;
using System.Reflection;
using ReporteriaClaro.Application.Models.Input.Delete;

namespace ReporteriaClaro.Infrastructure.Business.Extensions
{
	internal static class DeleteModelBaseExtensions
	{
		internal static void SetDeletedInfo<TEntity, TKey>(this TEntity entity, DeleteModelBase<TKey> model) where TEntity : new()
		{
			entity.GetType().GetProperty(nameof(model.FechaEliminacionRegistro))?.SetValue(entity, model.FechaEliminacionRegistro);
			entity.GetType().GetProperty(nameof(model.UsuarioEliminacionRegistro))?.SetValue(entity, model.UsuarioEliminacionRegistro);
			entity.GetType().GetProperty(nameof(model.Activo))?.SetValue(entity, model.Activo);
		}
	}
}