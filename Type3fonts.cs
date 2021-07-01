 using System.Collections.Generic;
using iText.Forms;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.License;
using iText.PdfCleanup;

namespace TYPE3TEST
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Load the license file to use cleanup features
            LicenseKey.LoadLicenseFile("license.xml");
         
            var properties = new StampingProperties();
         
            using (var pdfDocument =
                new PdfDocument(new PdfReader("base.pdf"),
                    new PdfWriter("cleanupResult.pdf"), properties))
            {

                var form = PdfAcroForm.GetAcroForm(pdfDocument, false);
                form?.FlattenFields();

                DeviceRgb color = (DeviceRgb) ColorConstants.BLACK;

                IList<PdfCleanUpLocation> cleanUpLocations = new List<PdfCleanUpLocation>();
                cleanUpLocations.Add(new PdfCleanUpLocation(1, new Rectangle(50, 50, 500, 800), color));
                PdfCleanUpTool cleaner = new PdfCleanUpTool(pdfDocument, cleanUpLocations);

                cleaner.CleanUp();
            }
        }
    }
}
