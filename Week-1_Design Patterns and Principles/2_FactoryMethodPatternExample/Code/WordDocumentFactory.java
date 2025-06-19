class WordDocumentFactory extends DocumentFactory {
    @Override
    Document createDocument(String name) {
        return new WordDocument(name);
    }
}