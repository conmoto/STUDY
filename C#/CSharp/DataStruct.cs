using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Monster
    {
        public int id;
        public Monster(int id){this.id = id;}
    }
    class DataStruct
    {
        static void SelectionSort(int[] scores)
        {
            for(int i = 0; i < scores.Length; i++)
            {
                int minIndex = i;
                for(int j = i; j < scores.Length; j++)
                {
                    if(scores[j] < scores[minIndex])
                    {
                        minIndex = j;
                    }
                }
                
                int temp = scores[minIndex];
                scores[minIndex] = scores[i];
                scores[i] = temp;
            }
        }
        static void Run()
        {
            //배열 => 참조 타입. 크기 고정
            //int[] scores = new int[5];
            //int[] scores = new int[5] {10, 20, 30, 40, 50};
            //int[] scores = new int[] {10, 20, 30, 40, 50};
            int[] scores = {10, 20, 30, 40, 50};

            //배열은 참조타입이므로 같은 데이터를 가리키게 된다.
            //int[] scores2 = scores;
            //scores2[0] = 100; => scores[0] = 100
            
            for(int i =0; i < scores.Length; i++)
            {
                Console.WriteLine(scores[i]);
            }
            foreach (int score in scores)
            {
                Console.WriteLine(score);
            }

            //다차원 배열
            //int[,] arr = new int[2,3];
            //int[,] arr = new int[2,3] { {1,2,3}, {1,2,3}};
            //int[,] arr = new int[,] { {1,2,3}, {1,2,3}};
            int[,] arr = { {1,2,3}, {1,2,3}};
            arr[0,0] = 1;
            for(int y = 0; y < arr.GetLength(0); y++)
            {
                for(int x = 0; x < arr.GetLength(1); x++)
                {
                    //...
                }
            }


            //List => 동적 배열
            List<int> list = new List<int>();
            for(int i = 0; i < 5; i++)
                list.Add(i);
            
            for(int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);
            foreach(int num in list)
                Console.WriteLine(num);

            //List 삽입/삭제 : O(n)
            //삽입 Insert(index, item)
            list.Insert(2, 20);
            //삭제 Remove(item) 중복된다면 첫번째 원소
            bool success = list.Remove(3);
            //삭제 RemoveAt(index)
            list.RemoveAt(4);
            list.Clear();


            //Dictionary : Hashtable => Key->Value - O(1)
            Dictionary<int, Monster> dic = new Dictionary<int, Monster>();

            //원소 추가
            //dic.Add(1, new Monster(1));
            //dic[5] = new Monster(5);
            for(int i = 0; i < 1000; i++)
            {
                dic.Add(i, new Monster(i));
            }
            
            //Monster mon = dic[200]; => 바로 접근하는건 KeyNotFoundException 발생 위험.
            //bool found = Dictionary.TryGetValue(Key, out Value) => 실패시 Value == null
            Monster monster;
            bool found = dic.TryGetValue(200, out monster);
            
            //Dictionary.Remove(Key)
            dic.Remove(500);
            dic.Clear();
        }
    }
}
