using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace jurnalmod8_103022300065
{
    internal class BankTransferConfig
    {
        private const string filePath = @"bank_transfer_config.json";
        public string lang { get; set; } = "en";
        public BankTransferConfig bt;
        
        class transfer
        {
           
      
            public int threshold { get; set; } = 25000000;
            public int low_fee { get; set; } = 6500;
            public int high_fee { get; set; } = 15000;
            

        }
        List <string> methods { get; set; } = new List<string>{ "RTO(real - time)”, “SKN”, “RTGS”, “BI FAST"};
        class confirmation
        {
            public string en { get; set; } = "yes";
            public string id { get; set; } = "ya";
        }
        public void ReadConfigFile()
        {
            String configJsonData = File.ReadAllText(filePath);
            bt = JsonSerializer.Deserialize<BankTransferConfig>(configJsonData);
            Console.WriteLine(bt);
        }
        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            String jsonString = JsonSerializer.Serialize(bt, options);
            File.WriteAllText(filePath, jsonString);
        }
        public BankTransferConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                

                WriteNewConfigFile();
            }
        }

        
    }
}
