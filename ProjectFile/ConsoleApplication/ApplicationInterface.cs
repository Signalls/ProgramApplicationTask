using Backend.UI;

namespace Backend
{
    public class ApplicationInterface
    {
        private readonly ITab1Interface _tab1Interface;
        private readonly ITab4Interface _tab4Interface;
        private readonly ITab3Interface _tab3Interface;
        private readonly ITab2Interface _tab2Interface;

        public ApplicationInterface(ITab1Interface tab1Interface, ITab4Interface tab4Interface, ITab3Interface tab3Interface, ITab2Interface tab2Interface)
        {
            _tab1Interface = tab1Interface;
            _tab4Interface = tab4Interface;
            _tab3Interface = tab3Interface;
            _tab2Interface = tab2Interface;
        }

        public void StartProgram()
        {
            while(true)
            {
                Console.Clear(); // Clear the console screen

                // Display the main menu
                Console.WriteLine("****************************************");
                Console.WriteLine("*        Program Management System      *");
                Console.WriteLine("****************************************");
                Console.WriteLine("1. Tab 1_Program Details");
                Console.WriteLine("2. Tab 2_Application Template");
                Console.WriteLine("3. Tab 3_Application WorkFlow");
                Console.WriteLine("4. Tab 4_Application Preview");
                Console.WriteLine("5. Exit_Program");

                Console.WriteLine("****************************************");

                Console.Write("Please select an option (1/2/3/4/5): ");
                string userInput = Console.ReadLine();

                switch(userInput)
                {
                    case "1":
                        // Handle program creation submenu
                        ShowSubMenu("Create Program", "Get Program", "Edit Program");
                        string programInput = Console.ReadLine();
                        switch(programInput)
                        {
                            case "1":
                                _tab1Interface.CreateProgram();
                                break;
                            case "2":
                                _tab1Interface.GetProgram1();
                                break;
                            case "3":
                                _tab1Interface.EditProgram1();
                                break;
                        }
                        break;
                    case "2":
                        // Handle program update submenu
                        ShowSubMenu("Update Program", "Get Program");
                        string programUpdate = Console.ReadLine();
                        switch(programUpdate)
                        {
                            case "1":
                                _tab2Interface.EditProgram2();
                                break;
                            case "2":
                                _tab2Interface.GetProgram2();
                                break;
                        }
                        break;
                    case "3":
                        // Handle getting a program submenu
                        ShowSubMenu("Edit Program", "Get Program");
                        string programUpdate2 = Console.ReadLine();
                        switch(programUpdate2)
                        {
                            case "1":
                                _tab3Interface.EditProgram3();
                                break;
                            case "2":
                                _tab3Interface.GetProgram3();
                                break;
                        }
                        break;
                    case "4":
                        // Handle getting a program submenu
                        ShowSubMenu("Edit Program", "Get Program");
                        string programUpdate3 = Console.ReadLine();
                        switch(programUpdate3)
                        {
                            case "1":
                                _tab4Interface.EditProgram4();
                                break;
                            case "2":
                                _tab4Interface.GetProgram4();
                                break;
                        }
                        break;
                    case "5":
                        // Exit the application
                        Console.WriteLine("Exiting the application. Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        // Helper function to display a submenu
        private void ShowSubMenu(params string[] options)
        {
            Console.WriteLine("****************************************");
            for(int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            Console.WriteLine("****************************************");
            Console.Write("Please select an option: ");
        }



        // ... (User input prompts and program creation logic)







    }



}
