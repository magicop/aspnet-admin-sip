using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Configuration;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using WebAdminSIP.Models.DTO;

namespace WebAdminSIP
{
    public class Utils
    {
        public static string Capitalize(string p)
        {
            var result = p;
            if (!string.IsNullOrEmpty(p))
            {
                if (result.Contains(" "))
                {
                    string[] pedazos = result.Split(' ');
                    result = "";
                    foreach (var item in pedazos)
                    {
                        if (item != "")
                        {
                            var tmp = "";
                            tmp = item.ToLowerInvariant().Substring(1);
                            result += item[0].ToString().ToUpperInvariant();
                            result += tmp;
                            result += " ";
                        }
                    }
                    result = result.Trim();
                }
                else
                {
                    if (p != null)
                        if (p.Length > 0)
                        {
                            var tmp = "";
                            tmp = p.ToLowerInvariant().Substring(1);
                            result = p[0].ToString().ToUpperInvariant();
                            result += tmp;
                        }
                }
            }
            return result;
        }

        public static string formatoRut(string rut)
        {
            if (!string.IsNullOrEmpty(rut))
            {
                var aux = Convert.ToInt32(rut);
                var suma = 0;
                var multiplicador = 1;
                var dv = string.Empty;
                while (aux != 0)
                {
                    multiplicador++;
                    if (multiplicador == 8)
                        multiplicador = 2;
                    suma += (aux % 10) * multiplicador;
                    aux = aux / 10;
                }
                suma = 11 - (suma % 11);
                if (suma == 11) dv = "0";
                else if (suma == 10) dv = "K";
                else dv = suma.ToString();

                rut = Convert.ToDouble(rut).ToString("N0") + "-" + dv;
            }

            return rut;
        }

        public static dynamic getServiceRest(string url, string parametros)
        {
            var WebReq = (HttpWebRequest)WebRequest.Create(string.Format(url + "/{0}", parametros));
            WebReq.Method = "GET";

            var WebResp = (HttpWebResponse)WebReq.GetResponse();

            var Answer = WebResp.GetResponseStream();
            var _Answer = new StreamReader(Answer);
            return JsonConvert.DeserializeObject(_Answer.ReadToEnd());
        }

        public static dynamic getServiceRest(string url, string parametros, string usuario, string contrasena)
        {
            var WebReq = (HttpWebRequest)WebRequest.Create(string.Format(url + "/{0}", parametros));
            WebReq.Method = "GET";
            WebReq.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(usuario + ":" + contrasena));

            var WebResp = (HttpWebResponse)WebReq.GetResponse();

            var Answer = WebResp.GetResponseStream();
            var _Answer = new StreamReader(Answer);

            return JsonConvert.DeserializeObject(_Answer.ReadToEnd());
        }

        public static dynamic postServiceRest(string url, string parametros, string usuario, string contrasena)
        {
            var WebReq = (HttpWebRequest)WebRequest.Create(string.Format(url + "/{0}", parametros));
            WebReq.Method = "POST";
            WebReq.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(usuario + ":" + contrasena));
            WebReq.ContentType = "application/json";
            WebReq.Expect = "application/json";
            WebReq.ContentLength = 0;

            var WebResp = (HttpWebResponse)WebReq.GetResponse();

            var Answer = WebResp.GetResponseStream();
            var _Answer = new StreamReader(Answer);

