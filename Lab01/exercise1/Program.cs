Console.Write("input a number: ");
int userInput = int.Parse(Console.ReadLine());
Console.WriteLine(userInput.GetType());

if(userInput == 0 )
{
    Console.WriteLine("Your number is 0");
}
else if(userInput > 0)
{
    if(userInput %2 == 0)
    {
        Console.WriteLine("Your number is above 0 and even");
    }
    else
    {
        Console.WriteLine("Your number is aboce 0 and odd");
    }
}
else
{
    if (userInput % 2 == 0)
    {
        Console.WriteLine("Your number is less than 0 and even");
    }
    else
    {
        Console.WriteLine("Your number is less than 0 and odd");
    }
        
}