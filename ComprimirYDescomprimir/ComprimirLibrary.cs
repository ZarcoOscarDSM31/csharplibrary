using System;
using System.IO.Compression;
using System.IO;
using System.Collections.Generic;


namespace ComprimirYDescomprimir
{

    public class ComprimirLibrary
    {

        Messages ShowMessage();
        //ENCAPSULAMIENTO
            //codeError = 0 si todo salio bien
            //codeError = 1 si la carpeta no existe
            //codeError = 2 si el archivo .zip ya existe
            //codeError = 3 si el archivo .zip no se pudo crear
        int codeError = 0;
        string messageError = string.Empty;
        public string MessageError { get => messageError; set => messageError = value; }
        public int CodeError { get => codeError; set => codeError = value; }

        

        /* public void ShowMessage()
        {
            switch (codeError)
            {
                case 0:
                    Console.WriteLine("El proceso se realizó correctamente.");
                    break;
                case 1:
                    Console.WriteLine("La carpeta especificada no existe.");
                    break;
                default:
                    break;
            }
        } */

        public ComprimirLibrary()
        {
            codeError = 0;
            messageError = "";
        }



        public void ZipFolder(string carpeta, string archivoComprimido)
        {
            if (!Directory.Exists(carpeta))
            {
                CodeError = 1;
                MessageError = "No existe.";
                return;
            }

            if (File.Exists(archivoComprimido))
            {
                CodeError = 2;
                MessageError = "El archivo comprimido ya existe.";
                return;
            }

            try
            {
                ZipFile.CreateFromDirectory(carpeta, archivoComprimido);
                CodeError = 0;
                MessageError = "La compresión se realizó correctamente.";
            }
            catch (Exception ex)
            {
                CodeError = 3;
                MessageError = "Error al comprimir la carpeta: " + ex.Message;
            }
        }



        public void UnZip(string archivoComprimido, string carpetaDestino)
        {
            if (File.Exists(archivoComprimido))
            {
                CodeError = 2;
                MessageError = "El archivo comprimido ya existe.";
                return;
            }

            try
            {
                ZipFile.ExtractToDirectory(archivoComprimido, carpetaDestino);
                CodeError = 0;
                MessageError = string.Empty;

            }
            catch (Exception ex)
            {
                CodeError = 3;
                MessageError = "Error al descomprimir la carpeta: " + ex.Message;
            }
        }



        public void ZipList(List<string> archivos, string archivoComprimidoLista)
        {
            if (archivos.Count == 0)
            {
                CodeError = 1;
                MessageError = "La lista de archivos esta vacia.";
                return;
            }
            foreach (string archivo in archivos)
            {
                if (Directory.GetFiles(archivo).Length == 0)
                {
                    CodeError = 1;
                    MessageError = "La carpeta está vacia.";
                    return;
                }
            }


            try
            {
                using (ZipArchive zip = ZipFile.Open(archivoComprimidoLista, ZipArchiveMode.Create)) 
                {
                    foreach (string archivo in archivos)
                    {
                        if (Directory.Exists(archivo))
                        {
                            DirectoryInfo di = new DirectoryInfo(archivo);
                            foreach (FileInfo file in di.GetFiles())
                            {
                                zip.CreateEntryFromFile(file.FullName, Path.Combine(di.Name, file.Name));
                            }
                        }
                    }
                }
            } catch (Exception ex)
            {
                CodeError = 3;
                MessageError = ex.Message;
            }
        }
    }
}



/*  G U Í A    P A R A    R E P A S A R    Y    E S T U D I A R

using (ZipArchive zip = ZipFile.Open(archivoComprimidoLista, ZipArchiveMode.Create))            // Abre un archivo ZIP para escritura y asegura que se cierre correctamente al finalizar (Para esto es el using; se puede usar también el Dispose)
{
    foreach (string archivo in archivos)                                                        // Recorre cada elemento en la lista de archivos
    {
        if (Directory.Exists(archivo))                                                          // Si el elemento es una carpeta
        {
            DirectoryInfo di = new DirectoryInfo(archivo);                                      // Obtiene información sobre la carpeta
            
            foreach (FileInfo file in di.GetFiles())                                            // Luego, recorre cada archivo dentro de la carpeta
            {
                zip.CreateEntryFromFile(file.FullName, Path.Combine(di.Name, file.Name));       // Y agrega el archivo al archivo .zip con la ruta dentro del .zip
            }
        }
    }
}



LO DE HASTA ARRIBA:
Son propiedades que se hacen para devolverle a quien consuma la libreria los errores y mensajes
*/