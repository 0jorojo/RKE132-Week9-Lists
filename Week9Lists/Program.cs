//list size isn't limited like array[size] but list also has entry [indexes]
//save info into file, if it exists at location
// 

string folderPath = @"D:\OneDrive - Tallinna Tehnikakõrgkool\Programmeerimine\data";
string fileName = "shoppingList.txt";
string filePath = Path.Combine(folderPath, fileName);
List<string> shoppingList = new List<string>();

if (File.Exists(filePath))      //File.Exists(path) checks if file already exists at location, returns true/false
{
    shoppingList = GetUserItems();
    File.WriteAllLines(filePath, shoppingList);     //(creates file and) saves data into file at location
}
else
{
    File.Create(filePath).Close();      //after file creation, has to be closed to allow modification
    Console.WriteLine($"File {fileName} has been created");
    shoppingList = GetUserItems();
    File.WriteAllLines(filePath, shoppingList);
}    

static List<string> GetUserItems()
{
    List<string> userList = new List<string>();     //create space in cache

    while (true)
    {
        Console.WriteLine("Add item (add) / Exit (exit):");
        string userChoice = Console.ReadLine();

        if (userChoice == "add")
        {
            Console.WriteLine("Enter new item:");
            string userItem = Console.ReadLine();
            userList.Add(userItem);             //adds to list
        }
        else
        {
            Console.WriteLine("Bye!");
            break;
        }
    }
    return userList;
}

static void showListItems(List<string> someList)    //void doesn't return value
{
    Console.Clear();

    int listLength = someList.Count;        //x.Length doesn't work with lists
    Console.WriteLine($"You've added {listLength} items to your list.");
    int i = 1;

    foreach (string item in someList)
    {
        Console.WriteLine($"{i}. {item}");
        i++;            //this with int i = 1 adds correct numbering to the list
    }
}