using System;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //byte(1byte 0~255), short(2바이트 -3만~3만), int(4바이트 -21억~21억), long(8바이트)
            //sbyte(1byte -128~127), ushort(2byte 0~6만), uint(0~43억), ulong(8바이트)

            //byte: 0b1111 1111 = 255
            //sbyte: 0b 1000 0000 = -128 -> 최상위 비트는 음수 : -128, 나머지 비트는 그대로 양수
            //sbyte: 0b 1000 0001 = -128 + 1 = -127
            
            //2의 보수 반대 부호 숫자
            //ex) 52 = 0b 0011 0100 
            //1. 모든 1, 0 바꿔치기
            // 0b 1100 1011
            //2. 1 더하기
            // 0b 1100 1100 = -52

            int hp;
            hp = 100;

            Console.WriteLine("Hello World! {0}", hp);
            Console.WriteLine($"Hello World! {hp}");

            /*진수*/

            //10진수

            //2진수(BIN)
            // 0b00 0b01 0b10 0b11 0b100

            //16진수(HEX)
            // 0~9 a b c d e f
            // 0x00 0x01 0x02 .. 0x0F 0x10

            //2진수 -> 16진수 : 2진수 숫자 4자리 = 16진수 숫자 1자리
            // 0b 1000 1111 = 0x 8 F


            //bool: 1바이트
            //float: 4바이트
            //double: 8바이트

            //char: 2바이트. 하나의 문자 저장
            //string: 8바이트(힙에 할당)

            int level = 30;

            bool isAlive = (hp > 0);
            bool isHighLevel = (level >= 40);

            bool a = isAlive && isHighLevel;
            bool b = isAlive || isHighLevel;
            bool c = !isAlive;

            /***************/
            /* 비트 연산자 */
            /***************/
            // << >> & | ^(xor) ~(not)

            // <<: 좌측으로 밀고 하위 비트는 0으로 채운다
            // 0b 0011 0011 -> 0b 0110 0110

            // >>: 음수 표현이 가능한 자료형이 음수인경우(최상위 비트가 1인 경우)
            // 우측으로 밀고 최상위 비트는 1로 유지된다
            // 0b 1100 0100 -> 0b 1110 0010
            // 양수이거나 양수만 표현 가능한 자료형의 경우
            // 우측으로 밀고 0으로 채운다
            // 0b 1100 0100 -> 0b 0110 0010

            // ^(xor): 다른 숫자: 1 같은 숫자: 0
            // 0b0101 ^ 0b1100 = 0b1001
            // ~(not): 0, 1반전
            // ~0b0011 = 0b1100

            //랜덤 & 입력받기
            Random rand = new Random();
            int choice = rand.Next(0, 3);
            //int input = Convert.ToInt32(Console.ReadLine());
            //string inputString = Console.ReadLine();

            //OOP2 Test
            OOP2.Run();
        }
    }
}