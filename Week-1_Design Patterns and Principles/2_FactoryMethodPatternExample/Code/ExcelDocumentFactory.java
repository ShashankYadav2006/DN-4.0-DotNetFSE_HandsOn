class ExcelDocumentFactory extends DocumentFactory {
    @Override
    Document createDocument(String name) {
        return new ExcelDocument(name);
    }
}