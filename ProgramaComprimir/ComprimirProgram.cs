using System;
using ComprimirYDescomprimir;

namespace ProgramComprimir
{
    public class ComprimirProgram
    {
        public static void Main(string[] args)
        {
            TestZipMethod();
            TestUnZipMethod();
            TestZipListMethod();
        }


        public static void TestZipMethod()
        {
            string carpeta = @"/home/oscar/Vídeos/miarchivo/";
            string archivoComprimido = @"/home/oscar/Vídeos/miarchivo.zip/";

            ComprimirLibrary oZip = new ComprimirLibrary(); //Aquí es la instancia
            oZip.ZipFolder(carpeta, archivoComprimido);
        }


        public static void TestUnZipMethod()
        {
            string archivoComprimido = @"/home/oscar/Vídeos/miarchivo.zip/";
            string carpetaDestino = @"/home/oscar/Vídeos/archivo_descomprimido/";

            ComprimirLibrary oZip = new ComprimirLibrary(); //Aquí es la instancia
            oZip.UnZip(archivoComprimido, carpetaDestino);
        }


        public static void TestZipListMethod()
        {
            List<string> archivos = new List<string>
            {
                @"/home/oscar/Vídeos/archivo1/",
                @"/home/oscar/Vídeos/archivo2/",
                @"/home/oscar/Vídeos/archivo3/"

            };
            string archivoComprimidoLista = @"/home/oscar/Vídeos/archivo_list.zip/";

            ComprimirLibrary oZip = new ComprimirLibrary(); //Aquí es la instancia
            oZip.ZipList(archivos, archivoComprimidoLista);
        }
    }
}

//NOTA IMPORTANTE: Cuando se colocan propiedades, campos, etc y no es estático; se tiene que instanciar antes de llamar al método