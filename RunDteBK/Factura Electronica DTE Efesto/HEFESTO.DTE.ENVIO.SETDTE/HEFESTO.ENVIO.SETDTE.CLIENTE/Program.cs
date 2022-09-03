using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using HEFESTO.DTE.AUTENTICACION;
using HEFESTO.DTE.AUTENTICACION.ENT;


namespace HEFESTO.ENVIO.SETDTE.CLIENTE
{
    class Program
    {
        static void Main(string[] args)
        {

            ////
            //// Parametros
            string cn = ConfigurationManager.AppSettings["CN"].ToString(); 
            string pRutEmisor = ConfigurationManager.AppSettings["RutEmisor"].ToString(); 
            string pDigEmisor = ConfigurationManager.AppSettings["DigEmisor"].ToString();
            string pRutEmpresa = ConfigurationManager.AppSettings["RutEmpresa"].ToString();
            string pDigEmpresa = ConfigurationManager.AppSettings["DigEmpresa"].ToString();
            string pIN = ConfigurationManager.AppSettings["IN"].ToString();
            string pOUT = ConfigurationManager.AppSettings["OUT"].ToString();
            string pERROR = ConfigurationManager.AppSettings["ERROR"].ToString();


            ////
            //// Defina el ambiente a utilizar
            SIIAmbiente ambiente = SIIAmbiente.Certificacion;


            ////
            //// Recupere los archivos a enviar
            string[] archivos = Directory.GetFiles(pIN, "*.xml");
            if (archivos != null && archivos.Count() > 0)
            {

                ////
                //// Inicie el envio de los archivos
                foreach (string archivo in archivos)
                {

                    ////
                    //// Conectarse al SII y recuperar el token
                    Respuesta respuesta = LOGIN.Conectar(cn, ambiente);
                    if (respuesta.correcto)
                    {

                        ////
                        //// Envie los documentos
                        string token = (string)respuesta.Resultado;
                        Respuesta respuestaEnvio = HEFESTO.DTE.AUTENTICACION.ENVIO.EnviarArchivoSII(archivo, token, pRutEmisor, pDigEmisor, pRutEmpresa, pDigEmpresa, ambiente);
                        Console.WriteLine(respuestaEnvio.mensaje);


                        ////
                        //// Si el proceso es correcto
                        if (respuestaEnvio.correcto)
                        {

                            ////
                            //// Traslade el archivo enviado a la carpeta de salida
                            string fecha = DateTime.Now.ToString("yyyyMMddHHmmss");
                            string folderName = string.Format("ID {0}-{1}-{2}", (string)respuestaEnvio.Resultado, fecha, Path.GetFileNameWithoutExtension(archivo));
                            folderName = Path.Combine(pOUT, folderName);

                            ////
                            //// Cree el directorio si es necesario
                            if (Directory.Exists(folderName))
                                Directory.Delete(folderName);
                            Directory.CreateDirectory(folderName);

                            ////
                            //// Guarde el archivo donde corresponde
                            folderName = Path.Combine(folderName, Path.GetFileName(archivo));
                            if (File.Exists(folderName))
                                File.Delete(folderName);
                            File.Copy(archivo, folderName);


                        }
                        else
                        {

                            ////
                            //// Traslade el archivo enviado a la carpeta de salida
                            string fecha = DateTime.Now.ToString("yyyyMMddHHmmss");
                            string folderName = string.Format("ERROR {0} {1}", fecha, Path.GetFileNameWithoutExtension(archivo));
                            folderName = Path.Combine(pERROR, folderName);

                            ////
                            //// Cree el directorio si es necesario
                            if (Directory.Exists(folderName))
                                Directory.Delete(folderName);
                            Directory.CreateDirectory(folderName);

                            ////
                            //// Guarde el archivo donde corresponde
                            folderName = Path.Combine(folderName, Path.GetFileName(archivo));
                            if (File.Exists(folderName))
                                File.Delete(folderName);
                            File.Copy(archivo, folderName);                        
                        
                        
                        
                        }

                        ////
                        //// Finalemente elimine el archivo original
                        File.Delete(archivo);

                    }
                
                }
            
            }

            Console.ReadKey();
        }

    }
}
