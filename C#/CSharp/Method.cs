using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Method
    {
        //메소드(함수)
        //한정자 반환형식 함수이름(매개변수목록)
        static void HelloWorld()
        {
            Console.WriteLine("Hello World");
        }
        
        static void AddOne(ref int number)
        {
            number += 1;
        }
        static void Divide(int a, int b, out int result1, out int result2)
        {
            //out 키워드로 받은 매개변수는 이 함수 안에서 값이 할당 되어야만 한다.
            result1 = a / b;
            result2 = a % b;
        }

        //선택적 매개변수 : C++과 다르게 순서상 뒤에있는 매개변수를 지정할 수 있다.
        static double Add(int a, int b, int c = 0, float d = 0.0f, double e = 3.0)
        {
            return a + b + c + d + e;
        }

        static void Run()
        {
            //ref 로 인자를 넘기려면 변수에 값이 할당되어 있어야 한다.
            int a = 0;
            Method.AddOne(ref a);
            Console.WriteLine(a);

            int num1 = 10;
            int num2 = 3;

            int result1;
            int result2;
            Divide(num1, num2, out result1, out result2);

            //선택적 매개변수 : C++과 다르게 순서상 뒤에있는 매개변수를 지정할 수 있다.
            Add(1, 2, d: 2.0f);
        }
    }
}
