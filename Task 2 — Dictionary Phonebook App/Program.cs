// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
namespace Phonebook{

    class Program{
    
    static Dictionary<string , string> user=new Dictionary<string , string>();
        public static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n==================================");
                Console.WriteLine("       PHONEBOOK MANAGEMENT       ");
                Console.WriteLine("==================================");
                Console.WriteLine(" Press 1.For Add Contact");
                Console.WriteLine("Press 2. For Search Contact");
                Console.WriteLine("Press 3. For Update Contact");
                Console.WriteLine("Press 4. For Delete Contact");
                Console.WriteLine("Press 5. For List All (Sorted)");
                Console.WriteLine("Press6. For Exit");
                Console.Write("Enter choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddContact();
                        break;
                    case 2:
                        SearchContact();
                        break;
                    case 3:
                        UpdateContact();
                        break;
                    case 4:
                        DeleteContact();
                        break;
                    case 5:
                        ListAllContacts();
                        break;
                    case 6:
                        running = false;
                        Console.WriteLine("Exiting the program...");
                        break;
                }
            }
        }
                public static void AddContact()
                {
            Console.WriteLine("Enter contact name: ");
            string name = Console.ReadLine().Trim();

            Console.WriteLine("Enter contact number: ");
            string number = Console.ReadLine().Trim();
            if (name ==null || number == null) {
            Console.WriteLine("Name or number cannot be empty.");
            }
            else if(user.ContainsKey(name) )
            {
                Console.WriteLine("Contact already exists.");
            }
            else
            {
                user.Add(name, number);
                Console.WriteLine("Contact added successfully.");
            }
            {
                 
            }


        }
        public static void SearchContact()
        {
            Console.WriteLine("Enter NAme for Search :");
            string name= Console.ReadLine().Trim();
            if(user.ContainsKey(name))
            {
                Console.WriteLine($"Contact found: {name} - {user[name]}");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }

        }
        public static void UpdateContact()
        {
            Console.WriteLine("Enter contact name to update: ");
            string name = Console.ReadLine().Trim();
            if (user.ContainsKey(name)) { 
            Console.WriteLine("Enter new contact number: ");
                string num= Console.ReadLine().Trim();
                user[name] = num;
                Console.WriteLine("Contact updated successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
        public static void DeleteContact() { 
        Console.WriteLine("Enter contact name to delete: ");
            string name= Console.ReadLine().Trim();
            if (user.ContainsKey(name)) { 
             user.Remove(name);
                Console.WriteLine("Contact deleted successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }




        }
        public static void ListAllContacts()
        {
            Console.WriteLine("All Contact in Sorted way");
            for (int i = 0; i < user.Count; i++)
            {
                var sortedContacts = user.OrderBy(x => x.Key).ToList();
                Console.WriteLine("Name : " + $"{sortedContacts[i].Key} - Number : {sortedContacts[i].Value}");
            }

        }


    }

}
