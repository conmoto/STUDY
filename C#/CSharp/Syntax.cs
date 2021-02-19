using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Syntax
    {

        //2. Generic
        //2-1. Generic class(클래스 일반화)
        class MyList<T>
        {
            T[] arr = new T[10];

            public T GetItem(int i )
            {
                return arr[i];
            }
        }
        class MyDictionary<T1, T2> // 2개 이상의 인자
        {
            Dictionary<T1, T2> myDictionary = new Dictionary<T1, T2>();
        }
        // Generic에 조건 추가 (C++엔 없는 문법)
        //class MyGeneric<T> where T : struct {} : T는 값 형식이어야 함
        //class MyGeneric2<T> where T : class {} : T는 참조 형식이어야 함
        //class MyGeneric3<T> where T : new() {} : 기본 생성자를 포함해야 함
        //class MyGeneric4<T> where T : MyClass {} : T는 MyClass 혹은 그 자식 클래스여야 함

        //2-2. Generic function(함수 일반화)
        static T MyFunc<T>(T input)
        {
            return input;
        }

        //3. Property
        class Player
        {
            protected int hp;
            public int Hp
            {
                get{ return hp; }
                private set{ hp = value;} //set에 전달되는 값 => value
            }

            //자동 구현 프로퍼티
            public int Mp {get; set;} = 50;
            //자동 구현 프로퍼티의 내부 구현
            // private int mp;
            // public int  GetMp() {return mp;}
            // public void SetMp(int value) {mp = value;}
        }

        static void Run()
        {
            //1. object / 박싱 / 언박싱
            //object 타입은 C# 자료형 최상위 클래스로 힙에 할당한다.
            //object 타입에 저장하는 것을 '박싱'이라 한다.
            object ob1 = 1;
            object ob2 = "Hello World";
            //object 타입을 캐스팅해 스택 변수에 할당하는 것을 '언박싱'이라 한다.
            //박싱, 언박싱은 속도가 느리다.
            int a = (int)ob1;
            string b = (string)ob2;

            //2. Generic
            MyList<int> myIntList = new MyList<int>();
            MyList<short> myShortList = new MyList<short>();

            //3. Property -> 객체지향 은닉성
            Player player = new Player();
            //player.Hp = 100; -> set
            int hp = player.Hp; // get
        }
    }
}
