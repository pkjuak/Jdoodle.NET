using iText.Forms.Form.Element;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout.Renderer;

namespace ConsoleApp1;

public class SignApearanceExample1
{
    private const string SourceFolder = "/SRC/";

    public virtual void SigFieldWithDivAppearance(string outPdf)
     {
         using var document = new Document(new PdfDocument(new PdfWriter(outPdf)));
         var div = new Div();
         div.Add(new Paragraph("Paragraph inside div with red dashed border and pink background")
             .SetBorder(new DashedBorder(ColorConstants.RED, 1)).SetBackgroundColor(ColorConstants.PINK));
         var flexContainer = new Div();
         flexContainer.SetProperty(Property.FLEX_WRAP, FlexWrapPropertyValue.WRAP);
         flexContainer.SetProperty(Property.FLEX_DIRECTION, FlexDirectionPropertyValue.ROW_REVERSE);
         flexContainer.SetProperty(Property.ALIGN_ITEMS, AlignmentPropertyValue.CENTER);
         flexContainer.Add(new Image(ImageDataFactory.Create(SourceFolder + "image.png")).Scale(0.1f, 0.3f)
                 .SetPadding(10)).Add(new List()
             .Add(new ListItem("Flex container with").SetListSymbol(ListNumberingType.ZAPF_DINGBATS_1))
             .Add(new ListItem("image and list,").SetListSymbol(ListNumberingType.ZAPF_DINGBATS_2))
             .Add(new ListItem("wrap, row-reverse,").SetListSymbol(ListNumberingType.ZAPF_DINGBATS_3))
             .Add(new ListItem("green dots border").SetListSymbol(ListNumberingType.ZAPF_DINGBATS_4))
             .SetPadding(10)).SetBorder(new RoundDotsBorder(ColorConstants.GREEN, 10));
         flexContainer.SetNextRenderer(new FlexContainerRenderer(flexContainer));
         div.Add(flexContainer);
         
         var appearance = new SignatureFieldAppearance("form SigField");
         appearance.SetContent(div)
             .SetFontColor(ColorConstants.WHITE).SetFontSize(10)
             .SetBackgroundColor(ColorConstants.DARK_GRAY)
             .SetBorder(new SolidBorder(ColorConstants.MAGENTA, 2))
             .SetInteractive(true);
         document.Add(appearance);
     }
     
}
