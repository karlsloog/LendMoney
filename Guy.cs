using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendMoney
{
    internal class Guy
    {
        public string Name;
        public int Cash;

        /// <summary>
        /// writes my name and the amount of cash i have to the console
        /// </summary>
        public void WriteMyInfo()
        {
            Console.WriteLine(Name + " has " + Cash + " bucks. ");
        }

        /// <summary>
        /// gives cash, removing it from wallet
        /// printing a message if doesnt have enough cash
        /// </summary>
        /// <param name="amount">Amount of cast to give.</param>
        /// <returns>
        /// the amount of cash removed from wallet, or 0 if dont have enough cash
        /// or if the amount is invalid
        /// </returns>
        public int GiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(Name + " says: " + amount + " isn't a valid amount");
            }
            if (amount > Cash) 
            {
                Console.WriteLine(Name + " says: " + "I don't have enough cash to give you " + amount);
                return 0;
            }
            Cash -= amount;
            return amount;
        }

        /// <summary>
        /// receive cash, adding it to wallet
        /// or printing message to console if doesnt have enough cash
        /// </summary>
        /// <param name="amount">amount of cast to give</param>
        public void ReceiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(Name + " says: " + amount + " isn't an amount I'll take");
            }
            else
            {
                Cash += amount;
            }
        }

        static void Main(string[] args)
        {
            Guy joe = new Guy() { Cash = 50, Name = "Joe"};
            Guy bob = new Guy() { Cash = 100, Name = "Bob" };

            while (true)
            {
                joe.WriteMyInfo();
                bob.WriteMyInfo();
                Console.Write("Enter the amount: ");
                string howMuch = Console.ReadLine();
                if (howMuch == "") return;
                if (int.TryParse(howMuch, out int amount))
                {
                    Console.Write("Who should give the cash: ");
                    string whichGuy = Console.ReadLine();
                    if (whichGuy == "Joe" || whichGuy == "joe")
                    {
                        int cashGiven = joe.GiveCash(amount);
                        bob.ReceiveCash(cashGiven);
                    }
                    else if (whichGuy == "bob" || whichGuy == "Bob")
                    {
                        int cashGiven = bob.GiveCash(amount);
                        joe.ReceiveCash(cashGiven);
                    }
                    else
                    {
                        Console.WriteLine("Please enter 'Joe' or 'Bob' ");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter an amount (or a blank line to exit).");
                }
            }
        }
            
    }
}
