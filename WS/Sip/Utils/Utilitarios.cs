using ExpertPdf.HtmlToPdf;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Sip.Exceptions;
using Sip.Models.Contracts;
using Sip.Models.Dto;
using Sip.Models.Entities;
using Sip.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;

namespace Sip.Utils
{
    public class PdfParams
    {
        public string Key { get; set; }
        public string Html { get; set; }
        public int DocWithPx { get; set; }
        public int DocHeightPx { get; set; }

    }
    public static class Utilitarios
    {

        public  static StringBuilder Presupuesto(DtoPresupuestoSip presupuesto)
        {
            string _pathB = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["presupuesto"].ToString();
            string _pathPrestadores = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["prestadores_presupuesto"].ToString();

            StreamReader objReader = new StreamReader(_pathB);
            StreamReader objReader2 = new StreamReader(_pathPrestadores);

            string _archivo = objReader.ReadToEnd();
            string _lista_prestadores = objReader2.ReadToEnd();
            string PrestadoresPresupuesto = string.Empty;

            foreach (Models.Entities.Prestador prestador in presupuesto.Prestadores.Where(x => x.COPAGO!=-1))
            {
                PrestadoresPresupuesto = PrestadoresPresupuesto + String.Format(_lista_prestadores, prestador.PRTA_NOMBRE, String.Format("{0:C0}", prestador.COPAGO));
            }

            string tipo_carta = presupuesto.Sip.ISAP_CEMPRESA == "T" ? "Beneficio Cuenta Segura" : "Beneficio Cuenta Conocida";

            _archivo = _archivo.Replace("#!LOGO!#", presupuesto.Sip.ISAP_CEMPRESA == "T" ? "http://www.vidatres.cl/Portals/0/Skins/media/menu/logo.gif" : "http://www.banmedica.cl/portals/0/images/logo-banmedica.png");
            _archivo = _archivo.Replace("#!NOMBRE!#", presupuesto.Sip.AFIL_TNOMBRES + ' ' + presupuesto.Sip.AFIL_TAPELLIDO_PATERNO + ' ' + presupuesto.Sip.AFIL_TAPELLIDO_MATERNO);
            _archivo = _archivo.Replace("#!TIPO_CARTA!#", tipo_carta);
            _archivo = _archivo.Replace("#!PAQU_DESCRIPCION!#", presupuesto.Sip.PAQU_DESCRIPCION);

            _archivo = _archivo.Replace("#!CONTACTO_ISAPRE!#", presupuesto.Sip.ISAP_CEMPRESA == "T" ? "Fonoayuda al 600 600 3535" : "Baninforma al 600 600 3600");
            _archivo = _archivo.Replace("#!PAGINA_ISAPRE!#", presupuesto.Sip.ISAP_CEMPRESA == "T" ? "www.vidatres.cl" : "www.banmedica.cl");
            _archivo = _archivo.Replace("#!LISTA_PRESTADORES!#", PrestadoresPresupuesto);
            StringBuilder sb = new StringBuilder();
            sb.Append(_archivo);

            return sb;
        }


