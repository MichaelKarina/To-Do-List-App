

namespace To_do_List_App
{
    internal class Program
    {
        static List<Task> tasks = new List<Task>();
        static void Main(string[] args)
        {
            bool exit = false;

            Console.WriteLine("----- Welcome To Your To-Do List App! -----");
            Console.WriteLine("--------------------------------------------");
            while (!exit) 
            {
                Console.WriteLine("\nChoose one option");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Mark Task as done");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Exit");

                Console.WriteLine("\nOption: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ViewTask();
                        break;
                    case "3":
                        MarkTaskAsDone();
                        break;
                    case "4":
                        DeleteTask();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Option!!! Please try again");
                        break;
                }
            }
            Console.WriteLine("\nGoodbye don't forget your tasks!");
            Console.WriteLine("------------------------------------");
        }

        private static void DeleteTask()
        {
            ViewTask();
            Console.WriteLine("Enter your task number to delete:");
            if(int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
            {
                tasks.RemoveAt(tasks.Count - 1);
                Console.WriteLine("Task deleted!");
            }
            else 
            {
                Console.WriteLine("Invalid task number");
            }
        }

        static void MarkTaskAsDone()
        {
            ViewTask();
            Console.WriteLine("Enter your task number to mark as done:");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
            {
                tasks[taskNumber - 1].IsDone = true;
                Console.WriteLine("This Task Is Done");
            }
            else
            {
                Console.WriteLine("Enter a valid task number!");
            }
        }

        static void ViewTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No available tasks at the moment!");
            }
            Console.WriteLine("\nTo-Do List:");
            for (int i = 0; i < tasks.Count; i++)
            {
                string status = tasks[i].IsDone ? "Done" : "Pending";
                Console.WriteLine($"{i + 1}.[{status}] {tasks[i].Description}");
            }
            
        }

        static void AddTask()
        {
            Console.WriteLine("Please Enter Your Task Description: ");
            string description = Console.ReadLine();
            Task newTask = new Task { Description = description, IsDone =  false };
            tasks.Add(newTask);
            Console.WriteLine("Task Added Successfully");
        }
    }
    class Task
    {
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
