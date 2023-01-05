using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace project
{
    class CustInfo
    { public int custId;
      public string CustName;
      public string CustNum;
      }
      class cus{
        public static void Main(string[] args){
            Console.WriteLine("enter number of persons:");
            //string a;
            int b;
            b=Convert.ToInt32(Console.ReadLine());
            //b=Int32.Parse(a);
            List <CustInfo> clist = new List<CustInfo>();
            int vcusId;
            string VcusName;
            string VcusNum;
            for(int i=0;i<b;i++){
                Console.WriteLine($"enter Id of {i} person");//("{0}",i)
                vcusId=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"enter Name of {i} person");
                VcusName = Console.ReadLine();
                Console.WriteLine($"enter contact number of {i} person");
                VcusNum= Console.ReadLine();
                clist.Add(new CustInfo {custId=vcusId , CustName= VcusName , CustNum = VcusNum} );
            }
            filewrite(clist);
            fileread(clist);
        }
        static void filewrite(List <CustInfo> list){
             string str;
              StreamWriter f = File.CreateText("C:\\example\\cus.dat");
                foreach(CustInfo cust in list){
                    /*Console.WriteLine(cust.custId);
                    Console.WriteLine(cust.CustName);
                    Console.WriteLine(cust.CustNum);*/
                    str = cust.custId.ToString()+","+cust.CustName+","+cust.CustNum;
                    Console.WriteLine(str);
                    f.WriteLine(str);
                }
                f.Close();
                }
                 //string s = StreamReader();
                //read from file
                static void fileread(List <CustInfo> mylist){
                StreamReader fil = new StreamReader(@"C:\\example\\text.dat");
                string s=fil.ReadLine();
                string[] arr=s.Split(',');
                int n =Convert.ToInt32(arr[0]);
                mylist.Add(new CustInfo{custId=n , CustName= arr[1] , CustNum = arr[2]});
                foreach(CustInfo cus in mylist){
                    Console.WriteLine(" {0}",cus.custId);
                    Console.Write(" {0}",cus.CustName);
                    Console.Write(" {0}",cus.CustNum);
                }
                }
    }
    }