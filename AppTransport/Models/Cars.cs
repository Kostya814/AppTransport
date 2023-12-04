namespace AppTransport.Models;

public class Cars
{
    private int _id;
    private Marks _mark;
    private string _color;
    private string _number;
    private bool _isRepair;

    public Cars(int id, Marks mark, string color, string number, bool isRepair)
    {
        _id = id;
        _mark = mark;
        _color = color;
        _number = number;
        _isRepair = isRepair;
    }

    public int Id => _id;

    public Marks Mark => _mark;

    public string Color => _color;

    public string Number => _number;

    public bool IsRepair => _isRepair;
    
    public string DisplayInfo => _mark.Name + " | " + _color + " | " + _number;
}