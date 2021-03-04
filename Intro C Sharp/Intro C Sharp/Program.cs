using System;

namespace Intro_C_Sharp

{
    class ATM
    {
        private CreditCard card;
        private uint id;
        public uint Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        private int money;
        public int Money
        {
            get
            {
                return money;
            }
            set
            {
                money = value;
            }
        }

        public ATM(uint id, int money, CreditCard card)
        {
            this.card = card;
            this.id = id;
            this.money = money;
        }
        public void ShowBalanceATM()
        {
            Console.WriteLine($"Balance in ATM: {Money}");
        }
        public void ShowBalanceCreditCard()
        {
            Console.WriteLine($"Balance in Credit Card: {card.Money}");
        }
        public void addMoney(uint money)
        {
            Money += Convert.ToInt32(money);
        }
        public bool Withdraw(string pin, uint sum)
        {
            if (card.PinCode == pin)
            {
                if (sum <= Money && card.Money >= sum)
                {
                    Money -= Convert.ToInt32(sum);
                    card.Money -= sum;
                    return true;
                }
                else
                {
                    if (sum > Money)
                    {
                        Console.WriteLine($"ATM didn't have enough money ATM have : {Money}");
                    }
                    else
                    {
                        Console.WriteLine($"You didn't have enough money in your credit card you  have : {card.Money}");
                    }
                }
            }
            else
            {
                Console.WriteLine("You enter bad pin");
            }
            return false;
        }
    }
    class CreditCard
    {
        public CreditCard(uint money, string pinCode)
        {
            Money = money;
            PinCode = pinCode;
        }
        private uint _money;
        private string pinCode;
        public uint Money
        {
            get
            {
                return _money;
            }
            set
            {
                _money = value;
            }
        }
        public string PinCode
        {
            get
            {
                return pinCode;
            }
            set
            {
                pinCode = value;
            }
        }
    }
    class Program
    {


        static void Main(string[] args)
        {

            CreditCard card = new CreditCard(4560, "1234");
            ATM atm = new ATM(1, 50000, card);
            string achion = Console.ReadLine();
            while (achion != "x")
            {
                Console.WriteLine("1.Show balance");
                Console.WriteLine("2.With draw");
                Console.WriteLine("x.Exit");
                achion = Console.ReadLine();

                switch (achion)
                {

                    case "1":
                        atm.ShowBalanceCreditCard();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Write("Enter sum to draw : ");
                        uint sum = uint.Parse(Console.ReadLine());
                        Console.Write("Enter pin : ");
                        string pin= Console.ReadLine();
                        bool isDraw  = atm.Withdraw(pin,sum);
                        if (isDraw) { atm.ShowBalanceCreditCard(); };
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "x":
                        break;
                    default:
                        break;
                }
            }

        }


    };
}

