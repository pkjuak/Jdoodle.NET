 private  static void ManipulatePdf(string src, string dest)
        {
            //Load the license file to use cleanup features
            LicenseKey.LoadLicenseFile("license.xml");
            using (var pdfDocument = new PdfDocument(new PdfReader(src), new PdfWriter(dest)))
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
