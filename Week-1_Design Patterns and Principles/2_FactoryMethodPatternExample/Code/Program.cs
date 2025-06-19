public class Program
{
    public static void Main(string[] args)
    {
        DocumentFactory wordFactory = new WordDocumentFactory();
        Document wordDoc = wordFactory.CreateDocument("MyDocument.docx");
        wordDoc.Open();
        wordDoc.Save();

        DocumentFactory pdfFactory = new PdfDocumentFactory();
        Document pdfDoc = pdfFactory.CreateDocument("MyDocument.pdf");
        pdfDoc.Open();
        pdfDoc.Save();

        DocumentFactory excelFactory = new ExcelDocumentFactory();
        Document excelDoc = excelFactory.CreateDocument("MyDocument.xlsx");
        excelDoc.Open();
        excelDoc.Save();
    }
}
