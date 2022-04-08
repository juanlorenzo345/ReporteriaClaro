﻿#region Header
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
//     Nombre: Mail.cs
//     Fecha creación: 2021/11/25 at 01:41 PM
//     Fecha modificación: 2021/11/25 at 03:15 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Collections.Generic;

namespace ReporteriaClaro.Tasks.Common.Configuration
{
	public class MailSettings
	{
		#region Properties and Indexers

		public From From
		{
			get;
			set;
		}

		public Smtp Smtp
		{
			get;
			set;
		}

		public string Subject
		{
			get;
			set;
		}

		public To[] To
		{
			get;
			set;
		}

		#endregion
	}
}