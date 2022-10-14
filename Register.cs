public class Register
{
    private string userType = " ";
    string SelectUserType()
    {
        Console.WriteLine("Select user type");
        Console.WriteLine("******************");
        Console.WriteLine("1. User");
        Console.WriteLine("2. Student");

        bool Is_correct = false;
        do
        {
            switch (Console.ReadLine())
            {
                case "1":
                    return "User";
                    break;
                case "2":
                    return "Student";
                    break;
                default:
                    Is_correct = true;
                    Console.WriteLine("Incorrect Input. Please select 1-2.");
                    break;
            }
        } while (Is_correct);
        return null;
    }
    string SelectTitle()
    {
        Console.WriteLine("Select your title");
        Console.WriteLine("******************");
        Console.WriteLine("1. Mr.");
        Console.WriteLine("2. Mrs.");
        Console.WriteLine("3. Miss");

        bool Is_correct = false;
        do
        {
            switch (Console.ReadLine())
            {
                case "1":
                    return "Mr.";
                    
                case "2":
                    return "Mrs.";
                    
                case "3":
                    return "Miss";
                    
                default:
                    Is_correct = true;
                    Console.WriteLine("Incorrect Input. Please select 1-3.");
                    break;
            }
        } while (Is_correct);
        return null;
    }
    string InputName()
    {
        Console.Write("Name: ");
        return Console.ReadLine();
    }
    string InputSurName()
    {
        Console.Write("Surname: ");
        return Console.ReadLine();
    }
    int InputAge()
    {
        Console.Write("Age: ");
        return int.Parse(Console.ReadLine());
    }
    string InputEmail()
    {
        Console.Write("Email: ");
        return Console.ReadLine();
    }
    string InputPassword()
    {
        Console.Write("Password: ");
        return Console.ReadLine();
    }
    string InputConfirmPassword()
    {
        Console.Write("Confirm Password: ");
        return Console.ReadLine();
    }
    string InputStudentID()
    {
        Console.Write("Student ID: ");
        return Console.ReadLine();
    }

    bool CheckTitleNameSurname(string title, string name, string surName, string userType, UserList userList)
    {
        for (int i = 0; i < userList.GetUserList().Count; i++)
        {
            if (title == userList.GetUserList().ElementAt(i).GetTitle() &&
                name == userList.GetUserList().ElementAt(i).GetName() &&
                surName == userList.GetUserList().ElementAt(i).GetSurName())
            {
                Console.WriteLine("User is already registered. Please try again.");
                return false;
            }
        }
        return true;
    }
    bool CheckEmail(string email, string userType, UserList userList)
    {
        for (int i = 0; i < userList.GetUserList().Count; i++)
        {
            if (email == userList.GetUserList().ElementAt(i).GetEmail())
            {
                Console.WriteLine("Invalid email. Please try again.");
                return false;
            }
        }
        return true;
    }
    bool CheckPassword(string password, string confirm_password, string userType, UserList userList)
    {
        if (password != confirm_password)
        {
            Console.WriteLine("Mismatched passwords. Please try again.");
            return false;
        }
        return true;
    }
    public void InputAndCheckUser(UserList userList)
    {
        int compareCount = userList.GetUserList().Count;
        if (this.userType == " ")
        {
            this.userType = SelectUserType();
        }
        while (compareCount == userList.GetUserList().Count)
        {
            FillInfo(userType, userList);
        }
        Console.Clear();
    }
    void FillInfo(string userType, UserList userList)
    {
        string title = SelectTitle();
        string name = InputName();
        string surName = InputSurName();
        if (userList.GetUserList().Count != 0)
        {
            if (CheckTitleNameSurname(title, name, surName, userType, userList) == false)
            {
                return;
            }
        }
        string std_ID = "null";
        if (userType == "Student")
        {
            std_ID = InputStudentID();
        }
        int age = InputAge();
        string email = InputEmail();
        if (userList.GetUserList().Count != 0)
        {
            if (CheckEmail(email, userType, userList) == false)
            {
                return;
            }
        }
        string password = InputPassword();
        string confirm_password = InputConfirmPassword();
        if (CheckPassword(password, confirm_password, userType, userList) == false)
        {
            return;
        }
        if (userType == "Student")
        {
            Student_User user = new Student_User(userType, title, name, surName, age, email, password, std_ID);
            userList.AddUser(user);
            this.userType=" ";
        }
        else
        {
            User user = new User(userType, title, name, surName, age, email, password);
            userList.AddUser(user);
            this.userType=" ";
        }
    }
}