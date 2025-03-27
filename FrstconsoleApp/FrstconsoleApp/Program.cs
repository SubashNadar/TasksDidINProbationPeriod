// See https://aka.ms/new-console-template for more information
if (args.Length > 0) { 
Console.WriteLine($"{args[0]} User !\n" +
    "Enter ur Name : ");
string userName = Console.ReadLine();
Console.Write("Hii " + userName+" Welcome To Code World!");
}
else
{
    Console.Write("Bye!");
}