            return JsonConvert.DeserializeObject(_Answer.ReadToEnd());
        }

        public static dynamic postServiceRestJson(string url, string objJson, string usuario, string contrasena)
        {
            var WebReq = (HttpWebRequest)WebRequest.Create(url);
            var data = Encoding.UTF8.GetBytes(objJson);
            WebReq.Method = "POST";
            WebReq.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(usuario + ":" + contrasena));
            WebReq.ContentType = "application/json";
            WebReq.Expect = "application/json";
            WebReq.ContentLength = 0;
            WebReq.PreAuthenticate = true;

            WebReq.ContentLength = data.Length;

            Stream postStream = WebReq.GetRequestStream();
            postStream.Write(data, 0, data.Length);
            postStream.Close();

            var httpResponse = (HttpWebResponse)WebReq.GetResponse();
            object result = null;

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = JsonConvert.DeserializeObject(streamReader.ReadToEnd());
                }
            }

            return result;
        }

        public static int convertirRutaInteger(string rutConPuntosyGuion)
        {
            var rutInteger = 0;

            if (!string.IsNullOrEmpty(rutConPuntosyGuion))
            {
                if (rutConPuntosyGuion.Contains(".") || rutConPuntosyGuion.Contains("-"))
                {
                    string rutSinPuntos = rutConPuntosyGuion.Replace(".", string.Empty);
                    string rutSinGuionniPuntos = rutSinPuntos.Replace("-", string.Empty);

                    //Retorna rut sin guión ni puntos en formato int
                    rutInteger = Convert.ToInt32(rutSinGuionniPuntos.Remove(rutSinGuionniPuntos.Length - 1, 1));
                }
                else rutInteger = Convert.ToInt32(rutConPuntosyGuion);
            }
            return rutInteger;
        }

        public static string ConstruirFecha()
        {
            var result = "";
            result = DateTime.Now.Day.ToString();
            result += " de ";
            result += TraducirMes(DateTime.Now.Month);
            result += " de ";
            result += DateTime.Now.Year.ToString();
            return result;
        }

        public static string TraducirMes(int mes)
        {
            var result = "";
            switch (mes)
            {
                case 1:
                    result = "Enero";
                    break;
                case 2:
                    result = "Febrero";
                    break;
                case 3:
                    result = "Marzo";
                    break;
                case 4:
                    result = "Abril";
                    break;
                case 5:
                    result = "Mayo";
                    break;
                case 6:
                    result = "Junio";
                    break;
                case 7:
                    result = "Julio";
                    break;
                case 8:
                    result = "Agosto";
                    break;
                case 9:
                    result = "Septiembre";
                    break;
                case 10:
                    result = "Octubre";
                    break;
                case 11:
                    result = "Noviembre";
                    break;
                case 12:
                    result = "Diciembre";
                    break;
                default:
                    break;
            }
            return result;
        }

        public static string formatoPeriodoCotizaciones(string periodo)
        {
            try
            {
                var mes = periodo.Remove(0, 4);
                var ano = periodo.Remove(4, 2);

                return TraducirMes(Convert.ToInt32(mes)) + ", " + ano;
            }
            catch
            {
                return periodo;
            }
        }

        public static string formatoPeso(string monto)
        {
            try
            {
                return "$ " + Convert.ToDouble(monto).ToString("N0");
            }
            catch
            {
                return "$ " + monto;
            }
        }

        public static string NullToString(string value)
        {
            return string.IsNullOrEmpty(value) ? "null" : value;
        }

        public static string NullToDateTime(string value)
        {
            return (value == null) ? "null" : value.Replace("/", "_S_");
        }

        public static string TransformaCaracter(string palabra)
        {
            palabra = palabra.ToString().Replace(".", "SIGNOPUNTO");

            return palabra;
        }

        public static string codeHTML(string Url)
        {
            var myRequest = (HttpWebRequest)WebRequest.Create(Url);
            myRequest.Method = "GET";
            var myResponse = myRequest.GetResponse();
            var sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            var result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();

            return result;
        }

        public static void borraAdjunto(int rutAfil)
        {
            if (ConfigurationManager.AppSettings["BorrarArchivosServidor"].ToString() == "si")
            {
                string directorio = string.Format("{0}{1}\\", ConfigurationManager.AppSettings["RutaDocumentos"], rutAfil).Replace("//", "\\");

                if (Directory.Exists(directorio)) Directory.Delete(directorio, true);
            }
        }

        public static string EstadoPago(int estado)
        {
            var result = "";
            switch (estado)
            {
                case 1:
                    result = "No autorizado";
                    break;
                case 2:
                    result = "No procesado";
                    break;
                case 3:
                    result = "Rechazado";
                    break;
                case 4:
                    result = "Error interno";
                    break;
                case 5:
                    result = "Pago exitoso";
                    break;
                default:
                    break;
            }
            return result;
        }

        public static int EstadoPagoViceversa(string estado)
        {
            var result = 0;
            switch (estado)
            {
                case "NoAutorizado":
                    result = 1;
                    break;
                case "NoProcesado":
                    result = 2;
                    break;
                case "Rechazado":
                    result = 3;
                    break;
                case "ErrorInterno":
                    result = 4;
                    break;
                case "PagoExitoso":
                    result = 5;
                    break;
                default:
                    break;
            }
            return result;
        }

        public static string IsaprePago(int isapre)
        {
            var result = "";
            switch (isapre)
            {
                case 1:
                    result = "Banmédica";
                    break;
                case 2:
                    result = "Vida Tres";
                    break;
                default:
                    break;
            }
            return result;
        }

        public static int IsaprePagoViceversa(string isapre)
        {
            var result = 0;
            switch (isapre)
            {
                case "Banmédica":
                    result = 1;
                    break;
                case "Vida Tres":
                    result = 2;
                    break;
                default:
                    break;
            }
            return result;
        }

        public static string TipoPagos(int tipopago)
        {
            var result = "";
            switch (tipopago)
            {
                case 1:
                    result = "Pago de cotización";
                    break;
                case 2:
                    result = "Compra de bonos";
                    break;
                case 3:
                    result = "Pago de deuda";
                    break;
                case 4:
                    result = "Folio de negociación";
                    break;
                case 5:
                    result = "Compra de bonos GES";
                    break;
                case 6:
                    result = "Compra de bonos APP Mobile BM";
                    break;
                case 7:
                    result = "Pago de bono PAM";
                    break;
                case 8:
                    result = "Compra de bonos APP Mobile VT";
                    break;
                case 9:
                    result = "Compra de bonos Vida Integra BM";
                    break;
                case 10:
                    result = "Compra de bonos Vida Integra VT";
                    break;
                case 11:
                    result = "Compra de bonos GES Web";
                    break;
                case 12:
                    result = "Compra de bonos WEB Cotizador exámenes";
                    break;
                case 13:
                    result = "Compra de bonos GES Web exámenes";
                    break;
                default:
                    break;
            }
            return result;
        }

        public static int TipoPagosViceversa(string tipopago)
        {
            var result = 0;
            switch (tipopago)
            {
                case "Cotizacion":
                    result = 1;
                    break;
                case "CompraBonos":
                    result = 2;
                    break;
                case "PagoDeuda":
                    result = 3;
                    break;
                case "FolioNegociación":
                    result = 4;
                    break;
                case "BonoGES":
                    result = 5;
                    break;
                case "BonosAPPMobileBM":
                    result = 6;
                    break;
                case "PagoBonoPAM":
                    result = 7;
                    break;
                case "BonosAPPMobileVT":
                    result = 8;
                    break;
                case "BonosVidaIntegraBM":
                    result = 9;
                    break;
                case "BonosVidaIntegraVT":
                    result = 10;
                    break;
                case "BonosGESWeb":
                    result = 11;
                    break;
                case "BonosWEBCotizadorExamen":
                    result = 12;
                    break;
                case "BonosGESWebExamen":
                    result = 13;
                    break;
                default:
                    break;
            }

            return result;
        }

        public static int MedioPagoViceversa(string mediopago)
        {
            var result = 0;
            switch (mediopago)
            {
                case "WebPay":
                    result = 1;
                    break;
                case "Servipag":
                    result = 2;
                    break;
                case "CuentaExcedente":
                    result = 3;
                    break;
                case "CuentaCorriente":
                    result = 4;
                    break;
                case "Costo0":
                    result = 5;
                    break;
                default:
                    break;
            }
            return result;
        }

    }
}