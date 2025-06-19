class PdfDocumentFactory extends DocumentFactory {
    @Override
    Document createDocument(String name) {
        return new PdfDocument(name);
    }
}
