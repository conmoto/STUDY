using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    //객체 (OOP Object Oriented Programming)
    class OOP
    {
        //class : Ref(참조), stack에 할당된 객체는 주소값을 가지고 있고 본체는 heap에 할당된다.
        class Knight
        {
            static public int counter = 1; //모든 객체들이 공유하는 단 하나의 변수
            public int id;
            public int hp;
            public int attack;
            
            //static 함수는 static 멤버에만 접근 가능하다.
            static void Test()
            {
                //id++; 접근 불가능!
            }
            //static 함수는 객체 없이 호출 가능 => Knight.CreateKnight()
            public static Knight CreateKnight()
            {
                Knight knight = new Knight();
                knight.hp = 100;
                knight.attack = 10;
                return knight;
            }

            //생성자
            public Knight()
            {
                id = counter;
                counter++;

                hp = 100;
                attack = 10;
            }
            // : this()는 기본 생성자를 호출한다. : this()가 먼저 호출된다.
            public Knight(int hp) : this()
            {
                this.hp = hp;
            }
            // 인자가 있는 생성자를 먼저 호출하는것도 가능하다.
            public Knight(int hp, int attack) : this(hp)
            {
                this.attack = attack;
            }

            //깊은복사
            public Knight Clone()
            {
                Knight knight = new Knight();
                knight.hp = hp;
                knight.attack = attack;
                return knight;
            }

            public void Move()
            {
                Console.WriteLine("Knight Move");
            }
            public void Attack()
            {
                Console.WriteLine("Knight Attack");
            }
        }

        //struct : Copy(복사), stack에 본체가 할당된다.
        struct Mage
        {
            public int hp;
            public int attack;
        }
        
        //class 객체는 참조로 받아오기 때문에 ref 키워드를 붙이지 않아도 원본이 수정된다.
        static void KillKnight(Knight knight)
        {
            knight.hp = 0;
        }
        //struct는 복사로 받아오기 때문에 ref 키워드를 붙이지 않는 한 원본에 영향을 주지 않는다.
        static void KillMage(Mage mage)
        {
            mage.hp = 0;
        }

        static void Run()
        {
            Knight knight1 = new Knight();

            knight1.hp = 100;
            knight1.attack = 10;

            Knight knight2 = knight1.Clone();
            knight2.hp = 0;

            //class 객체는 참조값(주소값)을 담고 있기 때문에 knight3와 knight2는 같은 객체가 된다(같은 heap주소를 가리키는 변수가 된다).
            Knight knight3 = knight2;
            knight3.hp = 100;

            Mage mage;
            mage.hp = 70;
            mage.attack = 15;
            
            //struct 변수는 복사이기 때문에 mage2와 mage는 다른 변수가 된다.
            Mage mage2 = mage;


            //static 함수 호출
            Knight knight = Knight.CreateKnight();
        }
    }

    //객체지향의 3대 속성: 은닉성/상속성/다형성
    //상속성 -> 코드의 재사용성
    class OOP2
    {
        class Player
        {
            static public int counter = 0; //모든 객체들이 공유하는 단 하나의 변수
            public int id;
            public int hp;
            public int attack;
            
            public Player()
            {
                counter++;
                id = counter;
                System.Console.WriteLine("Player 기본 생성자");
            }
            public Player(int hp)
            {
                counter++;
                id = counter;
                this.hp = hp;
                System.Console.WriteLine("Player hp 생성자");
            }

            public virtual void Move()
            {
                Console.WriteLine("Player Move");
            }
            public void Attack()
            {
                Console.WriteLine("Player Attack");
            }
        }

        class Knight : Player
        {
            public static Knight CreateKnight()
            {
                Knight knight = new Knight();
                return knight;
            }

            //부모 생성자 명시적 호출은 base(). 생략시 기본 생성자 호출
            public Knight() : base(100)
            {
                //base.attack = 10;
                attack = 10;
            }

            //override: 부모의 virtual 함수를 대신해 실제 자신의 클래스 함수를 호출
            public override void Move()
            {
                //base.Move();
                Console.WriteLine("Knight Move");
            }
            //new: 부모의 함수를 덮어 씀
            //다형성은 적용되지 않는다. 부모형으로 호출시 자신의 클래스가 아닌 부모 함수 호출
            public new void Attack()
            {
                Console.WriteLine("Knight Attack");
            }
        }

        class Mage : Player
        {
            public int mp = 5;
            public static Mage CreateMage()
            {
                Mage mage = new Mage();
                return mage;
            }

            public Mage() : base(70)
            {
                attack = 15;
            }

            public override void Move()
            {
                Console.WriteLine("Mage Move");
            }
            public new void Attack()
            {
                Console.WriteLine("Mage Attack");
            }
        }

        static void EnterGame(Player player)
        {
            // 1. is 는 형변환 성공 여부를 bool로 반환
            bool isMage = (player is Mage);
            if(isMage)
            {
                Mage mage = (Mage)player;
                mage.mp = 10;
            }
            
            // 2. as 는 형변환 성공시 형변환 결과를, 실패시 null을 반환
            Mage mage1 = (player as Mage);
            if(mage1 != null)
            {
                mage1.mp = 10;
            }
        }
        public static void Run()
        {
            Knight knight = Knight.CreateKnight();
            Console.WriteLine($"attack: {knight.attack}");
            Console.WriteLine($"player count: {Player.counter}");

            Mage mage = Mage.CreateMage();
            Console.WriteLine($"player count: {Player.counter}");

            //다형성
            //자식에서 부모 형변환은 바로 가능.
            Player playerKnight = knight;
            Player playerMage = mage;
            //EnterGame(knight);
            //EnterGame(mage);
            
            //Polymorphism: 같은 데이터형으로 다른 함수를 호출.
            playerKnight.Move();    // override => Knight 클래스 함수 호출
            playerMage.Move();      // override => Mage 클래스 함수 호출
            playerKnight.Attack();  // new => Player 클래스 함수 호출
            playerMage.Attack();    // new => Player 클래스 함수 호출
        }
    }
}