        public static StringBuilder Solicitud(Sip.Models.Entities.Sip solicitud)
        {
            string _pathB = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["solicitud"].ToString();

            StreamReader objReader = new StreamReader(_pathB);

            string _archivo = objReader.ReadToEnd();

            string tipo_carta = solicitud.ISAP_CEMPRESA == "T" ? "Beneficio Cuenta Segura" : "Beneficio Cuenta Conocida";

            _archivo = _archivo.Replace("#!LOGO!#", solicitud.ISAP_CEMPRESA == "T" ? "http://www.vidatres.cl/Portals/0/Skins/media/menu/logo.gif" : "http://www.banmedica.cl/portals/0/images/logo-banmedica.png");
            _archivo = _archivo.Replace("#!NOMBRE!#", solicitud.AFIL_TNOMBRES + ' ' + solicitud.AFIL_TAPELLIDO_PATERNO + ' ' + solicitud.AFIL_TAPELLIDO_MATERNO);
            _archivo = _archivo.Replace("#!TIPO_CARTA!#", tipo_carta);
            _archivo = _archivo.Replace("#!PAQU_DESCRIPCION!#", solicitud.PAQU_DESCRIPCION);

            _archivo = _archivo.Replace("#!CONTACTO_ISAPRE!#", solicitud.ISAP_CEMPRESA == "T" ? "Fonoayuda al 600 600 3535" : "Baninforma al 600 600 3600");
            _archivo = _archivo.Replace("#!PAGINA_ISAPRE!#", solicitud.ISAP_CEMPRESA == "T" ? "www.vidatres.cl" : "www.banmedica.cl");

            _archivo = _archivo.Replace("#!PRESTSIP_NOMBRE_PREST!#", solicitud.PRESTSIP_NOMBRE_PREST);
            _archivo = _archivo.Replace("#!COPAGO!#", String.Format("{0:C0}", solicitud.COPAGO));
            _archivo = _archivo.Replace("#!NOMBRE_ISAPRE!#", solicitud.ISAP_CEMPRESA == "T" ? "ISAPRE VIDA TRES" : "ISAPRE BANMEDICA");

            _archivo = _archivo.Replace("#!ID!#", solicitud.SOLSIP_ID.ToString());
            _archivo = _archivo.Replace("#!FECHA_SOLICITUD!#", solicitud.SOLISIP_FESTADO);

            _archivo = _archivo.Replace("#!RUT_BENEFICIARIO!#", solicitud.CARG_NRUT.ToString());
           // _archivo = _archivo.Replace("#!NOMBRE_BENEFICIARIO!#", solicitud..ToString());

            _archivo = _archivo.Replace("#!RUT_AFILIADO!#", solicitud.AFIL_NRUT.ToString());
            _archivo = _archivo.Replace("#!NOMBRE_AFILIADO!#", solicitud.AFIL_TNOMBRES + " " + solicitud.AFIL_TAPELLIDO_PATERNO + " " + solicitud.AFIL_TAPELLIDO_MATERNO);
            _archivo = _archivo.Replace("#!VIGENCIA_AFILIADO!#", solicitud.INICIOVIGENCIA);
            _archivo = _archivo.Replace("#!PRES_CCOD_PAQUETE!#", solicitud.PRES_CCOD_PAQUETE.ToString());
            _archivo = _archivo.Replace("#!PLAN!#", solicitud.PLSA_CCOD);
            _archivo = _archivo.Replace("#!TRAMO_SIP!#", solicitud.TRAMO);
            _archivo = _archivo.Replace("#!PRESTSIP_NOMBRE_PREST!#", solicitud.PRESTSIP_NOMBRE_PREST);
            _archivo = _archivo.Replace("#!PRESTSIP_DIRWEB!#", solicitud.PRESTSIP_DIRWEB);
            _archivo = _archivo.Replace("#!PRESTSIP_TELEFONO!#", solicitud.PRESTSIP_TELEFONO);
            _archivo = _archivo.Replace("#!PRESTSIP_DIRECCION!#", solicitud.PRESTSIP_DIRECCION);

            //Beneficiario

            var beneficiario = new SipRepository().ObtenerBeneficiarios((int)solicitud.PRESSIP_ID, (int)solicitud.AFIL_NRUT,solicitud.ISAP_CEMPRESA).Where(x => x.RUT == solicitud.CARG_NRUT).FirstOrDefault();
            _archivo = _archivo.Replace("#!NOMBRE_BENEFICIARIO!#", beneficiario.NOMBRE  + " " + beneficiario.APEPAT + " " + beneficiario.APEMAT);
            _archivo = _archivo.Replace("#!EMAIL_BENEFICIARIO!#", beneficiario.EMAIL);
            _archivo = _archivo.Replace("#!TELEFONO_BENEFICIARIO!#", beneficiario.FONO1);
            _archivo = _archivo.Replace("#!CELULAR_BENEFICIARIO!#", beneficiario.CELULAR);
            _archivo = _archivo.Replace("#!VIGENCIA_BENEFICIARIO!#", beneficiario.INICIOVIGENCIA);

            _archivo = _archivo.Replace("#!AGENCIA!#",solicitud.SOLISIP_AGENCIA);
            _archivo = _archivo.Replace("#!NOMBRE_EJECUTIVO!#", solicitud.NOMBRE_EJECUTIVO);
           

            //Staff
            string lista_medicos = string.Empty;

            var staff = new SipRepository().ObtenerStaffMedico((int)solicitud.PRESTSIP_ID, (int)solicitud.PRESSIP_ID, solicitud.ISAP_CEMPRESA);
            foreach(Staff medico in staff)
            {
                lista_medicos = lista_medicos + medico.STPREST_NOMBRE_PRES + ',';
            }

            _archivo = _archivo.Replace("#!STAFF!#", lista_medicos);


            StringBuilder sb = new StringBuilder();
            sb.Append(_archivo);

            return sb;
        }

