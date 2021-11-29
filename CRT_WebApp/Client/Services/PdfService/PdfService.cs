using CRT_WebApp.Shared;
using Microsoft.AspNetCore.Http;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.IO;

namespace CRT_WebApp.Client.Services.PdfService
{
    public class PdfService
    {
        PdfDocument doc;
        PdfPage page;
        XGraphics xg;        
        QuoteModel quote;
        bool isSurvey = false;
        MemoryStream memStream = new MemoryStream();

        readonly XFont font = new XFont("Verdana", 20, XFontStyle.Regular);
        readonly XFont headerFont = new XFont("Verdana", 28, XFontStyle.Bold);

        public PdfService()
        { }

        public void GenPDF(QuoteModel quote)
        {
            this.quote = quote;
            CreateDoc();
            AddHeaderPage();
            AddSubgroupPages();
            AddNotesPage();
            DownloadPDF();
        }

        public void CreateDoc()
        {
            try
            {
                doc = new PdfDocument();
                doc.Info.Title = quote.QuoteTitle + " - " + quote.QuoteDate;
                doc.Info.Author = quote.QuoteUser;

                if (quote.Total == 0)
                    isSurvey = true;
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR: "+e.Message);
            }
        }

        public void AddHeaderPage()
        {
            try
            {
                page = doc.AddPage();
                xg = XGraphics.FromPdfPage(page);

                xg.DrawString(quote.QuoteTitle + " - " + quote.QuoteDate, headerFont,
                    XBrushes.Black, new XPoint(200, 70));
                xg.DrawLine(new XPen(XColor.FromArgb(50, 30, 200)), new XPoint(100, 100),
                    new XPoint(400, 110));

                //headings for quote info. Arranged horizontally
                xg.DrawString("ID", font, XBrushes.Black, new XPoint(100, 280));
                xg.DrawString("Created by", font, XBrushes.Black, new XPoint(250, 280));
                xg.DrawString("State", font, XBrushes.Black, new XPoint(400, 280));

                //adding total if applicable and drawing a final line underneath
                if (isSurvey)
                    xg.DrawString("Total", font, XBrushes.Black, new XPoint(550, 280));

                //TODO: pop rows with quote info

                //bottom line of info tables (Y 300)
                xg.DrawLine(new XPen(XColor.FromArgb(50, 30, 200)), new XPoint(100, 290),
                        new XPoint(400, 300));
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
        }

        public void AddSubgroupPages()
        {
            try
            {
                int currYV = 100, currYL = 130;
                AssemblyItemModel currItem;

                for (int x = 0; x < quote.SubGroups.Count; x++)
                {
                    page = doc.AddPage();
                    xg = XGraphics.FromPdfPage(page);

                    //drawing subgroup title (x 100 y bottom line + 250)
                    xg.DrawString(quote.SubGroups[x].SubGroupTitle, headerFont, XBrushes.Black,
                        new XPoint(100, currYV));

                    //drawing subgroup line under title (x 100 y bottom line + 280)
                    xg.DrawLine(new XPen(XColor.FromArgb(50, 30, 200)), new XPoint(100, currYL),
                            new XPoint(400, currYL + 20));

                    for (int y = 0; y < quote.SubGroups[x].ListOfItems.Count; y++)
                    {
                        currItem = quote.SubGroups[x].ListOfItems[y];
                        xg.DrawString(currItem.Description, font, XBrushes.Black,
                            new XPoint(100, currYV));
                        xg.DrawString(currItem.NumberOfUnits.ToString(), font, XBrushes.Black,
                            new XPoint(250, currYV));

                        if (currItem.NumberOfUnits > 0)
                            xg.DrawString('$' + currItem.GetFormattedTotalPrice(), headerFont, XBrushes.Black,
                            new XPoint(400, currYV));

                        xg.DrawLine(new XPen(XColor.FromArgb(50, 30, 200)), new XPoint(100, currYL),
                        new XPoint(400, currYL + 10));

                        currYV += 30;
                        currYL += 30;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
        }

        public void AddNotesPage()
        {
            try
            {
                int currYV = 100, currYL = 130;
                page = doc.AddPage();
                xg = XGraphics.FromPdfPage(page);
                NoteModel currNote = new NoteModel();

                xg.DrawString("Additional Notes", headerFont, XBrushes.Black,
                    new XPoint(100, currYV));

                xg.DrawLine(new XPen(XColor.FromArgb(50, 30, 200)), new XPoint(100, currYL),
                        new XPoint(400, currYL + 20));

                for(int x = 0; x < quote.Notes.Count; x++)
                {
                    currNote = quote.Notes[x];
                    xg.DrawString(currNote.NoteHeader, font, XBrushes.Black,
                        new XPoint(100, currYV));
                    xg.DrawString(currNote.NoteContent, font, XBrushes.Black,
                        new XPoint(250, currYV));

                    xg.DrawLine(new XPen(XColor.FromArgb(50, 30, 200)), new XPoint(100, currYL),
                        new XPoint(400, currYL + 10));

                    currYV += 30;
                    currYL += 30;
                }

            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }           
        }

        public void DownloadPDF()
        {
            try
            {
                doc.Save(@"C:\Users\user\Desktop\" + this.quote.QuoteTitle.ToUpper().Trim()+".pdf");
                //doc.Save(memStream, false);
                //HttpResponse.Clear();
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
        }
    }
}
