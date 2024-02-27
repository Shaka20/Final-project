using Students_management_system;

StudentManagement sm = new StudentManagement();
Console.WriteLine("Welcome to Student Management System!");
while (true)
{
    Console.WriteLine("Enter command: add name, grade, rollNumber, [all], [find rollNumber], [update rollNumber  grade], [quit].");
    string todo = Console.ReadLine();
    if (todo.StartsWith("add"))
    {
        string[] splitStr = todo.Split(' ');
        string name = splitStr[1];
        double grade = double.Parse(splitStr[2]);
        int rollNumber = int.Parse(splitStr[3]);
        sm.addNewStudent(name, grade, rollNumber);
        Console.WriteLine("Student successfully added");
    }
    else if (todo.StartsWith("all"))
    {
        sm.printAllStudentInfo();
    } 
    else if(todo.StartsWith("find"))
    {
        string[] splitStr = todo.Split(' ');
        int rollNumber = int.Parse(splitStr[1]);
        sm.findStudentByRollNumber(rollNumber);
    }
    else if(todo.StartsWith("update"))
    {
        string[] splitStr = todo.Split(' ');
        int rollNumber = int.Parse(splitStr[1]);
        double grade = double.Parse(splitStr[2]);
      
        sm.updateStudentGrade(rollNumber, grade);
    }
    else if (todo.StartsWith("quit"))
    {
        Console.WriteLine("Program is quitting.");
        break;
    }
    else 
    {
        Console.WriteLine("Command is unknown.");
    }
}
