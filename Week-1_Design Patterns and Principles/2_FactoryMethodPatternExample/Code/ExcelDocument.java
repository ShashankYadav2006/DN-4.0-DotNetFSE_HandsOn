class ExcelDocument extends Document {
    public ExcelDocument(String name) {
        super(name);
    }
    @Override
    void open() {
        System.out.println("Launching Excel sheet: " + name);
    }
    @Override
    void save() {
        System.out.println("Saving spreadsheet " + name);
    }
}