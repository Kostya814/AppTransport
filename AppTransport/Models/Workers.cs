namespace AppTransport.Models;

public class Workers
{
    private int _id;
    private string _name;
    private string _secondName;
    private string _lastName;

    public Workers(int id, string name, string secondName, string lastName)
    {
        _id = id;
        _name = name;
        _secondName = secondName;
        _lastName = lastName;
    }

    public int Id => _id;

    public string Name => _name;

    public string SecondName => _secondName;

    public string LastName => _lastName;
    
    public string DisplayInfo => _name + " | " + _secondName + " | " + _lastName;
}