        public static StringBuilder CopiaPrestador(Sip.Models.Entities.Sip solicitud)
        {
            string _pathB = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["copiaprestador"].ToString();

            StreamReader objReader = new StreamReader(_pathB);

            string _archivo = objReader.ReadToEnd();

            string tipo_carta = solicitud.ISAP_CEMPRESA == "T" ? "Beneficio Cuenta Segura" : "Beneficio Cuenta Conocida";

            _archivo = _archivo.Replace("#!LOGO!#", solicitud.ISAP_CEMPRESA == "T" ? "http://www.vidatres.cl/Portals/0/Skins/media/menu/logo.gif" : "http://www.banmedica.cl/portals/0/images/logo-banmedica.png");
            _archivo = _archivo.Replace("#!NOMBRE!#", solicitud.AFIL_TNOMBRES + ' ' + solicitud.AFIL_TAPELLIDO_PATERNO + ' ' + solicitud.AFIL_TAPELLIDO_MATERNO);
            _archivo = _archivo.Replace("#!TIPO_CARTA!#", tipo_carta);
            _archivo = _archivo.Replace("#!PAQU_DESCRIPCION!#", solicitud.PAQU_DESCRIPCION);

            _archivo = _archivo.Replace("#!CONTACTO_ISAPRE!#", solicitud.ISAP_CEMPRESA == "T" ? "Fonoayuda al 600 600 3535" : "Baninforma al 600 600 3600");
            _archivo = _archivo.Replace("#!PAGINA_ISAPRE!#", solicitud.ISAP_CEMPRESA == "T" ? "www.vidatres.cl" : "www.banmedica.cl");

            _archivo = _archivo.Replace("#!PRESTSIP_NOMBRE_PREST!#", solicitud.PRESTSIP_NOMBRE_PREST);
            _archivo = _archivo.Replace("#!COPAGO!#", String.Format("{0:C0}", solicitud.COPAGO));
            _archivo = _archivo.Replace("#!NOMBRE_ISAPRE!#", solicitud.ISAP_CEMPRESA == "T" ? "ISAPRE VIDA TRES" : "ISAPRE BANMEDICA");

            _archivo = _archivo.Replace("#!ID!#", solicitud.SOLSIP_ID.ToString());
            _archivo = _archivo.Replace("#!FECHA_SOLICITUD!#", solicitud.SOLISIP_FESTADO);

            _archivo = _archivo.Replace("#!RUT_BENEFICIARIO!#", solicitud.CARG_NRUT.ToString());
            // _archivo = _archivo.Replace("#!NOMBRE_BENEFICIARIO!#", solicitud..ToString());

            _archivo = _archivo.Replace("#!RUT_AFILIADO!#", solicitud.AFIL_NRUT.ToString());
            _archivo = _archivo.Replace("#!NOMBRE_AFILIADO!#", solicitud.AFIL_TNOMBRES + " " + solicitud.AFIL_TAPELLIDO_PATERNO + " " + solicitud.AFIL_TAPELLIDO_MATERNO);
            _archivo = _archivo.Replace("#!VIGENCIA_AFILIADO!#", solicitud.INICIOVIGENCIA);
            _archivo = _archivo.Replace("#!PRES_CCOD_PAQUETE!#", solicitud.PRES_CCOD_PAQUETE.ToString());
            _archivo = _archivo.Replace("#!PLAN!#", solicitud.PLSA_CCOD);
            _archivo = _archivo.Replace("#!TRAMO_SIP!#", solicitud.TRAMO);
            _archivo = _archivo.Replace("#!PRESTSIP_NOMBRE_PREST!#", solicitud.PRESTSIP_NOMBRE_PREST);
            _archivo = _archivo.Replace("#!PRESTSIP_DIRWEB!#", solicitud.PRESTSIP_DIRWEB);
            _archivo = _archivo.Replace("#!PRESTSIP_TELEFONO!#", solicitud.PRESTSIP_TELEFONO);
            _archivo = _archivo.Replace("#!PRESTSIP_DIRECCION!#", solicitud.PRESTSIP_DIRECCION);

            //Beneficiario

            var beneficiario = new SipRepository().ObtenerBeneficiarios((int)solicitud.PRESSIP_ID, (int)solicitud.AFIL_NRUT, solicitud.ISAP_CEMPRESA).Where(x => x.RUT == solicitud.CARG_NRUT).FirstOrDefault();
            _archivo = _archivo.Replace("#!NOMBRE_BENEFICIARIO!#", beneficiario.NOMBRE + " " + beneficiario.APEPAT + " " + beneficiario.APEMAT);
            _archivo = _archivo.Replace("#!EMAIL_BENEFICIARIO!#", beneficiario.EMAIL);
            _archivo = _archivo.Replace("#!TELEFONO_BENEFICIARIO!#", beneficiario.FONO1);
            _archivo = _archivo.Replace("#!CELULAR_BENEFICIARIO!#", beneficiario.CELULAR);
            _archivo = _archivo.Replace("#!VIGENCIA_BENEFICIARIO!#", beneficiario.INICIOVIGENCIA);

            _archivo = _archivo.Replace("#!AGENCIA!#", solicitud.SOLISIP_AGENCIA);
            _archivo = _archivo.Replace("#!NOMBRE_EJECUTIVO!#", solicitud.NOMBRE_EJECUTIVO);

            


            //Staff
            string lista_medicos = string.Empty;

            var staff = new SipRepository().ObtenerStaffMedico((int)solicitud.PRESTSIP_ID, (int)solicitud.PRESSIP_ID, solicitud.ISAP_CEMPRESA);
            foreach (Staff medico in staff)
            {
                lista_medicos = lista_medicos + medico.STPREST_NOMBRE_PRES + ',';
            }

            _archivo = _archivo.Replace("#!STAFF!#", lista_medicos);


            StringBuilder sb = new StringBuilder();
            sb.Append(_archivo);

            return sb;
        }

