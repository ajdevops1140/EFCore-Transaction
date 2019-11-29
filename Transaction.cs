
using System;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Transaction
{
    public class TransactionContext : DbContext
    {
        public DbSet<Transaction> transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=Transactions.db");    
    }

    public class Transaction
    {
        public int id { get; set; }
        public string? _Date { get; set; }
        public string? _Description { get; set; }
        public string? _Debit { get; set; }   //decimal
        public string? _Credit { get; set; }  //decimal
        public string? _Category { get; set; }    

        public override string ToString()
        {
            return $"ID: {id}, Date: {_Date}, Description: {_Description}, Debit: {_Debit}, Credit: {_Credit}, Category: {_Category}";
        }
    }

    public class TransactionJson
    {
        public int id { get; set; }
        public string? _Date { get; set; }
        public string? _Description { get; set; }
        public string? _Debit { get; set; }  
        public string? _Credit { get; set; }  
        public string? _Category { get; set; }    

        public override string ToString()
        {
            return $"{id}, {_Date}, {_Description}, {_Debit}, {_Credit}, {_Category}";
        }
    }

/*
    public class Convert
    {
        public static Transaction FromTransactionJsonToTransaction(TransactionJson tj)
        {
            Transaction nTr = new Transaction();
            //Assign Id
            //nTr.id = tj.id;
            
            //Convert Date
            DateTime date1;
            if(DateTime.TryParse(tj._Date, out date1))
            {
                nTr._Date = date1;
            }
            else
            {
                nTr._Date = new DateTime(9999,9,9);
            }

            //Description
            nTr._Description = tj._Description;

            //Debit
            decimal amount1;
            if(Decimal.TryParse(tj._Debit, NumberStyles.Currency , new CultureInfo("en-US") , out amount1))
            {
                nTr._Debit = amount1;
            }
            else
            {
                nTr._Debit = 0;
            }

            //Credit
            decimal amount2;
            if(Decimal.TryParse(tj._Credit, NumberStyles.Currency, new CultureInfo("en-US"), out amount2))
            {
                nTr._Credit = amount2;
            }
            else
            {
                nTr._Credit = 0;
            }

            //Category
            tj._Category = nTr._Category;

            return nTr;
        }
    }*/
}