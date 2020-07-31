using System;

namespace myProj
{
    class Program
    {
        public static string[] all_words = System.IO.File.ReadAllLines(@"name.txt");
        public static string[] lines = all_words;
        public static int index = 0;

        public static int limit = 1;
        public static int per_page = 1;
        // int viewed = 0;
        public static int lower_limit = 0;

        static void Main(string[] args)
        {
            
        // Type your username and press enter
            Console.WriteLine("Select an option");
            Console.WriteLine("a to view all");
            Console.WriteLine("x to exit");

        Console.WriteLine("Enter an option:");
        string choice = Console.ReadLine();

       
        switch (choice) 
        {
            case "a":
              read();
              break;

            case "x":
             System.Environment.Exit(1);
                
              break;

            default:
                Console.WriteLine("please check the request input");                
            break;

            
        }
        
        Console.WriteLine("Press any key to exit.");
        System.Console.ReadKey();

        }

      static void read(){

            Read_file();
            while (true) 
            {
                
            Console.WriteLine("Select an option");
            Console.WriteLine("s to sort");
            Console.WriteLine("n to view next");
            Console.WriteLine("p to view previous");
            Console.WriteLine("e to edit");
            Console.WriteLine("d to Date difference");
            Console.WriteLine("r to Reset");
            Console.WriteLine("x to exit");

        Console.WriteLine("Enter an option:");
        string choice = Console.ReadLine();

       
        switch (choice) 
        {
            case "s":
              Read_file(true);
              break;

            case "n":
              Read_file(true, true);
              break;

            case "p":
              Read_file(true, false, true);
              break;

            case "x":
             System.Environment.Exit(1);
                
              break;

            case "e":
            write();
            
            break;

            case "r":
        limit = 1;
        per_page = 1;
        // int viewed = 0;
      lower_limit = 0;
            Read_file(true);
            
            break;
              
            case "d":
            difference();
              
              break;

              default:
              Console.WriteLine("please check the request input");                
                break;
            
        }
            }

        }
       
    static String Read_file(Boolean sortthis = false, Boolean next = false, Boolean previous = false){
        String words= "";

        
        if(sortthis == true){
        Array.Sort(lines);

        }
        int total = lines.Length;


        if (limit > total) 
        {
            limit = 0;
        }

        if(next == true){
            lower_limit = lower_limit + 1;
           
            limit = limit + 1;
            per_page ++;
        }
        if(previous == true){
            lower_limit = lower_limit - 1;
            limit = limit - 1;
            per_page = per_page -1;
        }
        // double result = Math.Ceiling(10/15);
              // Console.WriteLine(result);

            for (int i = lower_limit; i < limit; i++) 
            {
                index = i;
                string[] wordz = lines[i].Split(',');
                words += "name : " + wordz[0] + " ";
                words += " " + wordz[1] + " ";
                words += " " + wordz[2] + " ";
                words += "Date Of Admission : " + wordz[3] + " " ;
                words += "Gender : " + wordz[4] + " " ;
                words += System.Environment.NewLine;
                // lines
              Console.WriteLine(lines[i]);
            }

              // Console.WriteLine(per_page);
            return words;
    }
    static void write(){
            Console.WriteLine("Enter the following info");
            Console.WriteLine("Family Name");
            string fam_name = Console.ReadLine();
            Console.WriteLine("First Name");
            string f_name = Console.ReadLine();
            Console.WriteLine("Second name");
            string s_name = Console.ReadLine();
            Console.WriteLine("Date of enrolment (in the formyyyy/mm/dd)");
            string enrolment = Console.ReadLine();
            Console.WriteLine("Gender (one character, M or F)");
            string gender = Console.ReadLine();

            string[] wordz = lines[index].Split(',');
            wordz[1] = fam_name;
            wordz[1] = f_name;
            wordz[1] = s_name;
            wordz[1] = enrolment;
            wordz[1] = gender;

            Console.WriteLine("Done ");
            Console.WriteLine("Enter file name : ");
            string fileName = Console.ReadLine();

            System.IO.File.WriteAllLines(@fileName+".txt", lines);

    }
     static void  difference(){

       string[] wordz = lines[index].Split(',');
       DateTime myDate =  DateTime.Parse(wordz[3]);
       DateTime tooday =  DateTime.Now;

        TimeSpan span = tooday.Subtract (myDate);
        Console.WriteLine( span.Days );
        Console.WriteLine( " Days" );
        }

    }
}
