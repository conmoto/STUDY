using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Interface
    {
        abstract class Monster
        {
            //추상 클래스의 virtual 함수는 구현부도 넘겨줄 수 있다.
            public virtual void Attack(){ System.Console.WriteLine("Attack!"); }
            //추상 클래스의 abstract 함수는 사양만을 넘겨준다.
            public abstract void Shout();
        }

        interface IFlyable
        {
            void Fly(); //인터페이스 함수는 본문을 구현하지 않는다.
        }

        class Orc : Monster
        {
            public override void Attack()
            {
                Console.WriteLine("Orc Attack!");
            }
            public override void Shout() { Console.WriteLine("Crrr!");}
        }

        //C++과 다르게 C#은 클래스 다중상속은 하지 못한다.
        //인터페이스만 다중 상속이 가능하다.
        class FlyingSlime : Monster, IFlyable
        {
            public void Fly()
            {
                Console.WriteLine("Slime Fly!");
            }
            public override void Shout() { Console.WriteLine("Srrr~");}
        }

        //인터페이스 활용: 인터페이스 형으로 매개변수를 받아 함수를 실행한다.
        static void DoFly(IFlyable flyable)
        {
            flyable.Fly();
        }

        static void Run()
        {
            //인터페이스 상속 또한 부모 인터페이스 형으로 인스턴스 생성이 가능하다.
            IFlyable flyingSlime = new FlyingSlime();
            DoFly(flyingSlime);
        }

    }
}
