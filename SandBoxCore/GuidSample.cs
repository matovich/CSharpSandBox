using SandBoxCore.DesignPatterns.BehavioralPatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SandBoxCore
{
    public class GuidSample
    {

        public string Name { get; set; } = "Name is: Guid Sample";
        public string Description { get; set; } = string.Empty;

        public void Run()
        {

           // var tg = new Guid("");    

            Guid superAdminId = Guid.NewGuid();

            var success = Guid.TryParse(superAdminId.ToString(), out var superAdminGuidId);

            Console.WriteLine($"Was seccessful: {success.ToString()}");

            if (success && superAdminGuidId != Guid.Empty)
            {
                Console.WriteLine($"Guid output: {superAdminGuidId.ToString()}");

               // context.Options.Headers.Add("x-super-admin-id", superAdminId.ToString());
            }

            Console.WriteLine("Done");
        }

    }
}
