using System;

namespace Assignment2
{
    class Program
    {
        internal int Salesno { get; set; }
        internal int Productno { get; set; }

        internal float Price { get; set; }

        internal DateTime dateofsale { get; set; }
        internal int Qty { get; set; }

        internal float TAmount { get; set; }

        Program(int Salesno,int Productno,float Price,DateTime dateofsale,int Qty)
        {
            this.Salesno = Salesno;
            this.Productno = Productno;
            this.Price = Price;
            this.dateofsale = dateofsale;
            this.Qty = Qty;
        }
        void sales(int Qty,float Price)
        {
            TAmount = Qty * Price;
        }
        void display()
        {
          Console.WriteLine("Saleno:{0} || Productno:{1} || Price:{2} || DateOfSale:{3} || Quantity:{4} || TotalAmount:{5} ", Salesno, Productno,Price,dateofsale,Qty,TAmount);
        }
        static void Main()
        {
            Program p = new Program(101,2002,405.9f,Convert.ToDateTime("2000-09-08"),500);
            p.sales(500, 405.9f);
            p.display();
        }
    }
}
