 public virtual void Convert(String svg, String output, PageSize size) 
 {
           using (PdfDocument doc = new PdfDocument(new PdfWriter(output, new WriterProperties().SetCompressionLevel(0)))) 
           {
                doc.AddNewPage(size);
                  properties = new SvgConverterProperties().SetBaseUri(svg);
                SvgConverter.DrawOnDocument(new FileStream(svg, FileMode.Open, FileAccess.Read), doc, 1, properties);
            }
 }
