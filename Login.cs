public class Login
{
    private bool Is_login;
    private User current_User;
    private int count;

    public Login(bool Is_login)
    {
        this.Is_login = Is_login;
    }
    public bool GetIs_login()
    {
        return this.Is_login;
    }
    public void Logout(){
        this.Is_login=false;
    }
    public void LogingIn(UserList userList)
    {
        string email = " ";
        string password = " ";
        do
        {
            Console.Write("Email: ");
            email = Console.ReadLine();
            if (email == "exit")
            {
                Console.Clear();
                return;
            }
            Console.Write("Password: ");
            password = Console.ReadLine();
        } while (!Is_exist(userList, email, password));
        this.current_User = userList.GetUserList().ElementAt(this.count);
        this.Is_login = true;
        Console.Clear();
    }
    bool Is_exist(UserList userList, string email, string password)
    {
        for (int i = 0; i < userList.GetUserList().Count; i++)
        {
            if (email == userList.GetUserList().ElementAt(i).GetEmail() &&
                password == userList.GetUserList().ElementAt(i).GetPassword())
            {
                this.count = i;
                return true;
            }
        }
        count = 0;
        Console.WriteLine("Incorrect email or password. Please try again.");
        return false;
    }
    public User GetCurrentUser()
    {
        return this.current_User;
    }

}