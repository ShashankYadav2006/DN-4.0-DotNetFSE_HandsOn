class PdfDocument extends Document {
    public PdfDocument(String name) {
        super(name);
    }
    @Override
    void open() {
        System.out.println("Opening PDF document: " + name);
    }
    @Override
    void save() {
        System.out.println("Saving PDF " + name);
    }
}