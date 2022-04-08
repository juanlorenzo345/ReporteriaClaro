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
//     Nombre: CsvFileHandler.cs
//     Fecha creación: 2021/11/19 at 01:18 PM
//     Fecha modificación: 2021/11/19 at 01:18 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace ReporteriaClaro.Infrastructure.Business.Csv
{
	internal class CsvFileHandler
	{
		/// <summary>
		/// Obtiene un arreglo con los alias de los tipos en español.
		/// </summary>
		private static readonly Dictionary<Type, string> TypeAliasesSpanish = new Dictionary<Type, string>()
		{
			{ typeof(short), "número entero corto" },
			{ typeof(ushort), "número entero corto positivo" },
			{ typeof(int), "número entero" },
			{ typeof(uint), "número entero positivo" },
			{ typeof(long), "número entero largo" },
			{ typeof(ulong), "número entero largo positivo" },
			{ typeof(float), "número decimal" },
			{ typeof(double), "número decimal" },
			{ typeof(decimal), "número decimal" },
			{ typeof(bool), "booleano" },
			{ typeof(char), "caracter" },
			{ typeof(string), "texto" }
		};

		private const string Delimiter = ";";

		private const bool HasHeaderRow = true;

		private readonly Encoding fileEncoding;

		internal CsvFileHandler()
		{
			this.fileEncoding = Encoding.Latin1;
		}

		internal async Task<byte[]> GetExampleAsync<T>()
		{
			List<T> example = new List<T>(0);
			await using (MemoryStream memory = new MemoryStream())
			{
				await using (StreamWriter writer = new StreamWriter(memory, this.fileEncoding))
				{
					await using (CsvWriter csvWriter = new CsvWriter(writer, new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = Delimiter, Encoding = this.fileEncoding, HasHeaderRecord = HasHeaderRow }))
					{
						 await csvWriter.WriteRecordsAsync(example);
					}
				}
				return memory.ToArray();
			}
		}

		internal List<T> GetFileContent<T>(Stream stream)
		{
			stream.Seek(0, SeekOrigin.Begin);

			using (StreamReader reader = new StreamReader(stream, this.fileEncoding))
			{
				using (CsvReader csvReader = new CsvReader(reader, new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = Delimiter, Encoding = this.fileEncoding, HasHeaderRecord = HasHeaderRow }))
				{
					List<T> records = csvReader.GetRecords<T>().ToList();
					return records;
				}
			}
		}

		internal static string GetAliasType(MemberMapData memberMapData)
		{
			Type type = memberMapData.Type;
			return TypeAliasesSpanish.ContainsKey(Nullable.GetUnderlyingType(type) ?? type)
			? TypeAliasesSpanish[Nullable.GetUnderlyingType(type) ?? type]
			: type.Name;
		}
	}
}