        public static byte[] GetBytesFromHtmlString(PdfParams param)
        {
            PdfConverter conversor;

            //int htmlDocWidthPx = param.DocWithPx;
            //int htmlDocHeightPx = param.DocHeightPx;

            //if (htmlDocWidthPx != 0)
            //{
            //    conversor = new PdfConverter(htmlDocWidthPx, htmlDocHeightPx);
            //}
            //else
            //{
            conversor = new PdfConverter();
            //}



            // set the license key - required
            if (param.Key != "") { conversor.LicenseKey = param.Key; }

            //// set the converter options - optional
            conversor.PdfDocumentOptions.PdfPageSize = PdfPageSize.Letter;
            //conversor.PageHeight = 0;
            //conversor.PageWidth = 0;
            //conversor.PdfDocumentOptions.PdfCompressionLevel = PdfCompressionLevel.Normal;
            conversor.PdfDocumentOptions.PdfPageOrientation = PDFPageOrientation.Portrait;

            //conversor.PdfDocumentOptions.FitHeight = true;
            //conversor.PdfDocumentOptions.FitWidth = true;
            //// set if header and footer are shown in the PDF - optional - default is false 
            //conversor.PdfDocumentOptions.ShowHeader = false;
            //conversor.PdfDocumentOptions.ShowFooter = false;

            ////set the PDF document margins
            conversor.PdfDocumentOptions.LeftMargin = 10;
            conversor.PdfDocumentOptions.RightMargin = 10;
            conversor.PdfDocumentOptions.TopMargin = 10;
            conversor.PdfDocumentOptions.BottomMargin = 10;

            //// set to generate a pdf with selectable text or a pdf with embedded image - optional - default is true
            //conversor.PdfDocumentOptions.GenerateSelectablePdf = true;

            //// set if the HTML content is resized if necessary to fit the PDF page width - optional - default is true
            //conversor.PdfDocumentOptions.FitWidth = false;

            //// set the embedded fonts option - optional - default is false
            //conversor.PdfDocumentOptions.EmbedFonts = false;

            //// set the live HTTP links option - optional - default is true
            //conversor.PdfDocumentOptions.LiveUrlsEnabled = false;

            //if (conversor.PdfDocumentOptions.GenerateSelectablePdf)
            //{
            //    // set if the JavaScript is enabled during conversion to a PDF with selectable text 
            //    // - optional - default is false
            //    conversor.ScriptsEnabled = false;
            //    // set if the ActiveX controls (like Flash player) are enabled during conversion 
            //    // to a PDF with selectable text - optional - default is false
            //    conversor.ActiveXEnabled = false;
            //}
            //else
            //{
            //    // set if the JavaScript is enabled during conversion to a PDF with embedded image 
            //    // - optional - default is true
            //    conversor.ScriptsEnabledInImage = true;
            //    // set if the ActiveX controls (like Flash player) are enabled during conversion 
            //    // to a PDF with embedded image - optional - default is true
            //    conversor.ActiveXEnabledInImage = true;
            //}

            //// set if the images in PDF are compressed with JPEG to reduce the PDF document size - optional - default is true
            //conversor.PdfDocumentOptions.JpegCompressionEnabled = false;

            //set PDF document description - optional
            //if (isapre == "B")
            //  conversor.PdfDocumentInfo.AuthorName = "Isapre Banmédica";
            //else
            //    conversor.PdfDocumentInfo.AuthorName = "Isapre VidaTres";

            // Performs the conversion and get the pdf document bytes that you can further 
            // save to a file or send as a browser response
            return conversor.GetPdfBytesFromHtmlString(param.Html);
        }

