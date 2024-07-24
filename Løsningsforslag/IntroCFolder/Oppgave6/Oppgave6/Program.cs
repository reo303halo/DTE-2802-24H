namespace Oppgave6;

internal static class Program
{
    private static void Main()
    {
        IList<Student> studentList = new List<Student>() { 
            new Student() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 } ,
            new Student() { StudentID = 2, StudentName = "Steve",  Age = 21, StandardID = 1 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID = 2 } ,
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 2 } ,
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 } 
        };

        IList<Standard> standardList = new List<Standard>() { 
            new Standard() { StandardID = 1, StandardName="Standard 1"},
            new Standard() { StandardID = 2, StandardName="Standard 2"},
            new Standard() { StandardID = 3, StandardName="Standard 3"}
        };
        
        
        // Sample 1
        var studentNames = studentList.Where(s => s.Age > 18)
            .Select(s => s)
            .Where(st => st.StandardID > 0)
            .Select(s => s.StudentName);

        Console.WriteLine("Sample 1");
        foreach(var name in studentNames){			
            Console.WriteLine(name);
        }
        
        
        // Sample 2
        var teenStudentsName = from s in studentList
            where s.Age is > 12 and < 20
            select new { StudentName = s.StudentName };

        Console.WriteLine("\nSample 2");
        teenStudentsName.ToList().ForEach(s => Console.WriteLine(s.StudentName));
        
        
        // Sample 3
        var studentsGroupByStandard = from s in studentList
            group s by s.StandardID into sg
            orderby sg.Key 
            select new { sg.Key, sg };

        Console.WriteLine("\nSample 3");
        foreach (var group in studentsGroupByStandard)
        {
            Console.WriteLine("StandardID {0}:", group.Key);
    
            group.sg.ToList().ForEach(st => Console.WriteLine(st.StudentName ));
        }
        
        
        // Left Outer Join
        var studentsGroup = from stad in standardList
            join s in studentList
                on stad.StandardID equals s.StandardID
                into sg
            select new { 
                StandardName = stad.StandardName, 
                Students = sg 
            };

        Console.WriteLine("\nLeft Outer Join");
        foreach (var group in studentsGroup)
        {
            Console.WriteLine(group.StandardName);
    
            group.Students.ToList().ForEach(st => Console.WriteLine(st.StudentName));
        }
        
        
        // Se https://www.tutorialsteacher.com/linq/sample-linq-queries for komplett løsning.
    }
}
