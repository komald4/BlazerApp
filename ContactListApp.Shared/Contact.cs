namespace ContactListApp.Shared;

public class Contact
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<Address> Addresses { get; set; }
}

