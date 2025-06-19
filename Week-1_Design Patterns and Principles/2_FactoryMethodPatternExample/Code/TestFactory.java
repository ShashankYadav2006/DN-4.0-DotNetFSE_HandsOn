public class TestFactory {
    public static void main(String[] args) {
        DocumentFactory wordFactory = new WordDocumentFactory();
        Document wordDoc = wordFactory.createDocument("MyDocument.docx");
        wordDoc.open();
        wordDoc.save();
        DocumentFactory pdfFactory = new PdfDocumentFactory();
        Document pdfDoc = pdfFactory.createDocument("MyDocument.pdf");
        pdfDoc.open();
        pdfDoc.save();
        DocumentFactory excelFactory = new ExcelDocumentFactory();
        Document excelDoc = excelFactory.createDocument("MyDocument.xlsx");
        excelDoc.open();
        excelDoc.save();
    }
}