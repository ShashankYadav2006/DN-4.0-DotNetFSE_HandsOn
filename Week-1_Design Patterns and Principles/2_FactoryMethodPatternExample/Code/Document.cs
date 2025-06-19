public abstract class Document
{
    protected string name;
    public Document(string name)
    {
        this.name = name;
    }
    public abstract void Open();
    public abstract void Save();
    public string GetName()
    {
        return name;
    }
}
