namespace AppTransport.Models;

public class Address
{
    private int _id;
    private string _city;
    private string _street;
    private int _home;

    public Address(int id, string city, string street, int home)
    {
        _id = id;
        _city = city;
        _street = street;
        _home = home;
    }

    public int Id => _id;

    public string City => _city;

    public string Street => _street;

    public int Home => _home;
    
    public string DisplayInfo => _city + " | " + _street + " | " + _home;
}