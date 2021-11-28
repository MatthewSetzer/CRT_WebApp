using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using CRT_WebApp.Shared;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Document = iTextSharp.text.Document;
using System.Windows;

namespace CRT_WebApp.Client.Services.PdfService
{
    public class PdfService
    {
        Document doc;
        PdfPTable infoTable, noteTable;
        List<PdfPTable> subgroupTables = new List<PdfPTable>();
        PdfPCell cell;
        Font fontStyle;
        MemoryStream memStream = new MemoryStream();
        QuoteModel quote;
        bool isSurvey;

        private byte[] GenPDF(QuoteModel quote)
        {
            try
            {
                int infoColumns = 4, subgroupColumns = 3, noteColumns = 2, subgroupCount;

                if (quote.Total == 0)
                {
                    infoColumns = 2;
                    subgroupColumns = 2;
                    isSurvey = true;
                }
                else
                    isSurvey = false;

                this.quote = quote;
                doc = new Document(PageSize.A4, 10f, 10f, 20f, 30f);

                subgroupCount = quote.SubGroups.Count;

                for (int x = 0; x < subgroupCount; x++)
                {
                    subgroupTables.Add(new PdfPTable(subgroupColumns));
                    this.subgroupTables[x].WidthPercentage = 100;
                    this.subgroupTables[x].HorizontalAlignment = Element.ALIGN_CENTER;
                }

                infoTable.WidthPercentage = 100;
                infoTable.HorizontalAlignment = Element.ALIGN_CENTER;
                noteTable.WidthPercentage = 100;
                noteTable.HorizontalAlignment = Element.ALIGN_CENTER;

                fontStyle = FontFactory.GetFont("Verdana", 10f, 1);
                PdfWriter.GetInstance(doc, memStream);
                doc.Open();

                float[] infoTableSizes = new float[infoColumns];
                float[] subgroupSizes = new float[subgroupColumns];
                float[] noteSizes = new float[subgroupColumns];

                for (int x = 0; x < infoColumns; x++)
                {
                    if (x == 0)
                        infoTableSizes[x] = 50;
                    else
                        infoTableSizes[x] = 100;
                }

                for (int x = 0; x < subgroupColumns; x++)
                {
                    if (x == 0)
                        subgroupSizes[x] = 50;
                    else if (x == 1)
                        subgroupSizes[x] = 20;
                    else
                        subgroupSizes[x] = 100;
                }

                for (int x = 0; x < noteColumns; x++)
                {
                    if (x == 0)
                        noteSizes[x] = 35;
                    else
                        noteSizes[x] = 130;
                }


                infoTable.SetWidths(infoTableSizes);
                noteTable.SetWidths(noteSizes);
                for (int x = 0; x < subgroupTables.Count; x++)
                {
                    subgroupTables[x].SetWidths(subgroupSizes);
                }

                this.GetHeader(infoColumns);
                this.GetBody();

                infoTable.HeaderRows = 4;
                doc.Add(infoTable);
                for (int x = 0; x < subgroupTables.Count; x++)
                    doc.Add(subgroupTables[x]);
                doc.Add(noteTable);
                doc.Close();

                return memStream.ToArray();
            }
            catch (Exception e)
            {
                //generic popup message box here              
                return new byte[1];
            }
        }

        private void GetHeader(int infoPageColumns)
        {
            cell = new PdfPCell(this.SetPageTitle());
            cell.Colspan = infoPageColumns - 1;
            cell.Border = 0;
            infoTable.AddCell(cell);

            infoTable.CompleteRow();
        }

