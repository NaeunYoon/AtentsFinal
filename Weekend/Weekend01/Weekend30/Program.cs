using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Weekend30
{/*
    집에있는 전자제품 3개 클래스 만들고 상속
    전자제품 대전게임, 전자제품 재고 관리 프로그램
  */
    internal class Program
    {

        class ElectronicProduct
        {
            protected string name;
            protected int storage;
            protected int price;


            public ElectronicProduct(string _name, int _storage, int _price)
            {
                name= _name;
                storage= _storage;  
                price= _price;

            }

            public string NAME
            {
                get { return name; }
                set { name = value; }
            }

            public int STORAGE
            {
                get { return storage; }
                set { storage = value; }
            }
            public int PRICE
            {
                get { return price; }
                set { price = value; }
            }

            public void Info()
            {
                Console.WriteLine($"{name}의 가격은 {price}이고, 재고는 {storage}개 있다");
            }


        }

         class Airconditioner : ElectronicProduct
        {
            public Airconditioner(string _name, int _storage, int price) : base(_name, _storage, price)
            {

            }
        }

        class Television : ElectronicProduct
        {
            public Television(string _name, int _storage, int price) : base(_name, _storage,price)
            {

            }
        }

        class Computer : ElectronicProduct
        {
            public Computer(string _name, int _storage, int price) : base(_name, _storage,price)
            {

            }
        }


        static void Main(string[] args)
        {
            Airconditioner airconditioner = new Airconditioner("에어컨", 40,35000);
            Television television = new Television("TV", 30,25000);
            Computer computer = new Computer("컴퓨터", 20,15000);

            Console.WriteLine() ; 
        }
    }
}
