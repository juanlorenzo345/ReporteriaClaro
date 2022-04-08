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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Tasks.Common
// Info archivo:
//     Nombre: From.cs
//     Fecha creación: 2021/11/25 at 02:46 PM
//     Fecha modificación: 2021/11/25 at 03:15 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

namespace ReporteriaClaro.Tasks.Common.Configuration
{
	public class From
	{
		#region Properties and Indexers

		public string Address
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string Password
		{
			get;
			set;
		}

		public bool RequireAuthentication
		{
			get;
			set;
		}

		#endregion
	}
}