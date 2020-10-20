public void GeneratePdf(string src, string dest)
{
    //A converter properties with a base uri set
    // to point to the directory where images can be retrieved
    var properties = new ConverterProperties().SetBaseUri(RESOURCES_DIR);
    var pdfDocument = new PdfDocument(new PdfWriter(dest));
    var fileInputStream = new FileStream(src, FileMode.Open);
    HtmlConverter.ConvertToPdf(fileInputStream, pdfDocument, properties);
}
