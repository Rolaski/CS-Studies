String[] url = System.IO.File.ReadAllLines("C:\\Users\\Admin\\IdeaProjects\\C# - Studies\\Lab01\\exercise3\\iris.csv");
foreach (string item in url)
{
    String[] line = item.Split(',');
    foreach(string substrings in line)
    {
        Console.Write(substrings+" ");
    }
    Console.WriteLine();
}