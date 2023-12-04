namespace AppTransport.Models;

public class Marks
{
    private int _id;
    private string _name;

    public Marks(int id, string name)
    {
        _id = id;
        _name = name;
    }

    public int Id => _id;

    public string Name => _name;
}