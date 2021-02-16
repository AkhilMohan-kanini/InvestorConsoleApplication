using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace InvestorConsoleApplication
{
    class InvestorDetail
    {

        static int _id = 1;

        public int Id { get; set; }
        public string Name { get; set; }
        public string UniqueIdentifier { get; set; }
        public string FundName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Double Amount { get; set; }

        static List<InvestorDetail> InvestorList = new List<InvestorDetail>();

        static List<string> funds = new List<string>(){"Reliance", "Asian Paints", "Manappuram Fin",
                                               "Apollo Tyres", "Yes Bank" };

        public InvestorDetail(int id, string name, string uniqueIdentifier, string fundName, DateTime dateOfBirth, double amount)
        {
            this.Id = id;
            this.Name = name;
            this.UniqueIdentifier = uniqueIdentifier;
            this.FundName = fundName;
            this.DateOfBirth = dateOfBirth;
            this.Amount = amount;
        }

        public static void AddNewInvestor()
        {

            Console.WriteLine("Please Enter the Full Name : ");
            string name = Console.ReadLine();

            //Checks if Name is null or Empty
            try
            {

                Regex rgx = new Regex(@"^[a-zA-Z]+\s*[a-zA-Z]*$");

                if (string.IsNullOrEmpty(name) || !rgx.IsMatch(name))
                {
                    throw new ArgumentNullException();
                }

               
            }
            catch(ArgumentNullException )
            {
                Console.WriteLine("Name cannot be empty or Number.Please provide valid value \n");
                return;
            }

            //Date of Birth Input
            DateTime dob = default;

            //Checks If Date of Birth is Null Or Empty
            try
            {

                Console.WriteLine("Please Enter the Date of Birth (dd/mm/yyyy) : ");
                dob = DateTime.Parse(Console.ReadLine());

            }
            catch(FormatException)
            {
                Console.WriteLine("Date of birth cannot be empty. Please provide valid value \n");
                return;
            }

            //Pan Card Input
            Console.WriteLine("Please Enter the PanCard : ");
            string uIdentifier = Console.ReadLine();
            try
            {
                Regex rgx = new Regex("^[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}$");
                if(string.IsNullOrEmpty(uIdentifier) || !rgx.IsMatch(uIdentifier))
                {
                    throw new ArgumentNullException();
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Unique Identifier cannot be empty.Please provide valid value \n");
                return;
            }


            //Amount Input
            Console.WriteLine("Please Enter the amount to Invest :");
            double amount = Convert.ToDouble(Console.ReadLine());

            //Throws Exception  if amount is less than or equal to zero
            try
            {
                
                if(amount<=0 )
                {
                    throw new Exception("Incorrect amount entered.Please provide valid value");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect amount entered.Please provide valid value");
                return;
            }
            
            //Fund Name Input
            Console.WriteLine("Enter the Fund to Invest : ");

            int i = 1;
            foreach(string fund in funds)
            {
                Console.WriteLine("{0} - {1}", i++, fund);
            }

            int fundIndex = default;
            try
            {
                fundIndex = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Enter valid Choice for Fund Name");
                return;
            }
            string fundName = funds.ElementAt(fundIndex-1);

            try
            {
                if (string.IsNullOrEmpty(fundName))
                {
                    throw new Exception("fund name cannot be empty. Please provide valid value");
                }
            }
            catch
            {
                Console.WriteLine("fund name cannot be empty. Please provide valid value");
                return;
            }
            
            //Adds Investor object to List
            InvestorList.Add(new InvestorDetail(_id++, name, uIdentifier, fundName, dob, amount));

            Console.WriteLine("Investor Added Successfully");

            Console.WriteLine("Press any key to return to Main Menu\n");
            Console.ReadKey();

        }

        //Displays Investor Details
        public static void ShowDetails()
        {

            Console.WriteLine("***********************\n Investor Details \n ***********************\n");
                   
            foreach(InvestorDetail investor in InvestorList)
            {
                Console.WriteLine("\nInvestor ID : " + investor.Id);
                Console.WriteLine("Investor Name : " + investor.Name);
                Console.WriteLine("Investor Date of Birth : " + investor.DateOfBirth.ToString("dd-MM-yyyy"));
                Console.WriteLine("Investor PAN Card : " + investor.UniqueIdentifier);
                Console.WriteLine("Investor Amount : " + investor.Amount);
                Console.WriteLine("Fund Name : " + investor.FundName + "\n");
            }
        }

    }
}
