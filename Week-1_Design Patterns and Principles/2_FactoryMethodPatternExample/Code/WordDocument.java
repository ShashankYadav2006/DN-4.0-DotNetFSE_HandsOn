class WordDocument extends Document {
    public WordDocument(String name) {
        super(name);
    }
    @Override
    void open() {
        System.out.println("Opening Word document: " + name);
    }
    @Override
    void save() {
        System.out.println("Saving docs " + name);
    }
}