        public static string GetMailPrestador(int prestador, string isapre)
        {
            var mails= new SipRepository().ObtenerMailPrestador(prestador, isapre).Where(x=>x.MAPRES_XESTADO=="V");
            var mailsPrestadores = mails.Aggregate(string.Empty, (current, mail) => current + mail.MAPRES_TCORREO + ';');

            return mailsPrestadores.TrimEnd(';'); 
        }

        public static string Desencripta(string id)
        {

            var decoded = Convert.FromBase64String(id.Replace("-", "+").Replace("%", "/"));
            var key = ConfigurationManager.AppSettings["key_encripta"];
            var result = new byte[decoded.Length];

            for (int c = 0; c < decoded.Length; c++)
            {
                result[c] = (byte) (decoded[c] ^ (uint) key[c%key.Length]);
            }

            var buffer = Convert.FromBase64String(Encoding.UTF8.GetString(result));
            return Encoding.UTF8.GetString(buffer);
        }

        public static byte[] WaterMark(byte[] bytes, string texto)
        {

            using (var ms = new MemoryStream(10 * 1024))
            {
                using (var reader = new PdfReader(bytes))
                using (var stamper = new PdfStamper(reader, ms))
                {
                    var bf = BaseFont.CreateFont(@"c:\windows\fonts\arial.ttf", BaseFont.CP1252, true);

                    var times = reader.NumberOfPages;
                    for (var i = 1; i <= times; i++)
                    {
                        var dc = stamper.GetOverContent(i);
                        AddWaterMark(dc, texto, bf, 10, 90, new BaseColor(255, 0, 0), reader.GetPageSizeWithRotation(i));
                    }
                    stamper.Close();
                }
                return ms.ToArray();
            }


        }


        private static void AddWaterMark(PdfContentByte dc, string text, BaseFont font, float fontSize, float angle, BaseColor color, Rectangle realPageSize, Rectangle rect = null)
        {
            //  var gstate = new PdfGState { FillOpacity = 0.1f, StrokeOpacity = 0.3f };
            dc.SaveState();
            // dc.SetGState(gstate);
            dc.SetColorFill(color);
            dc.BeginText();
            dc.SetFontAndSize(font, fontSize);
            var ps = rect ?? realPageSize; /*dc.PdfDocument.PageSize is not always correct*/
            var x = 20; //(ps.Right + ps.Left) / 2;
            var y = ps.Bottom + 300;// (ps.Bottom + ps.Top) / 2;
            dc.ShowTextAligned(Element.ALIGN_LEFT, text, x, y, angle);
            dc.EndText();
            dc.RestoreState();
        }
    
    
    }

    public static class Mail
    {

        public static string To { get; set; }
        public static string From { get; set; }
        public static string Subject { get; set; }
        public static string Body { get; set; }
        public static Stream File { get; set; }

        public static void Send()
        {


            Attachment data = new Attachment(File,"solicitud.pdf", MediaTypeNames.Application.Pdf);
            ContentDisposition disposition = data.ContentDisposition;
            disposition.CreationDate = DateTime.Now;
            disposition.ModificationDate = DateTime.Today;
            disposition.ReadDate = DateTime.Today; 
			// Add time stamp information for the file.
			// Add the file attachment to this e-mail message.




            MailMessage email = new MailMessage();

            string[] copiaMail = To.Split(';');
            for (int i = 0; i <= copiaMail.Count() - 1;i++ )
            {
                email.To.Add(new MailAddress(copiaMail[i]));
            }

            email.From = new MailAddress(From);
            email.Subject = Subject;
            email.Attachments.Add(data);
            email.Body = Body;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["smtp"].ToString();
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"].ToString());
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;


            try
            {
                smtp.Send(email);
                email.Dispose();
            }
            catch (Exception ex)
            {
                throw new SipException(ex.Message);
            }
        }
    }

    
}