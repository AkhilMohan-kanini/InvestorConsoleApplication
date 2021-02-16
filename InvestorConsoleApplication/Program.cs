using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            bool start_menu=true;

            Console.WriteLine("******************************** \n Investment App \n ********************************\n");

             // Menu Options
            while(start_menu)
            {
                Console.WriteLine("Please Enter Your Option : \n");
                Console.WriteLine("1. Add New Investor \n2. Investor Details \n3. Close the App \n");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        InvestorDetail.AddNewInvestor();
                        break;
                    case 2:
                        InvestorDetail.ShowDetails();
                        break;
                    case 3:
                        start_menu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }

            
        }
    }
}
