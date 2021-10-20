using System.IO;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Licensing.Base;

namespace GPOS
{
    internal class GposLookupExample
    {
        private static string TEXT =
            "ဗမာမှာ လူများစုဗမာမျိုး နွယ်စု၏ ခေါ် ရာတွင် တရားဝင်ခေါ် သော အသုံး ဖြ စ်သည်။ အင်္ဂလိပ်လက်အော က်";

        private static string FONT = "NotoSansMyanmar-Regular.ttf";
        private static string DEST = "result.pdf";

        public static void Main(string[] args)
        {
            ManipulatePdf(DEST);
        }

        public static void ManipulatePdf(string dest)
        {
            LicenseKey.LoadLicenseFile(new FileStream("license.json",
                FileMode.Open));
            using (var document = new Document(new PdfDocument(new PdfWriter(dest))))
            {
                PdfFont font = PdfFontFactory.CreateFont(FONT, PdfEncodings.IDENTITY_H,
                    PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);
                Paragraph paragraph = new Paragraph(TEXT).SetBaseDirection(BaseDirection.LEFT_TO_RIGHT)
                    .SetTextAlignment(TextAlignment.LEFT);
                font.SetSubset(false);
                paragraph.SetFont(font);
                document.Add(paragraph);
            }
        }
    }
}
