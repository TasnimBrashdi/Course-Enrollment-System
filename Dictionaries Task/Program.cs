namespace Dictionaries_Task
{
    internal class Program
    {
        static List<(int AID, string Aname, string email, string pas)> Admin = new List<(int AID, string Aname, string email, string pas)>();
        Dictionary<string, HashSet<string>> Enrollment_System = new Dictionary<string, HashSet<string>>();
        static List<(int SID,string SName,string Semail, string Spas)> Student = new List<(int SID, string SName, string Semail, string Spas)>();
        static List<(int ID, string Name, string code)> Course = new List<(int ID, string Name, string code)>();
        static string Adminf = "C:\\Users\\Codeline User\\Documents\\FILEDIS\\Admin.txt";
        static void Main(string[] args)
        {

            bool ExitFlag = false;
           
            try
            {
                do
                {
                    Console.WriteLine("\n   - - - -   Course Enrollment System   - - - -  ");
                    Console.WriteLine("\n Choose: \n A- Log in Admin \n B- Log in Student  \n C- Log out ");


                    string choice = Console.ReadLine()?.ToUpper();

                    switch (choice)
                    {
                        case "A":
                            laodAdmin();
                            LoginAdmin();
                            break;

                        case "B":
                            LoginStudent();

                            break;
                        case "C":

                            ExitFlag = true;

                            break;
                    
                        default:
                            Console.WriteLine("Sorry your choice was wrong");
                            break;

                    }

                 

                } while (ExitFlag != true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR" + ex.Message);
            }
        }
        static void LoginAdmin()
        {

            Console.WriteLine("Enter your Email");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email cannot be empty.");
                return;
            }
          
           
            bool flag = false;
            try
            {
                for (int i = 0; i < Admin.Count; i++)
                {
                    if (Admin[i].email == email)
                    {
                        Console.WriteLine("Enter your Password");
                        string pas = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(pas))
                        {
                            Console.WriteLine("Password cannot be empty.");
                            return;
                        }
                        if (Admin[i].pas == pas)
                        {
                            Console.WriteLine("re-enter password your Password");
                            string pas2 = Console.ReadLine();
                            if (pas == pas2)
                            {
                                Console.WriteLine("WELCOME: " + Admin[i].Aname);
                                flag = true;

                                break;
                            }
                        }
                    }
                }

                if (flag != true)
                { Console.WriteLine("Admin not found Or input invaild"); }
            }

            catch (Exception e)
            {
                Console.WriteLine("Erorr" + e.Message);

            }




        }
        static void LoginStudent()
        {

            Console.WriteLine("Enter your Email");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email cannot be empty.");
                return;
            }


            bool flag = false;
            try
            {
                for (int i = 0; i < Student.Count; i++)
                {
                    if (Student[i].Semail == email)
                    {
                        Console.WriteLine("Enter your Password");
                        string pas = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(pas))
                        {
                            Console.WriteLine("Password cannot be empty.");
                            return;
                        }
                        if (Student[i].Spas == pas)
                        {
                            Console.WriteLine("re-enter password your Password");
                            string pas2 = Console.ReadLine();
                            if (pas == pas2)
                            {
                                Console.WriteLine("WELCOME: " + Student[i].SName);
                                flag = true;

                                break;
                            }
                        }
                    }
                }

                if (flag != true)
                { Console.WriteLine("Student not found Or input invaild"); }
            }

            catch (Exception e)
            {
                Console.WriteLine("Erorr" + e.Message);

            }




        }
        static void laodAdmin()
        {
            try
            {
                if (File.Exists(Adminf))
                {
                    using (StreamReader reader = new StreamReader(Adminf))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var parts = line.Split(" | ");
                            if (parts.Length == 4)
                            {
                                Admin.Add((int.Parse(parts[0]), parts[1], parts[2], parts[3]));
                            }
                        }
                    }
                    Console.WriteLine("Admin loaded from file successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading from file: {ex.Message}");
            }
        }
    }
    }

