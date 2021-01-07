using (FileStream htmlSource = File.Open(“input.html”, FileMode.Open))
using (FileStream pdfDest = File.Open(“output.html”, FileMode.OpenOrCreate))
{
	HtmlConverter.ConvertToPdf(htmlSource, pdfDest);
}
