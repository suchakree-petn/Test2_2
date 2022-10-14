public class User : Seat
{
    private string userType;
    private string title;
    private string name;
    private string surName;
    private int age;
    private string email;
    private string password;
    private List<string> userReserveA;
    private List<string> userReserveB;
    public User(string userType, string title, string name, string surName, int age, string email, string password)
    {
        this.userType = userType;
        this.title = title;
        this.name = name;
        this.surName = surName;
        this.age = age;
        this.email = email;
        this.password = password;
        this.userReserveA = new List<string>();
        this.userReserveB = new List<string>();
    }
    public string GetTitle()
    {
        return this.title;
    }
    public string GetEmail()
    {
        return this.email;
    }
    public string GetPassword()
    {
        return this.password;
    }
    public string GetName()
    {
        return this.name;
    }
    public string GetSurName()
    {
        return this.surName;
    }
    public void RecieveReserveA(List<string> userReserveA)
    {
        this.userReserveA = userReserveA;
    }
    public void RecieveReserveB(List<string> userReserveB)
    {
        this.userReserveB = userReserveB;
    }
}