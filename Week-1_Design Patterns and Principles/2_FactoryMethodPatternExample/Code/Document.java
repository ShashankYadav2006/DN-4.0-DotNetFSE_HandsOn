abstract class Document {
    String name;
    public Document(String name) {
        this.name = name;
    }
    abstract void open();
    abstract void save();
    public String getName() {
        return name;
    }
}