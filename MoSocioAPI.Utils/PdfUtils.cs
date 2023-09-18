using iTextSharp.text;
using iTextSharp.tool.xml;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.IO;
using TheArtOfDev.HtmlRenderer.Core.Entities;
using MoSocioAPI.Model.Configuration;

namespace MoSocioAPI.Utils
{
    public static class PdfUtils
    {
        /// <summary>
        /// Metodo que conta o número de páginas de um pdf
        /// </summary>
        /// <param name="pathDoc">caminho file pdf</param>
        public static int NumberOfPagesPdf(string pathDoc)
        {
            int count = -1;
            try
            {
                using (iTextSharp.text.pdf.PdfReader pdfReader = new iTextSharp.text.pdf.PdfReader(pathDoc))
                {
                    count = pdfReader.NumberOfPages;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu uma expção: " + ex.Message);
                //result = false;
            }

            return count;
        }

        /// <summary>
        /// Metodo que gera um pdf a partir de um file html
        /// </summary>
        /// <param name="dest">pdf a ser criado</param>
        /// <param name="src">caminho file html</param>
        public static bool GerarPdfFromHtmlITextHtml2pdf(string dest, string src)
        {

            bool result = true;
            try
            {
                iText.Html2pdf.HtmlConverter.ConvertToPdf(
                    new FileInfo(@src),
                    new FileInfo(@dest));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu uma expção: " + ex.Message);
                result = false;
            }

            return result;
        }

        /// <summary>
        /// The AddDocumentPages
        /// </summary>
        /// <param name="pdf">The pdf<see cref="byte[]"/></param>
        /// <param name="pages">The pages<see cref="int"/></param>
        /// <returns>The <see cref="byte[]"/></returns>
        private static byte[] AddDocumentPages(byte[] pdf, int pages)
        {
            var reader = new iTextSharp.text.pdf.PdfReader(pdf);
            using (var ms = new MemoryStream())
            using (var stamper = new iTextSharp.text.pdf.PdfStamper(reader, ms))
            {
                var numberofPages = reader.NumberOfPages;
                var rectangle = reader.GetPageSize(1);
                for (var i = 1; i <= pages; i++) stamper.InsertPage(numberofPages + i, rectangle);
                reader.Close();
                stamper.Close();
                ms.Flush();
                return ms.GetBuffer();
            }
        }

        /// <summary>
        /// Método para anexar imagem no Pdf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnImageLoadPdfSharp(object sender, HtmlImageLoadEventArgs e)
        {
        }

        /// <summary>
        /// Metodo que faz o merge das pecas de um processo
        /// </summary>
        /// <param name="targetPath">A directoria onde sera guardado o ficheiro final</param>
        /// <param name="pdfs">A Lista de Peças em PDF</param>
        public static void MergePDF(string targetPath, params string[] pdfs)
        {

            string url = string.Empty;
            using (PdfDocument targetDoc = new PdfDocument())
            {
                foreach (string pdf in pdfs)
                {
                    using (MemoryStream memoryStream = ReturnCompatiblePdf(pdf))
                    {

                        PdfDocument DocPdf = PdfReader.Open(memoryStream, PdfDocumentOpenMode.Import);

                        for (int i = 0; i < DocPdf.PageCount; i++)
                        {
                            targetDoc.AddPage(DocPdf.Pages[i]);
                        }
                    }
                }
                targetDoc.Save(targetPath);
            }
        }

        /// <summary>
        /// Método que retorna um Pdf com base no nome do ficheiro
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static MemoryStream ReturnCompatiblePdf(string fileName)
        {
            iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(fileName);
            MemoryStream output_stream = new MemoryStream();

            // we retrieve the total number of pages
            int n = reader.NumberOfPages;
            // step 1: creation of a document-object
            iTextSharp.text.Document document = new iTextSharp.text.Document(reader.GetPageSizeWithRotation(1));
            // step 2: we create a writer that listens to the document
            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, output_stream);
            // write pdf that pdfsharp can understand
            writer.SetPdfVersion(iTextSharp.text.pdf.PdfWriter.PDF_VERSION_1_4);
            // step 3: we open the document
            document.Open();
            iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
            iTextSharp.text.pdf.PdfImportedPage page;

            int rotation;

            int i = 0;
            while (i < n)
            {
                i += 1;
                document.SetPageSize(reader.GetPageSizeWithRotation(i));
                document.NewPage();
                page = writer.GetImportedPage(reader, i);
                rotation = reader.GetPageRotation(i);
                if (rotation == 90 || rotation == 270)
                    cb.AddTemplate(page, 0, -1.0F, 1.0F, 0, 0, reader.GetPageSizeWithRotation(i).Height);
                else
                    cb.AddTemplate(page, 1.0F, 0, 0, 1.0F, 0, 0);
            }

            // ---- Keep the stream open!
            writer.CloseStream = false;

            // step 5: we close the document
            document.Close();

            return output_stream;
        }

        public static byte[] MergeByteArrayPDF(List<byte[]> pdfByteContent)
        {
            using (var ms = new MemoryStream())
            {
                using (var doc = new Document())
                {
                    using (var copy = new iTextSharp.text.pdf.PdfSmartCopy(doc, ms))
                    {
                        doc.Open();
                        foreach (var p in pdfByteContent)
                        {
                            //Create a PdfReader bound to that byte array
                            using (var reader = new iTextSharp.text.pdf.PdfReader(p))
                            {
                                //Add the entire document instead of page-by-page
                                copy.AddDocument(reader);
                            }
                        }

                        doc.Close();
                    }
                }
                return ms.ToArray();
            }
        }


        public static Byte[] PdfSharpConvert(String html)
        {
            Byte[] res = null;
            using (MemoryStream ms = new MemoryStream())
            {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                pdf.Save(ms);
                res = ms.ToArray();
            }
            return res;
        }

        public static bool GerarPdfFromByte(byte[] documento)
        {
            string pathDoc = Constants.FOLDER_DOCS_PATH + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".pdf";

            try
            {
                FileStream fileStream = new FileStream(pathDoc, FileMode.Create);
                fileStream.Write(documento, 0, documento.Length);
                fileStream.Close();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public static void Html2Pdf(string html, string filename)
        {
            using (Stream fs = new FileStream(filename, FileMode.Create))
            {
                using (Document doc = new Document(PageSize.A4))
                {

                    iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    using (StringReader sr = new StringReader(html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, sr);
                    }
                    doc.Close();
                }
            }

        }
    }
}
