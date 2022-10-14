public class Student_User : User
{
    private string std_ID;
    public Student_User(string userType, string title, string name, string surName,
                        int age, string email, string password, string std_ID)
                        : base(userType, title, name, surName, age, email, password)
    {
        this.std_ID = std_ID;
    }
}