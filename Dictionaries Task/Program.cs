namespace Dictionaries_Task
{
    internal class Program
    {
        static List<(int AID, string Aname, string email, string pas)> Admin = new List<(int AID, string Aname, string email, string pas)>();
        Dictionary<string, HashSet<string>> Enrollment_System = new Dictionary<string, HashSet<string>>();
        static List<(int SID,string Semail, string Spas)> Student = new List<(int SID, string Semail, string Spas)>();
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


                            break;

                        case "B":
                           

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
    }
    }

