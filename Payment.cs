public class Payment
{
    private double price_user = 5235.25;
    private double price_student = 1200.50;
    private double totalPrice = 0;
    private string paymentMethodType;
    private string accountName;
    private string accountNumber;
    private string cardHolderName;
    private string cardNumber;
    private string cardExpireDate;
    private string cardCVV;

    public void PrintReserveSeatInfo(List<string> reserveSeatA,List<string> reserveSeatB,User current_User)
    {
        ShowReserveSeat(reserveSeatA,reserveSeatB, current_User);
        ShowPaymentMenu();
        SelectPaymentMethod(current_User);
        this.totalPrice = 0;
    }
    void ShowReserveSeat(List<string> reserveSeatA,List<string> reserveSeatB,User currentUser)
    {
        Console.WriteLine(" ");
        Console.Write("Seat type A: ");
        ShowSeat(reserveSeatA);
        CalcPrice(reserveSeatA.Count);
        Console.WriteLine(" ");
        Console.Write("Seat type B: ");
        ShowSeat(reserveSeatB);
        CalcPrice(reserveSeatB.Count, currentUser);
        Console.WriteLine(" ");
    }
    void ShowSeat(List<string> reserveSeat)
    {
        foreach (string s in reserveSeat)
        {
            Console.Write(s + " ");
        }
    }
    void CalcPrice(int reserveAmount)
    {
        this.totalPrice += (reserveAmount * this.price_user);
        Console.Write(" | Total {0} bath.", reserveAmount * this.price_user);
    }
    void CalcPrice(int reserveAmount, User current_User)
    {
        if (current_User is Student_User)
        {
            this.totalPrice += (reserveAmount * this.price_student);
            Console.Write(" | Total {0} bath.", reserveAmount * this.price_student);
        }
        else
        {
            if (current_User is User)
            {
                this.totalPrice += (reserveAmount * this.price_user);
                Console.Write(" | Total {0} bath.", reserveAmount * this.price_user);
            }
        }
    }
    void ShowPaymentMenu()
    {
        Console.WriteLine("Select Payment Method");
        Console.WriteLine("**********************");
        Console.WriteLine("1.Banking");
        Console.WriteLine("2.Credit Card");
        Console.WriteLine("3.Cancel Reserve");
    }
    void SelectPaymentMethod(User currentUser)
    {
        bool Is_correct = false;
        do
        {
            switch (Console.ReadLine())
            {
                case "1":
                    currentUser.RecieveReserveA(currentUser.GetReserveSeatA());
                    currentUser.RecieveReserveB(currentUser.GetReserveSeatB());
                    this.paymentMethodType = "Banking";
                    BankingMethod();
                    break;
                case "2":
                    currentUser.RecieveReserveA(currentUser.GetReserveSeatA());
                    currentUser.RecieveReserveB(currentUser.GetReserveSeatB());
                    this.paymentMethodType = "Credit Card";
                    CreditCardMethod();
                    break;
                case "3":
                    Console.Clear();
                    return;
                default:
                    Is_correct = true;
                    Console.WriteLine("Incorrect Input. Please select 1-3.");
                    break;
            }
        } while (Is_correct);
        Console.Clear();
    }
    void BankingMethod()
    {
        Console.Write("Account name: ");
        this.accountName = Console.ReadLine();
        Console.Write("Account number: ");
        this.accountNumber = Console.ReadLine();
    }
    void CreditCardMethod()
    {
        Console.Write("Card holder name: ");
        this.cardHolderName = Console.ReadLine();
        Console.Write("Card number: ");
        this.cardNumber = Console.ReadLine();
        Console.Write("Card expire date: ");
        this.cardExpireDate = Console.ReadLine();
        Console.Write("Card CVV: ");
        this.cardCVV = Console.ReadLine();
    }
    void PrintUserType(User current_User)
    {
        Console.Write("User type: ");
        if (current_User is Student_User)
        {
            Console.Write("Student user");
        }
        else
        {
            Console.Write("Normal user");
        }
    }
    void PrintBankingResult()
    {
        Console.WriteLine("Account name: {0}", this.accountName);
        Console.WriteLine("Account number: {0}", this.accountNumber);
    }
    void PrintCreditCardResult()
    {
        Console.WriteLine("Card holder name: {0}", this.cardHolderName);
        Console.WriteLine("Card number: {0}", this.cardNumber);
        Console.WriteLine("Card expire date: {0}", this.cardExpireDate);
        Console.WriteLine("Card CVV: {0}", this.cardCVV);
    }
    public void PrintResult(List<string> reserveSeatA,List<string> reserveSeatB,User currentUser)
    {
        Console.Clear();
        Console.WriteLine("Reserving Result");
        Console.WriteLine("************************************************************************");
        PrintUserType( currentUser);
        ShowReserveSeat(reserveSeatA,reserveSeatB, currentUser);
        Console.WriteLine("Total Price: {0} bath.", this.totalPrice);
        this.totalPrice = 0;
        Console.WriteLine("Payment type: {0}", this.paymentMethodType);
        switch (this.paymentMethodType)
        {
            case "Banking":
                PrintBankingResult();
                break;
            case "Credit Card":
                PrintCreditCardResult();
                break;
            default:

                break;
        }
        Console.WriteLine("Enter to back to menu.");
        Console.ReadLine();
        Console.Clear();
    }
}