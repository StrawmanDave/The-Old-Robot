
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

///Create a RobotCommand class with a public and abstract void Run(Robot robot) method. (The code above should compile afte this step.)
///Make OnCommand and OffCommand classes that inherit from RobotCommand and turn the robot on or off by overridn the run method
///Make a NorthCommand, SouthCommand, WestCommand, and EastCommand that move the robot 1 unit in the Y+ directin, 1 unit in the Y- direction, 1 unit in the X- directino, and 1 unit in the X + direction respecively.
///Also enusre that theses commands only worked if the robot's Ispowerd property is true.
///Make your main mehtod able to collect three commands from the console window. Generate new RobotCommand objects based on the texted eneterd.
///After filling the robot's command set with these new RobotCommand objects, use the robot's Run method to execute them.


///Robotic Interface
///Change your abstract RobotCommand class into an IRobotCommand interface.
///Remove the unnecessary public and abstract keywords from the Run mehtod.
///Change the Robot class to use IrobotCommand instead of RobotCommand
///Make all of your commmands implement this new interface instead of extending the RobotCommand class that no longer exists.
///You will also want to remove the override keywords in these classes.
///Ensure your program still compils and runs
///Awnser the question Do you feel this is an improvement over using an abstract base class? Why or why not?
///This seems way easier to use if you are familair even a little bit when it comes overriding/ using the implemented interface. It is definetly a improvement.



Console.WriteLine("Enter 3 commands out of these 5 On, Off, North, South, West, East");
Robot newRobot = new Robot();

//needs to be a forloop so you can set the index of the array Commands will not work if you try to append the items.
for(int i = 0; i<newRobot.Commands.Length; i++)
{
    string? InputCommand = Console.ReadLine();  
    switch(InputCommand)
    {
        case "On":
        newRobot.Commands[i] =new OnCommand();
        break;
        case "Off":
        newRobot.Commands[i] = new OffCommand();
        break;
        case "North":
        newRobot.Commands[i] = new NorthCommand();
        break;
        case "South":
        newRobot.Commands[i] = new SouthCommand();
        break;
        case "West":
        newRobot.Commands[i] = new WestCommand();
        break;
        case "East":
        newRobot.Commands[i] = new EastCommand();        
        break;
    }
}
newRobot.Run();

public class Robot
{
    public int X {get; set;}
    public int Y {get; set;}
    public bool IsPowered {get; set;}
    public IRobotCommand?[] Commands {get;} = new IRobotCommand?[3];
    
    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public interface IRobotCommand
{
    public void Run(Robot robot);
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : IRobotCommand
{
    public  void Run(Robot robot)
    {
        if(robot.IsPowered == true)
        {
            robot.Y = robot.Y + 1;
        }else
        {
            Console.WriteLine("Need power");
        }
    }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if(robot.IsPowered == true)
        {
            robot.Y = robot.Y -1;
        }else
        {
            Console.WriteLine("Need power");
        }
    }
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if(robot.IsPowered == true)
        {
            robot.X = robot.X -1;
        }else
        {
            Console.WriteLine("Need power");
        }
    }
}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if(robot.IsPowered == true)
        {
            robot.X = robot.X +1 ;
        }else
        {
            Console.WriteLine("Need power");
        }
    }
}