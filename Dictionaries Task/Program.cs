using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace Dictionaries_Task
{
    internal class Program
    {
        //static List<(int AID, string Aname, string email, string pas)> Admin = new List<(int AID, string Aname, string email, string pas)>();
        static Dictionary<string, HashSet<string>> courses = new Dictionary<string, HashSet<string>>();
        static List<(string code,string names)> WaitList = new List<(string code, string names)>();
        
        static Dictionary<string,int> courseCapacities = new Dictionary<string,int>();
        //static List<(int SID,string SName,string Semail, string Spas)> Student = new List<(int SID, string SName, string Semail, string Spas)>();
        //static List<(int ID, string Name, string code ,int Ma)> Course = new List<(int ID, string Name, string code,int Ma)>();


        static void Main(string[] args)
        {
            InitializeStartupData();
            bool ExitFlag = true;
           
            try
            {
                while (ExitFlag) 
                {
                    Console.WriteLine("\n Choose: \n A- Add a new course \n B- Remove Course  \n C- Enroll a student in a course \n D- Remove a student from a course \n E- Display all students in a course" +
                        "\n F- Display all courses and their students \n G- Find courses with common students \n H- Withdraw a Student from All Courses \n Z- Exit ");


                    string choice = Console.ReadLine()?.ToUpper();

                    switch (choice)
                    {
                        case "A":
                            Addcouse();

                            break;

                        case "B":
                            RemoveCourse();

                            break;
                        case "C":

                            EnrollStudent();
                            break;
                        case "D":

                            RemoveStudent();
                            break;
                        case "E":
                            Displayallstudentincourse();
                          

                            break;
                        case "F":
                            Displayallstudentandcourse();

                            break;
                        case "G":


                            break;
                        case "H":


                            break;
                        case "Z":

                            ExitFlag = false;

                            break;

                        default:
                            Console.WriteLine("Sorry your choice was wrong");
                            break;
                    }

                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR" + ex.Message);
            }
        }
        //static void LoginAdmin()
        //{

        //    Console.WriteLine("Enter your Email");
        //    string email = Console.ReadLine();
        //    if (string.IsNullOrWhiteSpace(email))
        //    {
        //        Console.WriteLine("Email cannot be empty.");
        //        return;
        //    }
          
           
        //    bool flag = false;
        //    try
        //    {
        //        for (int i = 0; i < Admin.Count; i++)
        //        {
        //            if (Admin[i].email == email)
        //            {
        //                Console.WriteLine("Enter your Password");
        //                string pas = Console.ReadLine();
        //                if (string.IsNullOrWhiteSpace(pas))
        //                {
        //                    Console.WriteLine("Password cannot be empty.");
        //                    return;
        //                }
        //                if (Admin[i].pas == pas)
        //                {
        //                    Console.WriteLine("re-enter password your Password");
        //                    string pas2 = Console.ReadLine();
        //                    if (pas == pas2)
        //                    {
        //                        Console.WriteLine("WELCOME: " + Admin[i].Aname);
        //                        AdminMenu();
        //                        flag = true;

        //                        break;
        //                    }
        //                }
        //            }
        //        }

        //        if (flag != true)
        //        { Console.WriteLine("Admin not found Or input invaild"); }
        //    }

        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Erorr" + e.Message);

        //    }




        //}
        //static void LoginStudent()
        //{

        //    Console.WriteLine("Enter your Email");
        //    string email = Console.ReadLine();
        //    if (string.IsNullOrWhiteSpace(email))
        //    {
        //        Console.WriteLine("Email cannot be empty.");
        //        return;
        //    }


        //    bool flag = false;
        //    try
        //    {
        //        for (int i = 0; i < Student.Count; i++)
        //        {
        //            if (Student[i].Semail == email)
        //            {
        //                Console.WriteLine("Enter your Password");
        //                string pas = Console.ReadLine();
        //                if (string.IsNullOrWhiteSpace(pas))
        //                {
        //                    Console.WriteLine("Password cannot be empty.");
        //                    return;
        //                }
        //                if (Student[i].Spas == pas)
        //                {
        //                    Console.WriteLine("re-enter password your Password");
        //                    string pas2 = Console.ReadLine();
        //                    if (pas == pas2)
        //                    {
        //                        Console.WriteLine("WELCOME: " + Student[i].SName);
        //                        flag = true;

        //                        break;
        //                    }
        //                }
        //            }
        //        }

        //        if (flag != true)
        //        { Console.WriteLine("Student not found Or input invaild"); }
        //    }

        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Erorr" + e.Message);

        //    }




        //}
        //static void laodAdmin()
        //{
        //    try
        //    {
        //        if (File.Exists(Adminf))
        //        {
        //            using (StreamReader reader = new StreamReader(Adminf))
        //            {
        //                string line;
        //                while ((line = reader.ReadLine()) != null)
        //                {
        //                    var parts = line.Split(" | ");
        //                    if (parts.Length == 4)
        //                    {
        //                        Admin.Add((int.Parse(parts[0]), parts[1], parts[2], parts[3]));
        //                    }
        //                }
        //            }
        //            Console.WriteLine("Admin loaded from file successfully.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error loading from file: {ex.Message}");
        //    }
        //}
        static void AdminMenu()
        {
          
        }
        static void Addcouse()
        {
            int id;
            Console.WriteLine("Enter Number of course You want to add");
            int NOFcourse=int.Parse(Console.ReadLine());
            for (int i = 0; i < NOFcourse; i++) {
                Console.WriteLine($"Insert Code of Course {i + 1}");
                string code = Console.ReadLine();
                Console.WriteLine($"Insert Max number of student {i+1}");
                int Max = int.Parse(Console.ReadLine());
         


                courseCapacities.Add(code,Max);
                courses.Add(code,new HashSet<string>());

            }
            Console.WriteLine("Courses added successfully");

        }
       
        static void RemoveCourse()
        {
            Console.WriteLine("Enter the course code to remove");
            string coderemove=Console.ReadLine();
            
              
                    if (courses.ContainsKey(coderemove))
                    {
                        courseCapacities.Remove(coderemove);
                        courses.Remove(coderemove);
                        Console.WriteLine("course removed");
                    }
                    else
                    {
                        Console.WriteLine("Not found");
                    }
                }
          
        
        static void EnrollStudent() {
            Console.WriteLine("Enter name of student: ");
            string  nameeroll=Console.ReadLine();
            Console.WriteLine("Enter code of course: ");
            string codeeroll = Console.ReadLine();

            if (courses.ContainsKey(codeeroll))
            {
                var student = courses[codeeroll];
                if (student.Contains(nameeroll))
                {

                    Console.WriteLine("student is enrolled befor in course");
                }

                else if (courses.Count >= courseCapacities.Count)
                {
                    Console.WriteLine("course Fall");
                    WaitList.Add((nameeroll, codeeroll));
                }
                else
                {
                    courses[codeeroll].Add(nameeroll);
                }
            }
            else { Console.WriteLine("Not found"); }

            


        }
        static void RemoveStudent()
        {
           
            Console.WriteLine("\n List of courses and student:");
            foreach (KeyValuePair<string,HashSet<string>> v in courses)
            {
                Console.WriteLine($"{v.Key}: {string.Join(", ", v.Value)}");
            }

            Console.WriteLine("Enter code course");
            string code = Console.ReadLine();
            Console.WriteLine("Enter Name of student to remove");
            string name=Console.ReadLine();
          
            //var student = courses[name];
            if (courses.ContainsKey(code))
            {
               foreach(string n in courses[code])
                {
                    if (n==name) {
                        courses[code].Remove(n);
                        Console.WriteLine("student removed");
                    }
                    
                   
               }
             
            }
            else {
                Console.WriteLine("Not found");
            }

        }
        static void InitializeStartupData()
        {
            // Example data: Courses and their enrolled students (cross-over students)
            courses["CS101"] = new HashSet<string> { "Alice", "Bob", "Charlie" };   // CS101 has Alice, Bob, Charlie
            courses["MATH202"] = new HashSet<string> { "David", "Eva", "Bob" };     // MATH202 has David, Eva, and Bob (cross-over with CS101)
            courses["ENG303"] = new HashSet<string> { "Frank", "Grace", "Charlie" };// ENG303 has Frank, Grace, and Charlie (cross-over with CS101)
            courses["BIO404"] = new HashSet<string> { "Ivy", "Jack", "David" };     // BIO404 has Ivy, Jack, and David (cross-over with MATH202)
                                                                                    // Set course capacities (varying)
            courseCapacities["CS101"] = 3;  // CS101 capacity of 3 (currently full)
            courseCapacities["MATH202"] = 5; // MATH202 capacity of 5 (can accept more students)
            courseCapacities["ENG303"] = 3;  // ENG303 capacity of 3 (currently full)
            courseCapacities["BIO404"] = 4;  // BIO404 capacity of 4 (can accept more students)
                                             // Waitlist for courses (students waiting to enroll in full courses)
            WaitList.Add(("Helen", "CS101"));   // Helen waiting for CS101
            WaitList.Add(("Jack", "ENG303"));   // Jack waiting for ENG303
            WaitList.Add(("Alice", "BIO404"));  // Alice waiting for BIO404
            WaitList.Add(("Eva", "ENG303"));    // Eva waiting for ENG303
            Console.WriteLine("Startup data initialized.");
        }
        static void Displayallstudentandcourse()
        {

             Console.WriteLine("\n - - - - List of courses and student - - - -");
            foreach (KeyValuePair<string,HashSet<string>> v in courses)
            {
                Console.WriteLine($"{v.Key}: {string.Join(", ", v.Value)}");
            }

        }
        static void Displayallstudentincourse()
        {

            Console.WriteLine("\n - - - - List of courses and student - - - -");
            foreach (KeyValuePair<string, HashSet<string>> v in courses)
            {
                Console.WriteLine($"Course code: {v.Key}");
            }
            Console.WriteLine("\nEnter code course");
            string code = Console.ReadLine();
            if (courses.ContainsKey(code))
            {   
                foreach (string n in courses[code])
                {

                    Console.WriteLine("Student Name: "+n);
                }

            }
            else
            {
                Console.WriteLine("Code Not found");
            }
        }

    }
    }

