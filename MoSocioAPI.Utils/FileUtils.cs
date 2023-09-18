using System;
using System.IO;
using System.Text;
using MoSocioAPI.Model.Configuration;

namespace MoSocioAPI.Utils
{
    public class FileUtils
    {
        /// <summary>
        /// Metodo que escreve em um ficheiro
        /// </summary>
        /// <param name="filePath">ficheiro</param>
        /// <param name="texto">texto a ser escrito</param>
        public static bool WriteOnFileHtmlComDoctype(String filePath, String texto)
        {
            bool result = true;
            try
            {
                if (File.Exists(filePath))
                {

                    RemoverFicheiro(filePath);
                }
                FileStream fs = null;

                fs = new FileStream(filePath, FileMode.CreateNew);

                using (StreamWriter swriter = new StreamWriter(fs, Encoding.UTF8))
                {
                    //swriter.Write("<!DOCTYPE html><head><link href=\"../../../content/css/print.css\" rel=\"stylesheet\"/></head><body>");
                    swriter.Write(texto.ToString());
                    //swriter.Write("</body></html>");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu uma expção: " + ex.Message);
                result = false;
            }

            return result;
        }

    

        /// <summary>
        /// Metodo que escreve em um ficheiro
        /// </summary>
        /// <param name="filePath">ficheiro</param>
        /// <param name="texto">texto a ser escrito</param>
        public static bool WriteOnFile(String filePath, String texto)
        {
            bool result = true;
            try
            {
                if (File.Exists(filePath))
                {
                    RemoverFicheiro(filePath);
                }
                FileStream fs = null;

                fs = new FileStream(filePath, FileMode.CreateNew);

                using (StreamWriter swriter = new StreamWriter(fs, Encoding.UTF8))
                {
                    swriter.Write("<!DOCTYPE html><head><link href=\"../../../content/css/print.css\" rel=\"stylesheet\"/></head><body>");
                    swriter.Write(texto.ToString());
                    swriter.Write("</body></html>");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu uma expção: " + ex.Message);
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Metodo que cria uma pasta
        /// </summary>
        /// <param name="nomePasta">nome da pasta a ser criada</param>
        public static void CriarPasta(String nomePasta)
        {
            try
            {
                Directory.CreateDirectory(nomePasta);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu uma expção: " + ex.Message);
            }
        }

        /// <summary>
        /// Metodo que move um ficheiro de um local para outro
        /// </summary>
        /// <param name="origem">localizacao actual do ficheiro</param>
        /// <param name="destino">local para onde o ficheiro será movido</param>
        public static void MoverFicheiro(String origem, String destino)
        {
            try
            {
                File.Move(origem, destino);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu uma expção: " + ex.Message);
            }
        }

        /// <summary>
        /// Metodo que eliminar um ficheiro
        /// </summary>
        /// <param name="ficheiro">ficheiro a ser removido</param>
        public static void RemoverFicheiro(String ficheiro)
        {
            try
            {
                File.Delete(ficheiro);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu uma expção: " + ex.Message);
            }
        }
        public static bool RemoveFilesByName(string fileName)
        {
            bool result = false;

            string[] files = Directory.GetFiles(Constants.FOLDER_DOCS_PATH);

            try
            {
                foreach (string file in files)
                {
                    if (file.ToUpper().Contains(fileName.ToUpper()))
                    {
                        File.Delete(file);

                    }
                }
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu uma expção: " + ex.Message);
            }
            return result;
        }
        public static bool CopiarFicheiro(String origem, String destino)
        {
            bool result = true;
            try
            {
                FileInfo file = new FileInfo(origem);

                file.CopyTo(destino);

            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine("Ocorreu uma expção: " + ex.Message);
            }
            return result;
        }
    }
}
