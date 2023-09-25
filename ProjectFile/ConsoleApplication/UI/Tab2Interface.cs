using Data.Dtos;
using Data.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Newtonsoft.Json;
using System.Text;

namespace Backend.UI
{
    public class Tab2Interface : ITab2Interface
    {
        private readonly ITab3Interface _tab3Interface;

        public Tab2Interface(ITab3Interface tab3Interface)
        {
            _tab3Interface = tab3Interface;
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
        public async void GetProgram2()
        {
            Console.WriteLine("Getting a program...");
            string baseUrl = "https://localhost:7219/api/ApplicationTemplate/Id";

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

                        ShowSubMenu("Edit Program", "Move to next tab", "ExitProgram");
                        int nextTab = 0;
                        bool isnexttab = false;

                        do
                        {
                            Console.Write("SELECT OPTIONS (1 to Edit, 2 to continue, 3 to Exit): ");
                            if(int.TryParse(Console.ReadLine(), out int nextTypeInput))
                            {

                                if(nextTypeInput > 0 && nextTypeInput <= 3)
                                {
                                    nextTab = nextTypeInput;
                                    isnexttab = false;
                                }
                                isnexttab = true;
                            }
                            else
                            {
                                isnexttab = false;
                            }

                            if(!isnexttab)
                            {
                                Console.Write("Invalid input. Please select a valid program type.");
                                Console.WriteLine("****************************************");
                            }

                        } while(!isnexttab);

                        switch(nextTab)
                        {
                            case 1:
                                EditProgram2();
                                break;
                            case 2:
                                _tab3Interface.GetProgram3();
                                break;
                            case 3:
                                Console.WriteLine("Exiting the application. Goodbye!");
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Invalid option. Please try again.");
                                break;

                        }

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
        public async void EditProgram2()
        {
            Console.WriteLine("Editting a program...");
            Console.Write("Program Id:");
            string Id = Console.ReadLine();
            Console.WriteLine("Please select a picture from the directory:");
            string directoryPath = @"C:\Users\johnn\OneDrive\Pictures"; // Replace with the actual directory path
            string[] pictureFiles = Directory.GetFiles(directoryPath, "*.png"); // Change the file extension as needed

            if(pictureFiles.Length == 0)
            {
                Console.WriteLine("No picture files found in the directory.");
                return;
            }

            Console.WriteLine("Available picture files:");

            for(int i = 0; i < pictureFiles.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Path.GetFileName(pictureFiles[i])}");
            }
            string selectedPicturePath = string.Empty;
            Console.Write("Enter the number of the picture you want to select: ");
            if(int.TryParse(Console.ReadLine(), out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= pictureFiles.Length)
            {
                selectedPicturePath += pictureFiles[selectedIndex - 1];
                Console.WriteLine($"You selected: {Path.GetFileName(selectedPicturePath)}");
                // You can now use `selectedPicturePath` to work with the selected picture.
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }

            string imagepath = selectedPicturePath;
            Console.Write("Is Education Mandatory ?:");
            Mandatory Education = 0;
            bool isValidEducation = false;

            do
            {
                Console.Write("SELECT PROGRAM TYPE (1 for Yes, 2 for No): ");
                if(int.TryParse(Console.ReadLine(), out int EducationInput))
                {
                    Education = (Mandatory)EducationInput;
                    isValidEducation = Enum.IsDefined(typeof(ProgramType), Education);
                }
                else
                {
                    isValidEducation = false;
                }

                if(!isValidEducation)
                {
                    Console.WriteLine("Invalid input. Please select a valid program type.");
                    Console.WriteLine("****************************************");
                }

            } while(!isValidEducation);
            Console.Write("Is Experience Mandatory ?:");
            Mandatory Experience = 0;
            bool isValidExperience = false;

            do
            {
                Console.Write("SELECT PROGRAM TYPE (1 for Yes, 2 for No): ");
                if(int.TryParse(Console.ReadLine(), out int ExperienceInput))
                {
                    Experience = (Mandatory)ExperienceInput;
                    isValidExperience = Enum.IsDefined(typeof(ProgramType), Experience);
                }
                else
                {
                    isValidExperience = false;
                }

                if(!isValidExperience)
                {
                    Console.WriteLine("Invalid input. Please select a valid program type.");
                    Console.WriteLine("****************************************");
                }

            } while(!isValidExperience);
            Console.Write("Is Resume Mandatory ?:");
            Mandatory Resume = 0;
            bool isResume = false;

            do
            {
                Console.Write("SELECT PROGRAM TYPE (1 for Yes, 2 for No): ");
                if(int.TryParse(Console.ReadLine(), out int ResumeInput))
                {
                    Resume = (Mandatory)ResumeInput;
                    isResume = Enum.IsDefined(typeof(ProgramType), Resume);
                }
                else
                {
                    isResume = false;
                }

                if(!isResume)
                {
                    Console.WriteLine("Invalid input. Please select a valid program type.");
                    Console.WriteLine("****************************************");
                }

            } while(!isResume);
            Console.Write("First Name:");
            string FName = Console.ReadLine();
            Console.Write("Last Name:");
            string LName = Console.ReadLine();
            Console.Write("Email:");
            string Email = Console.ReadLine();
            Console.Write("Nationality:");
            string Nationality = Console.ReadLine();
            Console.Write("Phone:");
            string Phone = Console.ReadLine();
            Console.Write("Residence:");
            string Residence = Console.ReadLine();
            Console.Write("Id Number:");
            string IdNumber = Console.ReadLine();
            Console.Write("Enter a date (yyyy-MM-dd): ");
            string userInput = Console.ReadLine();
            DateTime db;
            DateTime.TryParse(userInput, out db);
            Console.Write("Gender:");
            Gender Gender = 0;
            bool isGender = false;

            do
            {
                Console.Write("SELECT PROGRAM TYPE (1 for Male, 2 for Female): ");
                if(int.TryParse(Console.ReadLine(), out int GenderInput))
                {
                    Gender = (Gender)GenderInput;
                    isGender = Enum.IsDefined(typeof(ProgramType), Gender);
                }
                else
                {
                    isGender = false;
                }

                if(!isGender)
                {
                    Console.WriteLine("Invalid input. Please select a valid program type.");
                    Console.WriteLine("****************************************");
                }

            } while(!isGender);

            // Create a StreamContent for the image
            var imageStream = File.OpenRead(imagepath);
            var image = ConvertImageStreamToIFormFile(imageStream, "image");
            var person = new PersonalInfoDto();
            person.Nationality = Nationality;
            person.Phone = Phone;
            person.Residence = Residence;
            person.IdNumber = IdNumber;
            person.LastName = LName;
            person.FirstName = FName;
            person.Gender = Gender;
            person.Email = Email;
            person.DB = db;

            // Base URL of your API
            string baseUrl = "https://localhost:7219/api/ApplicationTemplate";



            // Create an instance of HttpClient
            using(HttpClient client = new HttpClient())
            {
                try
                {
                    // Set the base address of the API
                    client.BaseAddress = new Uri(baseUrl);

                    // Create a ProgramDetailUpdateDto object with image as IFormFile
                    var programUpdateDto = new ApplicationTemplateRequestDto
                    {
                        Id = Id,
                        Education = Education,
                        Experience = Experience,
                        Resume = Resume,

                    };

                    // Send a PUT request to the UpdateProgram endpoint
                    var jsonContent = JsonConvert.SerializeObject(programUpdateDto);

                    // Create a StringContent with the JSON data
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    // Send a PUT request to the UpdateProgram endpoint with the JSON content
                    var response = await client.PutAsync("ApplicationTemplate", content);
                    // Check if the request was successful
                    if(response.IsSuccessStatusCode)
                    {
                        // Read the response content
                        string responseContent = await response.Content.ReadAsStringAsync();
                        // Deserialize the response JSON into an object if needed
                        // var result = JsonConvert.DeserializeObject<ResultType>(responseContent);
                        Console.WriteLine("Program updated successfully.");
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
                        //        EditProgram2();
                        //        break;
                        //    case 2:
                        //        _tab3Interface.GetProgram3();
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
            // Function to convert a Stream to IFormFile
            static IFormFile ConvertImageStreamToIFormFile(Stream imageStream, string fileName)
            {
                MemoryStream memoryStream = new MemoryStream();
                imageStream.CopyTo(memoryStream);

                return new FormFile(memoryStream, 0, memoryStream.Length, null, fileName)
                {
                    Headers = new HeaderDictionary(),
                };
            }

        }
    }
}
