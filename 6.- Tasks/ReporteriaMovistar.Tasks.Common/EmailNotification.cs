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
// Solución/Proyecto: ReporteriaMovistar / ReporteriaMovistar.Tasks.Common
// Info archivo:
//     Nombre: NotificacionCorreo.cs
//     Fecha creación: 2021/11/17 at 08:50 AM
//     Fecha modificación: 2021/11/17 at 09:25 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using ReporteriaMovistar.Tasks.Common.Configuration;

namespace ReporteriaMovistar.Tasks.Common
{
	public class EmailNotification
	{
		#region Fields

		private readonly MailSettings mailSettings;

		#endregion

		#region Constructors

		public EmailNotification(IOptions<MailSettings> mailSettings)
		{
			this.mailSettings = mailSettings.Value;
		}

		#endregion

		#region Methods

		public async Task SendEmailAsync(string logFileName)
		{
			MimeMessage message = new MimeMessage();

			SetFromAddress(message);

			foreach (To receiver in this.mailSettings.To ?? Enumerable.Empty<To>())
			{
				message.To.Add(new MailboxAddress(receiver.Name, receiver.Address));
			}

			message.Subject = this.mailSettings.Subject;

			MultipartAlternative alternative = new MultipartAlternative();
			alternative.Add(CreatePlainContentMessage());
			alternative.Add(CreateHtmlContentMessage());

			Multipart multipart = new Multipart("mixed");
			multipart.Add(alternative);
			multipart.Add(CrearArchivoAdjunto(logFileName));

			message.Body = multipart;

			using (SmtpClient smtpClient = new SmtpClient())
			{
				await ConnectToSmtpAsync(smtpClient);
				await smtpClient.SendAsync(message);
				await smtpClient.DisconnectAsync(true);
			}
		}

		private void SetFromAddress(MimeMessage message)
		{
			string name = this.mailSettings.From.Name;
			string address = this.mailSettings.From.Address;
			message.From.Add(new MailboxAddress(name, address));
		}

		private async Task ConnectToSmtpAsync(SmtpClient smtpClient)
		{
			string host = this.mailSettings.Smtp.Host;
			int port = this.mailSettings.Smtp.Port;
			string username = this.mailSettings.From.Address; ;
			string password = this.mailSettings.From.Password;
			bool requireAuthentication = this.mailSettings.From.RequireAuthentication;
			
			await smtpClient.ConnectAsync(host, port, false);

			if (requireAuthentication)
			{
				await smtpClient.AuthenticateAsync(username, password);
			}
		}

		private MimePart CrearArchivoAdjunto(string fileName)
		{
			return new MimePart("text", "plain")//MimePart("image", "gif")
			{
				//NOTE: Al momento de adjuntar archivo, el log se debe abrir en modo compartido de lectura/escritura, ya que Serilog también lo está leyendo y escribiendo.
				Content = new MimeContent(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), ContentEncoding.Default), //new MimeContent(File.OpenRead(rutaArchivo), ContentEncoding.Default),
				ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
				ContentTransferEncoding = ContentEncoding.Base64,
				FileName = Path.GetFileName(fileName)
			};
		}

		private TextPart CreateHtmlContentMessage()
		{
			return new TextPart("html")
			{
				Text = $"<p style=\"font - family:'Courier New'\">Log del día {DateTime.Today.ToString("dd-MM-yyyy")}.</p>"
			};
		}

		private TextPart CreatePlainContentMessage()
		{
			return new TextPart("plain")
			{
				Text = $@"Log del día {DateTime.Today.ToString("dd-MM-yyyy")}."
			};
		}

		#endregion
	}
}