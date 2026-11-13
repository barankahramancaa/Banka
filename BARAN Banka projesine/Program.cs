using System.ComponentModel;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace BARAN_Banka_projesine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();
            accounts.Add(new Account("BARAN", 300));
            accounts.Add(new SavingsAccount("AYŞE", 1000));
            accounts.Add(new CheckingAccount("MEHMET", 300));

            Console.WriteLine("1-HESAP AÇ");
            Console.WriteLine("2-PARA YATIR");
            Console.WriteLine("3-PARA ÇEK");
            Console.WriteLine("4-HESAPLARI LİSTELE");
            Console.WriteLine("5-İŞLEM GEÇMİŞİ");

            Console.WriteLine("0-ÇIKIŞ");
            Console.Write("SEÇİMİNİZ: ");
            int choice = int.Parse(Console.ReadLine());

            while (choice != 0)
            {
                if (choice == 1)
                {
                    Console.Write("HESAP SAHİBİ: ");
                    string owner = Console.ReadLine();
                    Console.Write("Hesap türü (1-Normal, 2-Vadeli, 3-Vadesiz): ");
                    int type = int.Parse(Console.ReadLine());

                    if (type == 1)
                    {
                        accounts.Add(new Account(owner, 0));
                    }
                    else if (type == 2)
                    {
                        accounts.Add(new SavingsAccount(owner, 0));
                    }
                    else if (type == 3)
                    {
                        accounts.Add(new CheckingAccount(owner, 0));
                    }

                    Console.WriteLine("Hesap açıldı!");
                }
                else if (choice == 2)
                {
                    Console.Write("Hesap numarası: ");
                    int no = int.Parse(Console.ReadLine());
                    Console.Write("Miktar: ");
                    double amount = double.Parse(Console.ReadLine());
                    accounts[no - 1].Deposit(amount);
                }
                else if (choice == 3)
                {
                    Console.Write("Hesap numarası: ");
                    int no = int.Parse(Console.ReadLine());
                    Console.Write("Miktar: ");
                    double amount = double.Parse(Console.ReadLine());
                    accounts[no - 1].Withdraw(amount);
                }
                else if (choice == 4)
                {
                    for (int i = 0; i < accounts.Count; i++)
                    {
                        Console.Write($"{i + 1}. ");
                        accounts[i].ShowInfo();
                    }
                }
                else if(choice==5)
                {
                    Console.Write("HESAP NUMARASI:");
                    int no=int.Parse(Console.ReadLine());

                    foreach (string item  in accounts[no-1].History)
                    {
                        Console.WriteLine($"- {item} ");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("1-HESAP AÇ");
                Console.WriteLine("2-PARA YATIR");
                Console.WriteLine("3-PARA ÇEK");
                Console.WriteLine("4-HESAPLARI LİSTELE");
                Console.WriteLine("5-İŞLEM GEÇMİŞİ");

                Console.WriteLine("0-ÇIKIŞ");
                Console.Write("SEÇİMİNİZ: ");
                choice = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Görüşürüz!");
        }
    }
}

class Account
{
    public string Owner { get; set; }
    public double Balance { get; protected set; }

    public Account(string owner, double balance)
    {
        Owner = owner;
        Balance = balance;
        History = new List<string>();
    }
    public List<string> History { get; }
    
    public void Deposit(double amount)
    {
        Balance = Balance + amount;
        Console.WriteLine($"{amount} TL yatırıldı. Yeni bakiye: {Balance} TL");
        History.Add($"{amount} TL yatırıldı ");
    }

    public virtual void Withdraw(double amount)
    {
        if (amount <= Balance)
        {
            Balance = Balance - amount;
            Console.WriteLine($"{amount} TL çekildi. Yeni bakiye: {Balance} TL");
            History.Add($"{amount} TL çekildi");

        }
        else
        {
            Console.WriteLine("Yetersiz bakiye!");
        }
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Hesap sahibi: {Owner} - Bakiye: {Balance} TL");
    }
}

class SavingsAccount : Account, IInterest
{
    public SavingsAccount(string owner, double balance) : base(owner, balance)
    {
    }

    public void AddInterest(double rate)
    {
        double interest = Balance * rate / 100;
        Balance = Balance + interest;
        Console.WriteLine($"{interest} TL faiz eklendi. Yeni bakiye: {Balance} TL");
            History.Add($"{interest} TL faiz eklendi");



    }
}

class CheckingAccount : Account
{
    public CheckingAccount(string owner, double balance) : base(owner, balance)
    {
    }

    public override void Withdraw(double amount)
    {
        if (amount <= Balance + 1000)
        {
            Balance = Balance - amount;
            Console.WriteLine($"{amount} TL çekildi. Yeni bakiye: {Balance} TL");
            History.Add($"{amount} TL çekildi");
        }
        else
        {
            Console.WriteLine("Ek hesap limiti aşıldı!");
        }
    }
}

interface IInterest
{
    void AddInterest(double rate);
}