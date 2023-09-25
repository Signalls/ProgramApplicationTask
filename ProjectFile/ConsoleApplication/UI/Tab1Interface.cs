using Data.Enum;
using Data.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Backend.UI
{
    public class Tab1Interface : ITab1Interface
    {
        private readonly ITab2Interface _tab2Interface;

        public Tab1Interface(ITab2Interface tab2Interface)
        {
            _tab2Interface = tab2Interface;
        }
        private void ShowSubMenu(params string[] options)
        {
            Console.WriteLine("****************************************");
            for(int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            Console.WriteLine("****************************************");
            Console.Write("Please select an option:");
        }

        public async void CreateProgram()
        {
            Console.WriteLine("Creating a program....");
            Console.Write("Program title:");
            string title = Console.ReadLine();
            Console.Write("Description:");
            string description = Console.ReadLine();
            Console.Write("Summary:");
            string summary = Console.ReadLine();
            Console.Write("Skill:");
            string skills = Console.ReadLine();
            Console.Write("Benefit:");
            string benefit = Console.ReadLine();
            Console.Write("Criteria:");
            string criteria = Console.ReadLine();
            Console.WriteLine("****************************************");
            Console.WriteLine("SELECT PROGRAM TYPE:(1/2)");
            ShowSubMenu("Part Time", "Full Time");
            ProgramType programtype = 0;
            bool isValidProgramType = false;

            do
            {
                Console.Write("SELECT PROGRAM TYPE (1 for Part Time, 2 for Full Time): ");
                if(int.TryParse(Console.ReadLine(), out int programTypeInput))
                {
                    programtype = (ProgramType)programTypeInput;
                    isValidProgramType = Enum.IsDefined(typeof(ProgramType), programtype);
                }
                else
                {
                    isValidProgramType = false;
                }

                if(!isValidProgramType)
                {
                    Console.WriteLine("Invalid input. Please select a valid program type.");
                    Console.WriteLine("****************************************");
                }

            } while(!isValidProgramType);

            // At this point, you have a valid ProgramType in the 'programtype' variable

            Console.WriteLine("****************************************");
            Console.WriteLine("SELECT PROGRAM DURATION:(1/2/3)");
            ShowSubMenu("Three months", "Six months", "One year");
            Duration programduration = 0;
            bool isValidProgramDuration = false;
            do
            {
                Console.Write("SELECT DURATION (1 for Three months, 2 for Six months,3 for One year): ");
                if(int.TryParse(Console.ReadLine(), out int programDurationInput))
                {
                    programduration = (Duration)programDurationInput;
                    isValidProgramDuration = Enum.IsDefined(typeof(Duration), programduration);
                }
                else
                {
                    isValidProgramDuration = false;
                }

                if(!isValidProgramDuration)
                {
                    Console.WriteLine("Invalid input. Please select a valid program type.");
                    Console.WriteLine("****************************************");
                }

            } while(!isValidProgramDuration);

            Console.WriteLine("****************************************");
            Console.WriteLine("SELECT PROGRAM QUALIFICATION:(1/2/3/4)");
            ShowSubMenu("HighSchool", "Colledge", "Masters", "Phd");
            MiniQualification programqualification = 0;
            bool isValidQualification = false;
            do
            {
                Console.Write("SELECT DURATION (1 for HighSchool, 2 for Colledge,3 for Masters, 4 for Phd): ");
                if(int.TryParse(Console.ReadLine(), out int programQualification))
                {
                    programqualification = (MiniQualification)programQualification;
                    isValidQualification = Enum.IsDefined(typeof(MiniQualification), programqualification);
                }
                else
                {
                    isValidQualification = false;
                }

                if(!isValidQualification)
                {
                    Console.WriteLine("Invalid input. Please select a valid program type.");
                    Console.WriteLine("****************************************");
                }

            } while(!isValidProgramDuration);
            Console.Write("Max num of appplication:");
            int maxnumberofapplication = int.Parse(Console.ReadLine());
            Console.Write("Location:");
            string location = Console.ReadLine();
            Console.Write("Enter program start-date (yyyy-MM-dd): ");
            string date = Console.ReadLine();
            DateTime startdate;
            DateTime.TryParse(date, out startdate);
            Console.Write("Enter program end-date (yyyy-MM-dd): ");
            string endDate = Console.ReadLine();
            DateTime enDate;
            DateTime.TryParse(endDate, out enDate);
            string baseUrl = "https://localhost:7219/api/ProgramDetails";


            var newProgram = new ProgramDetails
            {
                Title = title,
                Description = description,
                Summary = summary,
                Skills = skills,
                Benefits = benefit,
                ApplicationCriteria = criteria,
                MaxNumberOfApplication = maxnumberofapplication,
                ApplicationClose = enDate,
                ProgramStart = startdate,
                Location = location,
                mininmumQualification = programqualification,
                ProgramDuration = programduration,
                programType = programtype,


            };

            string jsonContent = JsonConvert.SerializeObject(newProgram);

            // Create an instance of HttpClient
            using(HttpClient client = new HttpClient())
            {
                try
                {
                    // Set the base address of the API
                    client.BaseAddress = new Uri(baseUrl);

                    // Set the content type header to JSON
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Create a StringContent object from the JSON content
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    // Send a POST request to the CreateProgram endpoint
                    HttpResponseMessage response = await client.PostAsync("ProgramDetails", content);

                    // Check if the request was successful
                    if(response.IsSuccessStatusCode)
                    {
                        // Read the response content
                        string responseContent = await response.Content.ReadAsStringAsync();
                        // Deserialize the response JSON into an object if needed
                        // var result = JsonConvert.DeserializeObject<ResultType>(responseContent);
                        Console.WriteLine("Program created successfully.");

                        //ShowSubMenu("Edit Program", "Move to next tab", "Exit_Program");
                        //int nextTab = 0;
                        //bool isnexttab = false;

                        //do
                        //{
                        //    Console.Write("SELECT OPTIONS (1 to Edit, 2 to continue, 3 to Exit): ");
                        //    if(int.TryParse(Console.ReadLine(), out int nextTypeInput))
                        //    {

                        //        if(nextTypeInput > 0 && nextTypeInput <= 3)
                        //        {
                        //            nextTab = nextTypeInput;
                        //            isnexttab = false;
                        //        }
                        //        isnexttab = true;
                        //    }
                        //    else
                        //    {
                        //        isnexttab = false;
                        //    }

                        //    if(!isnexttab)
                        //    {
                        //        Console.Write("Invalid input. Please select a valid program type.");
                        //        Console.WriteLine("****************************************");
                        //    }

                        //} while(!isnexttab);

                        //switch(nextTab)
                        //{
                        //    case 1:
                        //        EditProgram1();
                        //        break;
                        //    case 2:
                        //        _tab2Interface.GetProgram2();
                        //        break;
                        //    case 3:
                        //        Console.WriteLine("Exiting the application. Goodbye!");
                        //        Environment.Exit(0);
                        //        break;
                        //    default:
                        //        Console.WriteLine("Invalid option. Please try again.");
                        //        break;

                        //}
                    }
                    else
                    {
                        Console.WriteLine("Error: " + response.StatusCode);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }


        }
        public async void EditProgram1()
        {
            Console.WriteLine("Editing a program...");
            Console.Write("Program Id:");
            string Id = Console.ReadLine();
            Console.Write("Program title:");
            string title = Console.ReadLine();
            Console.Write("Description:");
            string description = Console.ReadLine();
            Console.Write("Summary:");
            string summary = Console.ReadLine();
            Console.Write("Skill:");
            string skills = Console.ReadLine();
            Console.Write("Benefit:");
            string benefit = Console.ReadLine();
            Console.Write("Criteria:");
            string criteria = Console.ReadLine();
            Console.WriteLine("****************************************");
            Console.WriteLine("SELECT PROGRAM TYPE:(1/2)");
            ShowSubMenu("Part Time", "Full Time");
            ProgramType programtype = 0;
            bool isValidProgramType = false;

            do
            {
                Console.Write("SELECT PROGRAM TYPE (1 for Part Time, 2 for Full Time): ");
                if(int.TryParse(Console.ReadLine(), out int programTypeInput))
                {
                    programtype = (ProgramType)programTypeInput;
                    isValidProgramType = Enum.IsDefined(typeof(ProgramType), programtype);
                }
                else
                {
                    isValidProgramType = false;
                }

                if(!isValidProgramType)
                {
                    Console.WriteLine("Invalid input. Please select a valid program type.");
                    Console.WriteLine("****************************************");
                }

            } while(!isValidProgramType);

            // At this point, you have a valid ProgramType in the 'programtype' variable

            Console.WriteLine("****************************************");
            Console.WriteLine("SELECT PROGRAM DURATION:(1/2/3)");
            ShowSubMenu("Three months", "Six months", "One year");
            Duration programduration = 0;
            bool isValidProgramDuration = false;
            do
            {
                Console.Write("SELECT DURATION (1 for Three months, 2 for Six months,3 for One year): ");
                if(int.TryParse(Console.ReadLine(), out int programDurationInput))
                {
                    programduration = (Duration)programDurationInput;
                    isValidProgramType = Enum.IsDefined(typeof(Duration), programduration);
                }
                else
                {
                    isValidProgramDuration = false;
                }

                if(!isValidProgramType)
                {
                    Console.WriteLine("Invalid input. Please select a valid program type.");
                    Console.WriteLine("****************************************");
                }

            } while(!isValidProgramDuration);

            Console.WriteLine("****************************************");
            Console.WriteLine("SELECT PROGRAM QUALIFICATION:(1/2/3/4)");
            ShowSubMenu("HighSchool", "Colledge", "Masters", "Phd");
            MiniQualification programqualification = 0;
            bool isValidQualification = false;
            do
            {
                Console.Write("SELECT DURATION (1 for HighSchool, 2 for Colledge,3 for Masters, 4 for Phd): ");
                if(int.TryParse(Console.ReadLine(), out int programQualification))
                {
                    programqualification = (MiniQualification)programQualification;
                    isValidQualification = Enum.IsDefined(typeof(MiniQualification), programqualification);
                }
                else
                {
                    isValidQualification = false;
                }

                if(!isValidQualification)
                {
                    Console.WriteLine("Invalid input. Please select a valid program type.");
                    Console.WriteLine("****************************************");
                }

            } while(!isValidProgramDuration);
            Console.Write("Max num of appplication:");
            int maxnumberofapplication = int.Parse(Console.ReadLine());
            Console.Write("Location:");
            string location = Console.ReadLine();
            Console.Write("Enter program start-date (yyyy-MM-dd): ");
            string date = Console.ReadLine();
            DateTime startdate;
            DateTime.TryParse(date, out startdate);
            Console.Write("Enter program end-date (yyyy-MM-dd): ");
            string endDate = Console.ReadLine();
            DateTime enDate;
            DateTime.TryParse(endDate, out enDate);

            string baseUrl = "https://localhost:7219/api/ProgramDetails";


            var newProgram = new ProgramDetails
            {
                Id = Id,
                Title = title,
                Description = description,
                Summary = summary,
                Skills = skills,
                Benefits = benefit,
                ApplicationCriteria = criteria,
                MaxNumberOfApplication = maxnumberofapplication,
                ApplicationClose = enDate,
                ProgramStart = startdate,
                Location = location,
                mininmumQualification = programqualification,
                ProgramDuration = programduration,
                programType = programtype,

            };

            string jsonContent = JsonConvert.SerializeObject(newProgram);

            // Create an instance of HttpClient
            using(HttpClient client = new HttpClient())
            {
                try
                {
                    // Set the base address of the API
                    client.BaseAddress = new Uri(baseUrl);

                    // Set the content type header to JSON
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Create a StringContent object from the JSON content
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    // Send a POST request to the CreateProgram endpoint
                    HttpResponseMessage response = await client.PutAsync("ProgramDetails", content);

                    // Check if the request was successful
                    if(response.IsSuccessStatusCode)
                    {
                        // Read the response content
                        string responseContent = await response.Content.ReadAsStringAsync();
                        // Deserialize the response JSON into an object if needed
                        // var result = JsonConvert.DeserializeObject<ResultType>(responseContent);
                        Console.WriteLine("Program updated successfully.");
                        //int nextTab = 0;
                        //bool isnexttab = false;

                        //do
                        //{
                        //    Console.Write("SELECT OPTIONS (1 to Edit, 2 to continue, 3 to Exit): ");
                        //    if(int.TryParse(Console.ReadLine(), out int nextTypeInput))
                        //    {

                        //        if(nextTypeInput > 0 && nextTypeInput <= 3)
                        //        {
                        //            nextTab = nextTypeInput;
                        //            isnexttab = false;
                        //        }
                        //        isnexttab = true;
                        //    }
                        //    else
                        //    {
                        //        isnexttab = false;
                        //    }

                        //    if(!isnexttab)
                        //    {
                        //        Console.Write("Invalid input. Please select a valid program type.");
                        //        Console.WriteLine("****************************************");
                        //    }

                        //} while(!isnexttab);

                        //switch(nextTab)
                        //{
                        //    case 1:
                        //        EditProgram1();
                        //        break;
                        //    case 2:
                        //        _tab2Interface.GetProgram2();
                        //        break;
                        //    case 3:
                        //        Console.WriteLine("Exiting the application. Goodbye!");
                        //        Environment.Exit(0);
                        //        break;
                        //    default:
                        //        Console.WriteLine("Invalid option. Please try again.");
                        //        break;

                        //}
                    }
                    else
                    {
                        Console.WriteLine("Error: " + response.StatusCode);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }


        }
        // ... (User input prompts and program creation logic)
        public async void GetProgram1()
        {
            Console.WriteLine("Getting a program...");
            string baseUrl = "https://localhost:7219/api/ProgramDetails/Id";

            // Specify the program ID you want to retrieve
            Console.Write("Enter Program Id:");
            string programId = Console.ReadLine();
            // Create an instance of HttpClient
            using(HttpClient client = new HttpClient())
            {
                try
                {
                    // Set the base address of the API
                    client.BaseAddress = new Uri(baseUrl);

                    // Send a GET request to the GetProgram endpoint
                    HttpResponseMessage response = await client.GetAsync($"?Id={programId}");

                    // Check if the request was successful
                    if(response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        string responseContent = await response.Content.ReadAsStringAsync();

                        // Process the response content (e.g., deserialize JSON)
                        //var program = JsonConvert.DeserializeObject<ProgramDetailsDto>(responseContent);

                        // Print or work with the retrieved program data
                        Console.WriteLine("Program retrieved successfully:");
                        Console.WriteLine(responseContent);
                        //int nextTab = 0;
                        //bool isnexttab = false;

                        //do
                        //{
                        //    Console.Write("SELECT OPTIONS (1 to Edit, 2 to continue, 3 to Exit): ");
                        //    if(int.TryParse(Console.ReadLine(), out int nextTypeInput))
                        //    {

                        //        if(nextTypeInput > 0 && nextTypeInput <= 3)
                        //        {
                        //            nextTab = nextTypeInput;
                        //            isnexttab = false;
                        //        }
                        //        isnexttab = true;
                        //    }
                        //    else
                        //    {
                        //        isnexttab = false;
                        //    }

                        //    if(!isnexttab)
                        //    {
                        //        Console.Write("Invalid input. Please select a valid program type.");
                        //        Console.WriteLine("****************************************");
                        //    }

                        //} while(!isnexttab);

                        //switch(nextTab)
                        //{
                        //    case 1:
                        //        EditProgram1();
                        //        break;
                        //    case 2:
                        //        _tab2Interface.GetProgram2();
                        //        break;
                        //    case 3:
                        //        Console.WriteLine("Exiting the application. Goodbye!");
                        //        Environment.Exit(0);
                        //        break;
                        //    default:
                        //        Console.WriteLine("Invalid option. Please try again.");
                        //        break;

                        //}



                    }
                    else
                    {
                        Console.WriteLine("Error: " + response.StatusCode);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
