using System;
using Modul8_1302210086;

class program
{
    static void Main(string[] args)
    {
        BankTransferConfig btc = new BankTransferConfig();
        if (btc.config.lang == "en")
        {
            Console.WriteLine("please insert the amount of money to tansfer: ");
        } else if (btc.lang == "id")
        {
            Console.WriteLine("masukkan jumlah uang yang akan di-transfer: ");
        }

        int amount = int.Parse(Console.ReadLine());
        int tranferFee = amount <= btc.config.transfer.threshold ? btc.config.transfer.low_fee : btc.config.transfer.high_fee;
        int total = amount + tranferFee;

        if (btc.config.lang == "en")
        {
            Console.WriteLine($"transfer fee = {tranferFee}\nTotal amount = {total}");
        } else if (btc.config.lang == "id")
        {
            Console.WriteLine($"biaya transfer = {tranferFee}\nTotal amount = {total}");
        }
    }
}