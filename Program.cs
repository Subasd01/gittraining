using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
    class Menu{
        public int itemId{get; set;}
        public String itemName{get; set;}
        public int rate{get; set;}
    }
    class ItemOrder{
        public int itemId{get; set;}
        public int qty{get; set;}
        public double amt{get; set;}
    }
    class Program
    {
        public static void Main(string[] args){
            List<Menu> L = new List<Menu>();
            List<ItemOrder> I = new List<ItemOrder>();
            menuMethod(L);
            order(L,I);
            generateAndPrintBill(I);
        }
        public static void menuMethod(List<Menu> L){
            using(var reader = new StreamReader(@"sample.csv"))
            {
                Menu m = new Menu();
                while (!reader.EndOfStream)
                {
                var line = reader.ReadLine();
                var values = line.Split(',');
                for(int i=0 ; i<values.Length ; i=i+3)
                {
                   L.Add(new Menu {itemId = Convert.ToInt32(values[i+0]), itemName=values[i+1],rate=Convert.ToInt32(values[i+2])});
                }
            }
            }
        }
            public static void order(List<Menu> L, List<ItemOrder> I){
                Menu menu = new Menu();
                int choice;
                do{
                System.Console.WriteLine("\n\nSr. :       Item Name    Price}");
                foreach(var l in L){
                System.Console.WriteLine("{0}   :       {1}      Rs{2}",l.itemId, l.itemName, l.rate);
                }
                System.Console.Write("Please Chhose from above options\n(Press 0 to exit): ");
                choice=Convert.ToInt32(Console.ReadLine());
                try{
                    int flag=0;
                    foreach(Menu l in L)
                    {
                        if(l.itemId==choice)
                        {
                            flag=1;
                            System.Console.Write("Please Enter Quantity : ");
                            int qty = Convert.ToInt32(Console.ReadLine());
                            double res=0;
                            foreach(var i in L)
                            {
                                if(i.itemId == choice){
                                    res = i.rate;
                                }
                            }
                             I.Add(new ItemOrder {itemId = choice, qty=qty, amt =res*qty});
                        }
                    }
                     if(flag==0)
                            throw new NullReferenceException("Please enter correct item Id");
                }
                catch(Exception ex)
                {
                    if(choice!=0)
                    Console.WriteLine(ex.Message );
                }
                }while(choice!=0);
        }
        public static void generateAndPrintBill(List<ItemOrder> I){
            string str;
              StreamWriter f = File.CreateText("ItemOrders.csv");
                foreach(var i in I){
                    str = i.itemId.ToString()+","+i.qty.ToString()+","+i.amt.ToString();
                    f.WriteLine(str);
                }
                f.Close();
        }
    }