        private byte[] CreateImagePDF(List<string> imageURLs)
        {
            try
            {
                Document newDoc = new Document();
                var ms = new MemoryStream();
                {
                    PdfCopy pdf = new PdfCopy(doc, ms);
                    doc.Open();

                    foreach (string url in imageURLs)
                    {
                        byte[] imgData = File.ReadAllBytes(url);
                        //doc.NewPage();
                        Document imgDoc = null;
                        PdfWriter imgDocWriter = null;

                        using (var imageMS = new MemoryStream())
                        {
                            imgDocWriter = PdfWriter.GetInstance(imgDoc, imageMS);
                            imgDoc.Open();

                            var image = Image.GetInstance(imgData);
                            image.Alignment = Element.ALIGN_CENTER;
                            image.ScaleToFit(imgDoc.PageSize.Width - 10, imgDoc.PageSize.Height - 10);

                            if (!imgDoc.Add(image))
                            {
                                throw new Exception("An error occurred while adding an image to the PDF!");
                            }

                            imgDoc.Close();
                            imgDocWriter.Close();
                            PdfReader imgDocReader = new PdfReader(ms.ToArray());
                            var page = pdf.GetImportedPage(imgDocReader, 1);
                            pdf.AddPage(page);
                            imgDocReader.Close();
                        }
                    }


                }
                if (newDoc.IsOpen()) 
                    newDoc.Close();

                return ms.ToArray();

            }
            catch (Exception e)
            {
                //ERROR MESSAGE HERE
                return new byte[10];
            }
        }   
        
        private Document combinePDFs(byte[] imageDocBytes, string outFileName)
        {
            Document imageDoc = new Document(PageSize.A4);
            PdfWriter.GetInstance(imageDoc, new FileStream(path, FileAccess.ReadWrite));

            Document mergedDoc = new Document();
            using (FileStream fs = new FileStream(outFileName, FileMode.Create))
            {
                PdfCopy copyWriter = new PdfCopy(mergedDoc, fs);
                if(copyWriter == null)
                {
                    return new Document();
                }

                mergedDoc.Open();

                PdfReader reader = new PdfReader(filename);

            }
            
            return new Document();
        }

        private PdfPTable SetPageTitle()
        {
            try
            {
                int maxCol = 2;
                PdfPTable table = new PdfPTable(maxCol);

                this.fontStyle = FontFactory.GetFont("Verdana", 28f, 1);
                cell = new PdfPCell(new Phrase(this.quote.QuoteTitle, this.fontStyle));
                cell.Colspan = maxCol;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Border = 0;
                cell.ExtraParagraphSpace = 0;
                table.AddCell(cell);
                table.CompleteRow();

                this.fontStyle = FontFactory.GetFont("Verdana", 20f, 1);
                cell = new PdfPCell(new Phrase(this.quote.QuoteDate.ToString(), this.fontStyle));
                cell.Colspan = maxCol;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Border = 0;
                cell.ExtraParagraphSpace = 0;
                table.AddCell(cell);
                table.CompleteRow();

                return table;
            }
            catch(Exception e)
            {
                //ERROR MESSAGE HERE
                return new PdfPTable(0);
            }           
        }

        private void GetBody()
        {
            try
            {
                this.fontStyle = FontFactory.GetFont("Verdana", 12f, 1);
                var altFontStyle = FontFactory.GetFont("Verdana", 9f, 1);

                cell = new PdfPCell(new Phrase("ID", this.fontStyle));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.LightGray;
                infoTable.AddCell(cell);

                cell = new PdfPCell(new Phrase("Created by", this.fontStyle));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.LightGray;
                infoTable.AddCell(cell);

                if (!isSurvey)
                {
                    cell = new PdfPCell(new Phrase("State", this.fontStyle));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.BackgroundColor = BaseColor.LightGray;
                    infoTable.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Total", this.fontStyle));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.BackgroundColor = BaseColor.LightGray;
                    infoTable.AddCell(cell);

                    infoTable.CompleteRow();
                }

                cell = new PdfPCell(new Phrase(quote.Id.ToString(), this.fontStyle));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.LightGray;
                infoTable.AddCell(cell);

                cell = new PdfPCell(new Phrase(quote.QuoteUser.ToString(), this.fontStyle));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.LightGray;
                infoTable.AddCell(cell);

                if(!isSurvey)
                {
                    string stateString = "";
                    if (quote.QuoteState == true)
                        stateString = "Active";
                    else
                        stateString = "Inactive";

                    cell = new PdfPCell(new Phrase(stateString, this.fontStyle));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.BackgroundColor = BaseColor.LightGray;
                    infoTable.AddCell(cell);

                    cell = new PdfPCell(new Phrase("$ "+quote.Total.ToString(), this.fontStyle));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.BackgroundColor = BaseColor.LightGray;
                    infoTable.AddCell(cell);

                }


            }
            catch (Exception e)
            {
                //ERROR MESSAGE HERE'
                return;
            }
        }

    }
}
