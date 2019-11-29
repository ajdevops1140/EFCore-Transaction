using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Text.Json;
using System.Collections.Generic;

namespace EFCore_Transaction
{
    class Program
    {
        static void OpenApplication(ref List<TransactionJson> _tran)
        {
            try{
                using(Process _process = new Process())
                {
                    //Start Transaction File load process
                    ProcessStartInfo startInfo = new ProcessStartInfo(@"D:\VSCode Projects\FillTransactionList\FillTransactionList\bin\Debug\netcoreapp3.0\FillTransactionList.exe");
                    startInfo.Arguments = @"""D:\\VSCode Projects\\TransactionsList.csv""";

                    startInfo.RedirectStandardOutput = true;            
                    
                    _process.StartInfo = startInfo;
                    _process.Start();
                    
                    var json = _process.StandardOutput.ReadToEnd();
                    //Console.WriteLine(json);                   
                    
                    _tran = JsonSerializer.Deserialize<List<TransactionJson>>(json);

                    Console.WriteLine($"Number of Transactions: {_tran.Count}");
                    
                    /*
                    foreach(TransactionJson t in _tran)
                    {                       
                        Console.WriteLine(t);
                    }  
                    */        
                    
                }
            }
            catch(Exception e)
            {

            }
        }       

        static void LoadDB(ref List<TransactionJson> _trans)
        {
            if(_trans != null)
            {
                using ( var context = new TransactionContext())
                {
                    foreach(TransactionJson t in _trans)
                    {
                        //Transaction converted = Convert.FromTransactionJsonToTransaction(t);
                        Console.WriteLine(t);
                        context.Add(t);
                    }
                    context.SaveChanges();
                }
            }
        }

        static void Main(string[] args)
        {
            List<TransactionJson> _transactions = null;

            if(args.Length > 0)
            {
                switch(args[0])
                {
                    case "Load":
                        OpenApplication(ref _transactions);
                        LoadDB(ref _transactions);
                        Console.WriteLine($"Command recognized: {args[0]}");
                    break;
                    case "Add":

                    break;
                    default:
                        Console.WriteLine($"Command NOT recogized: {args[0]}");
                    break;
                }
            }
            else
            {
                Console.WriteLine("No commands provided.");
                
            }
        }
    }
}
