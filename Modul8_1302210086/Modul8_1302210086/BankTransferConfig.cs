using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Modul8_1302210086
{
    public class config
    {
        public string lang { get; set; }
        public Transfer transfer { get; set; }
        public list<string> methods { get; set; }
        public Confirmation confirmation { get; set; }

        public config (string lang, Transfer transfer, list<string> methods, Confirmation confirmation, transfer)
        {
            this.lang = lang;
            this.transfer = transfer;
            this.methods = methods;
            this.confirmation = confirmation;
        }
    }

    public class Transfer
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }
        public Transfer(int threshold, int low_fee, int high_fee)
        {
            this.threshold = threshold;
            this.low_fee = low_fee;
            this.high_fee = high_fee;
        }
    }

    public class Confirmation
    {
        public string en { get; set; }
        public string id { get; set; }

        public Confirmation(string en, string id)
        {
            this.en = en;
            this.id = id;
        }
    }

    public class BankTransferConfig
    {
        public config config;
        public const string Filepath = @"bank_transfer_config.json";

        public BankTransferConfig()
        {
            try
            {
                ReadConfig();
            }
            catch (exception)
            {
                setDefault();
                WriteConfig();
            }
        }
        public config ReadConfig()
        {
            string configJsonData = File.ReadAllText(Filepath);
            config = JsonSerializer.Deserialize<config>(configJsonData);
            return config;
        }

        public void setDefault()
        {
            var method = new List<string> { "RTD (Real-time)", "SKN", "RTGS", "BI FAST" };
            var transferConfig = new Transfer(25000000, 65000, 15000);
            var confirmationConfig = new Confirmation("yes", "ya");
            config = new config("en", transferConfig, method, confirmationConfig);
        }
    }

}
