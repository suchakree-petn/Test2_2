public class Seat
{
    private List<string> AvailableSeatA;
    private List<string> AvailableSeatB;
    private List<string> ReserveSeatA;
    private List<string> ReserveSeatB;
    public Seat()
    {
        this.AvailableSeatA = new List<string> { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "A10" };
        this.AvailableSeatB = new List<string> { "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9", "B10" };
        this.ReserveSeatA = new List<string>();
        this.ReserveSeatB = new List<string>();
    }
    public List<string> GetReserveSeatA()
    {
        return this.ReserveSeatA;
    }
    public List<string> GetReserveSeatB()
    {
        return this.ReserveSeatB;
    }
    public void Reserve(User currentUser, ref bool Is_loop, ref bool Is_complete)
    {
        while (true)
        {
            Console.Write("Enter a seat that you want to reserve(A1-A10 or B1-B10): ");
            string seat = Console.ReadLine();
            if (seat == "exit")
            {
                Is_loop = false;
                return;
            }
            else
            {
                if (seat == "checkout")
                {
                    currentUser.RecieveReserveA(this.ReserveSeatA);
                    currentUser.RecieveReserveB(this.ReserveSeatB);
                    if (this.ReserveSeatA.Count != 0 || this.ReserveSeatB.Count != 0)
                    {
                        Is_complete = true;
                        Is_loop = false;
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Is_loop = false;
                        Console.Clear();
                        return;
                    }
                }
            }
            if (FindSeatType(seat) == AvailableSeatA)
            {
                if (currentUser is Student_User)
                {
                    Console.WriteLine("Cannot book. Please try again.");
                    return;
                }
            }
            AddToReserve(seat);
        }

    }
    void AddToReserve(string seat)
    {
        if (this.FindSeatType(seat).Remove(seat) == false)
        {
            
            Console.WriteLine("Already booked. Please try again.");
        }
        else
        {
            this.FindReserveSeatType(seat).Add(seat);
            this.FindSeatType(seat).Remove(seat);
        }
    }
    List<string> FindSeatType(string seat)
    {
        char firstLetter = seat[0];
        if (firstLetter == 'A')
        {
            return this.AvailableSeatA;
        }
        else if (firstLetter == 'B')
        {
            return this.AvailableSeatB;
        }
        return null;
    }
    List<string> FindReserveSeatType(string seat)
    {
        char firstLetter = seat[0];
        if (firstLetter == 'A')
        {
            return this.ReserveSeatA;
        }
        else if (firstLetter == 'B')
        {
            return this.ReserveSeatB;
        }
        return null;
    }
}