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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Application.Models
// Info archivo:
//     Nombre: File.cs
//     Fecha creación: 2021/11/18 at 01:01 PM
//     Fecha modificación: 2021/11/18 at 01:01 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

namespace ReporteriaClaro.Application.Models.Output
{
	public class FileResult
	{
		public string Extension
		{
			get;
			init;
		}

		public string Name
		{
			get;
			init;
		}

		public string FullName
		{
			get
			{
				return $"{Name}.{Extension}";
			}
		}

		public byte[] Content
		{
			get;
			init;
		}
	}
}