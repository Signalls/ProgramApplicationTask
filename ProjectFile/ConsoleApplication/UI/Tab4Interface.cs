using Data.Dtos;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Backend.UI
{
    public class Tab4Interface : ITab4Interface
    {



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

        public async void GetProgram4()
        {
            Console.WriteLine("Getting a program...");
            string baseUrl = "https://localhost:7219/api/ApplicationPrieview/Id";

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
                        //    Console.Write("SELECT OPTIONS (1 to Edit, 3 to Exit): ");
                        //    if(int.TryParse(Console.ReadLine(), out int nextTypeInput))
                        //    {

                        //        if(nextTypeInput > 0 && nextTypeInput <= 2)
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
                        //        EditProgram4();
                        //        break;

                        //    case 2:
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



        public async void EditProgram4()
        {
            Console.WriteLine("Editing a program...");
            Console.Write("Program Id:");
            string Id = Console.ReadLine();
            Console.Write("Title:");
            string title = Console.ReadLine();
            Console.Write("Description:");
            string description = Console.ReadLine();
            Console.Write("Summary:");
            string summary = Console.ReadLine();
            Console.Write("Application Criteria:");
            string Criteria = Console.ReadLine();
            Console.Write("Benefit:");
            string benefit = Console.ReadLine();

            var previewUpdate = new ApplicationPreviewDto
            {
                Id = Id,
                Title = title,
                Description = description,
                ApplicationCriteria = Criteria,
                Benefits = benefit,
                Summary = summary,


            };
            string baseUrl = "https://localhost:7219/api/ApplicationPrieview";

            string jsonContent = JsonConvert.SerializeObject(previewUpdate);

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
                    HttpResponseMessage response = await client.PutAsync("ApplicationPrieview", content);

                    // Check if the request was successful
                    if(response.IsSuccessStatusCode)
                    {
                        // Read the response content
                        string responseContent = await response.Content.ReadAsStringAsync();
                        // Deserialize the response JSON into an object if needed
                        // var result = JsonConvert.DeserializeObject<ResultType>(responseContent);
                        Console.WriteLine("Program created successfully.");
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
