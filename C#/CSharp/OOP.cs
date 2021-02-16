using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    //객체 (OOP Object Oriented Programming)
    class OOP
    {
        class Knight
        {
            public int hp;
            public int attack;

            public void Move()
            {
                Console.WriteLine("Knight Move");
            }
            public void Attack()
            {
                Console.WriteLine("Knight Attack");
            }
        }


        static void Run()
        {
            Knight knight = new Knight();

            knight.hp = 100;
            knight.attack = 10;
        }
    }
}
