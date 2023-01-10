using System.IO;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Licensing.Base;

namespace TextWrap
{
    internal class TextWrapTest
    {
        public static void Main(string[] args)
        {
           LicenseKey.LoadLicenseFile(new FileStream("license.json",FileMode.Open));
           TestTextWrapping("testTextWrapping_New.pdf");
        }

        public static void TestTextWrapping(string fileName)
        {
            using (var pdfDoc = new PdfDocument(new PdfWriter(fileName)))
            using(var document = new Document(pdfDoc))
            {
              document.SetLeftMargin(68.04f);
              document.SetRightMargin(68.04f);
              pdfDoc.SetDefaultPageSize(PageSize.LETTER);

              var font = PdfFontFactory.CreateFont("Fonts/arial.ttf");
              const string text1 = "Please note that the corporation does not have IPFCF coverage " +
                                   "for any period of time during which primary ";
              
              const string text2 = "professional liability insurance " +
                                   "coverage is not in place, and that the statutory limits of liability do not " +
                                   "apply for any such ";
              
              const string text3 = "period."; 
 
              var text = new Text(text1); 
              text.SetFont(font); 
              text.SetFontSize(9); 
              var paragraph = new Paragraph(); 
              paragraph.Add(text); 
 
              text = new Text(text2); 
              text.SetFont(font); 
              text.SetFontSize(9); 
              paragraph.Add(text); 
 
              text = new Text(text3); 
              text.SetFont(font); 
              text.SetFontSize(9); 
              paragraph.Add(text); 
 
              paragraph.SetBackgroundColor(ColorConstants.LIGHT_GRAY); 
              document.Add(paragraph);

            }
        }
    }
}
