
class Program
{
    static UserList userList;
    static Login current_login;
    static Seat seat;
    static Payment payment;
    static Register register;

    static void Main(string[] args)
    {
        PrepareUserList();
        PrepareLoginStatus();
        PrepareSeat();
        PreparePayment();
        PrepareRegister();
        int selected = 0;
        while (true)
        {
            ShowMenu(current_login, ref selected, register);
        }
    }







    static void ShowMenu(Login current_login, ref int selected, Register register)
    {
        if (current_login.GetIs_login() == false)
        {
            selected = SelectMenuNotLogin();
            Console.Clear();
        }
        else if (current_login.GetIs_login() == true)
        {
            selected = SelectMenuLogin();
            Console.Clear();
        }
        switch (selected)
        {
            case 1:
                register.InputAndCheckUser(userList);
                break;
            case 2:
                current_login.LogingIn(userList);
                break;
            case 3:
                bool Is_loop = true;
                bool Is_complete = false;
                while (Is_loop)
                {
                    seat.Reserve(current_login.GetCurrentUser(), ref Is_loop, ref Is_complete);
                    if (Is_complete)
                    {
                        payment.PrintReserveSeatInfo(seat.GetReserveSeatA(),seat.GetReserveSeatB(),current_login.GetCurrentUser());
                        payment.PrintResult(seat.GetReserveSeatA(),seat.GetReserveSeatB(),current_login.GetCurrentUser());

                    }
                }
                break;
            case 4:
                if (seat.GetReserveSeatA().Count == 0 &&
                    seat.GetReserveSeatB().Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Please book your seat first.");
                    return;
                }
                payment.PrintResult(seat.GetReserveSeatA(),seat.GetReserveSeatB(),current_login.GetCurrentUser());
                break;
            case 5:
                current_login.Logout();
                break;
        }
    }
    static void PrepareRegister(){
        Program.register=new Register();
    }
    static void PrepareUserList()
    {
        Program.userList = new UserList();
    }
    static void PrepareLoginStatus()
    {
        Program.current_login = new Login(false);
    }
    static void PrepareSeat()
    {
        Program.seat = new Seat();
    }
    static void PreparePayment()
    {
        Program.payment = new Payment();
    }
    static int SelectMenuNotLogin()
    {
        Console.WriteLine("Menu");
        Console.WriteLine("************************************************************************");
        Console.WriteLine("1.Register");
        Console.WriteLine("2.Login");

        bool Is_correct = false;
        do
        {
            switch (Console.ReadLine())
            {
                case "1":
                    return 1;
                case "2":
                    return 2;
                default:
                    Is_correct = true;
                    Console.WriteLine("Incorrect Input. Please select 1-2.");
                    break;
            }
        } while (Is_correct);
        return 0;
    }
    static int SelectMenuLogin()
    {
        Console.WriteLine("Menu");
        Console.WriteLine("************************************************************************");
        Console.WriteLine("1.Start reserve");
        Console.WriteLine("2.Reserve result");
        Console.WriteLine("3.Logout");

        bool Is_correct = false;
        do
        {
            switch (Console.ReadLine())
            {
                case "1":
                    return 3;
                case "2":
                    return 4;
                case "3":
                    return 5;
                default:
                    Is_correct = true;
                    Console.WriteLine("Incorrect Input. Please select 1-2.");
                    break;
            }
        } while (Is_correct);
        return 0;
    }
}
