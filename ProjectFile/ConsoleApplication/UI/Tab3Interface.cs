using Data.Dtos;
using Data.Enum;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Backend.UI
{
    public class Tab3Interface : ITab3Interface
    {
        private readonly ITab4Interface _tab4Interface;

        public Tab3Interface(ITab4Interface tab4Interface)
        {
            _tab4Interface = tab4Interface;
        }
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
        public async void EditProgram3()
        {
            Console.WriteLine("Editing a program...");
            Console.Write("Program Id:");
            string Id = Console.ReadLine();
            Console.Write("Stage Name:");
            string stageName = Console.ReadLine();
            Console.Write("Stage Type:");
            StageType stageType = 0;
            bool isStageType = false;

            do
            {
                Console.Write("SELECT PROGRAM TYPE (1 for Yes, 2 for No): ");
                if(int.TryParse(Console.ReadLine(), out int stagetypeInput))
                {
                    stageType = (StageType)stagetypeInput;
                    isStageType = Enum.IsDefined(typeof(ProgramType), stageType);
                }
                else
                {
                    isStageType = false;
                }

                if(!isStageType)
                {
                    Console.WriteLine("Invalid input. Please select a valid program type.");
                    Console.WriteLine("****************************************");
                }

            } while(!isStageType);



            var newWorkFlow = new WorkFlowDto
            {
                Id = Id,
                StageName = stageName,
                StageType = stageType,


            };
            string baseUrl = "https://localhost:7219/api/WorkFlow";
            string jsonContent = JsonConvert.SerializeObject(newWorkFlow);

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
                    HttpResponseMessage response = await client.PutAsync("WorkFlow", content);

                    // Check if the request was successful
                    if(response.IsSuccessStatusCode)
                    {
                        // Read the response content
                        string responseContent = await response.Content.ReadAsStringAsync();
                        // Deserialize the response JSON into an object if needed
                        // var result = JsonConvert.DeserializeObject<ResultType>(responseContent);
                        Console.WriteLine("Program created successfully.");
                        //ShowSubMenu("Edit Program", "Move to next tab", "ExitProgram");
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
                        //        EditProgram3();
                        //        break;
                        //    case 2:
                        //        _tab4Interface.GetProgram4();
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
        public async void GetProgram3()
        {
            Console.WriteLine("Getting a program...");
            string baseUrl = "https://localhost:7219/api/WorkFlow/Id";

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
                        //ShowSubMenu("Edit Program", "Move to next tab", "ExitProgram");
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
                        //        EditProgram3();
                        //        break;
                        //    case 2:
                        //        _tab4Interface.GetProgram4();
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
