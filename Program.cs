// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


List<string> toDoList = new List<string>();
string inputCase;
do
{
    display();
    inputCase = Console.ReadLine();
    if (equalsCaseInSensitive(inputCase, "S"))
    {
        showToDo(toDoList);
    }
    else if (equalsCaseInSensitive(inputCase, "A"))
        addToDo();
    else if (equalsCaseInSensitive(inputCase, "R"))
        removeToDo();
    else if (inputCase != "e" && inputCase != "E")
    {
        Console.WriteLine("Invalid Choice");
        printNewLine();
    }

}
while (!equalsCaseInSensitive(inputCase, "E"));

static void display()
{
    Console.WriteLine("Hello!\nWhat do you want to do?\n[S] ee all TODOs\n[A] dd a TODO\n[R] emove a TODO\n[E] xit\n");
}

static void printNewLine() => Console.WriteLine("\n");

static void showToDo(List<string> taskList)
{
    if (taskList.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet.");
        printNewLine();
        return;
    }
    int num = 0;
    foreach (string task in taskList)
        Console.WriteLine((++num).ToString() + ". " + task);
    printNewLine();
}

static bool equalsCaseInSensitive(string inputCase, string compareCase)
{
    return inputCase.ToUpper() == compareCase.ToUpper();
}

void addToDo()
{
    bool flag = false;
    while (!flag)
    {
        Console.WriteLine("Enter the TODO description:");
        string str = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(str))
            Console.WriteLine("The description cannot be empty.");
        else if (toDoList.Contains(str))
        {
            Console.WriteLine("The description must be unique.");
        }
        else
        {
            flag = true;
            toDoList.Add(str);
            Console.WriteLine("TODO Successfully added:" + str);
            printNewLine();
        }
    }
}

void removeToDo()
{
    bool flag = false;
    while (!flag)
    {
        if (toDoList.Count == 0)
        {
            Console.WriteLine("No TODOs have been added yet.");
            printNewLine();
            return;
        }
        Console.WriteLine("Select the index of the TODO you want to remove:");
        showToDo(toDoList);
        string s = Console.ReadLine();
        int result;
        int.TryParse(s, out result);
        if (s == "")
            Console.WriteLine("Selected index cannot be empty.");
        else if (result < 1 || result > toDoList.Count)
        {
            Console.WriteLine("The given index is not valid.");
        }
        else
        {
            flag = true;
            string toDo = toDoList[result - 1];
            toDoList.RemoveAt(result - 1);
            Console.WriteLine("TODO removed:" + toDo);
        }
    }
}
