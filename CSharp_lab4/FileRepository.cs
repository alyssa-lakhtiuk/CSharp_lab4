using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSharp_lab4
{
    class FileRepository
    {
        internal static readonly string BaseFolder =Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CSharp4", "Users");

        internal static readonly string BaseFile = Path.Combine(BaseFolder, "usersCSharp.json");
        public FileRepository()
        {
            if (!Directory.Exists(BaseFolder))
            {
                Directory.CreateDirectory(BaseFolder);
            }          
        }

        public void AddUserOrUpdate(Person user)
        {
            var stringObj = JsonSerializer.Serialize(user);

            using (StreamWriter sw = new StreamWriter(Path.Combine(BaseFolder, user.EmailAdress), false))
            {
                sw.WriteAsync(stringObj);
            }
        }

        //public async Task AddUserOrUpdate(Person user)
        //{
        //    var stringObj = JsonSerializer.Serialize(user);

        //    using (StreamWriter sw = new StreamWriter(Path.Combine(BaseFile, user.EmailAdress), false))
        //    {
        //        await sw.WriteAsync(stringObj);
        //    }
        //}

        public async Task<Person> GetAsync(string email)
        {
            string stringObj = null;
            string filePath = Path.Combine(BaseFile, email);

            if (!File.Exists(filePath))
                return null;

            using (StreamReader sw = new StreamReader(filePath))
            {
                stringObj = await sw.ReadToEndAsync();
            }

            return JsonSerializer.Deserialize<Person>(stringObj);
        }
    }
}
