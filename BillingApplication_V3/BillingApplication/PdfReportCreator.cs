using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;

namespace hrms
{
    public struct MasterDataStructure
    {
        public string Caption { get; set; }
        public string Value { get; set; }
        public int ColumnNo { get; set; }
        public string DataType { get; set; }
    }

    public struct DetailDataStructure
    {
        public string Caption { get; set; }
        public string Value { get; set; }
        public string DataType { get; set; }
    }


    public class PdfReportCreator
    {
        public PageSize pageSize { get; set; }

        /// <summary>
        /// Variables for data
        /// </summary>
        public Hashtable CompanyInfo { get; set; }
        public string ReportTitle { get; set; }
        public int NoOfMasterColumn { get; set; }
        public List<MasterDataStructure> MasterData { get; set; }
        public Hashtable DetailHeaders { get; set; }
        public List<DetailDataStructure> DetailData { get; set; }


        private Hashtable fields;


        public PdfReportCreator()
        {

        }

        private void Write(DataTable dt)
        {
            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 10, 10, 10, 10);
            try
            {
                PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);
                pdfDoc.Open();

                Font HeaderFont = FontFactory.GetFont("Verdana", 18, Font.BOLD);
                foreach (var key in CompanyInfo)
                {
                    Chunk infoChunk = new Chunk(CompanyInfo[key].ToString(), HeaderFont);
                    Paragraph p = new Paragraph();
                    p.Alignment = Element.ALIGN_LEFT;
                    p.SpacingAfter = 10f;
                    p.Add(infoChunk);
                    pdfDoc.Add(p);

                    HeaderFont = FontFactory.GetFont("Verdana", 12, Font.NORMAL);
                }

                Chunk titleChunk = new Chunk(ReportTitle, FontFactory.GetFont("Verdana", 18));
                Paragraph p = new Paragraph();
                p.Alignment = Element.ALIGN_LEFT;
                p.SpacingAfter = 10f;
                p.Add(titleChunk);
                pdfDoc.Add(p);

                //Craete instance of the pdf table and set the number of column in that table  
                PdfPTable table = new PdfPTable(NoOfMasterColumn);
                table.HorizontalAlignment = 0;
                table.TotalWidth = 500f;
                table.LockedWidth = true;

                float[] masterWidths;
                if(NoOfMasterColumn == 2)
                    masterWidths = new float[] { 100f, 400f };
                else
                    masterWidths = new float[] { 70f, 160f, 40f, 70f, 160f };
                
                table.SetWidths(masterWidths);


                int lineNo = 1;
                string Id = "";
                Font font8 = FontFactory.GetFont("ARIAL", 10);
                Font captoionFont = FontFactory.GetFont("ARIAL", 10, Font.BOLD);

                if (dt != null)
                {
                    for (int rows = 0; rows < dt.Rows.Count; rows++)
                    {
                        //Craete instance of the pdf table and set the number of column in that table  
                        PdfPTable table = new PdfPTable(2);
                        table.HorizontalAlignment = 0;
                        table.TotalWidth = 500f;
                        table.LockedWidth = true;
                        float[] widths = new float[] {100f, 400f};
                        table.SetWidths(widths);

                        PdfPCell Cell = null;

                        for (int i = 0; i < fields.Count; i++)
                        {
                            System.Web.UI.WebControls.ListItem lst = new System.Web.UI.WebControls.ListItem();
                            lst = (System.Web.UI.WebControls.ListItem) fields[i];


                            string column = lst.Value;
                            string title = lst.Text;

                            if (title == "Id")
                            {
                                Id = dt.Rows[rows]["Id"].ToString();
                            }
                            else
                            {
                                if (title == "Line No")
                                    column = lineNo.ToString();

                                //if total field, by default set to RIGHT align.

                                string value = "";

                                if (title.Contains("Date"))
                                {
                                    try
                                    {
                                        string dtString = dt.Rows[rows][column].ToString();

                                        DateTime date = DateTime.Parse(dtString);
                                        value = date.ToString();
                                    }
                                    catch
                                    {
                                        value = "";
                                    }
                                }
                                else if (title.Contains("Price"))
                                {
                                    string price = "", currency = "";
                                    string strValue = dt.Rows[rows][column].ToString();
                                    try
                                    {
                                        if (strValue.Contains(" "))
                                        {
                                            price = strValue.Substring(0, strValue.IndexOf(" "));
                                            currency = strValue.Substring(strValue.IndexOf(" ") + 1,
                                                strValue.Length - (strValue.IndexOf(" ") + 1));
                                        }
                                        else
                                        {
                                            price = strValue;
                                        }

                                        price = double.Parse(price, CultureInfo.InvariantCulture).ToString();
                                        value = price + " " + currency;
                                    }
                                    catch
                                    {
                                        value = "0";

                                    }
                                }

                                Cell = new PdfPCell(new Phrase(new Chunk(title + " : ", captoionFont)));
                                //Cell.Rowspan = 1;
                                Cell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                                Cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                                Cell.MinimumHeight = 20f;
                                Cell.Border = Rectangle.NO_BORDER;
                                table.AddCell(Cell);

                                if (title == "Line No")
                                    Cell = new PdfPCell(new Phrase(new Chunk(column, font8)));
                                else if (title.Contains("Date"))
                                {
                                    Cell = new PdfPCell(new Phrase(new Chunk(value, font8)));
                                }
                                else if (title.Contains("Price"))
                                {
                                    Cell = new PdfPCell(new Phrase(new Chunk(value, font8)));
                                }
                                else
                                    Cell = new PdfPCell(new Phrase(new Chunk(dt.Rows[rows][column].ToString(), font8)));
                                //Cell.Rowspan = 2;
                                Cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                                Cell.Border = Rectangle.NO_BORDER;
                                Cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                                table.AddCell(Cell);
                            }
                        }
                        pdfDoc.Add(table);

                        pdfDoc.NewPage();

                        lineNo++;
                    }
                    //PdfTable.SpacingBefore = 15f; // Give some space after the text or it may overlap the table            
                    // add pdf table to the document   
                }

                pdfDoc.Close();
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write(ex.Message);
            }
                
        }
    }
}