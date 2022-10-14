public class UserList
{
    private List<User> userList;
    public UserList()
    {
        this.userList = new List<User>();
    }
    public void AddUser(User user)
    {
        this.userList.Add(user);
    }
    public List<User> GetUserList()
    {
        return this.userList;
    }
}