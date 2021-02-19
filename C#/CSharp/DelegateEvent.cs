using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class DelegateEvent
    {
        //delegate : 함수 자체를 인자로 넘겨줄 수 있게 하는 형식
        // 형식 이름 : Onclicked
        // 반환 : int 입력 : void
        delegate int OnClicked();

        //delegate 형식으로 함수 자체를 인자로 넘겨줄 수 있다. -> 함수를 변수로 만든다고 생각하면 편하다.
        static void ButtonPressed(OnClicked clickedFunction) 
        {
            clickedFunction();
        }
        
        static int Func1()
        {
            Console.WriteLine("Func1");
            return 0;
        }
        static int Func2()
        {
            Console.WriteLine("Func2");
            return 0;
        }

        static void Run()
        {
            //1. delegate 형식에 맞는 함수를 직접 넘겨줄 수 있다.
            ButtonPressed(Func1);

            //2. 함수들을 delegate에 등록해 delegate를 넘길 수 있다.
            OnClicked clicked = new OnClicked(Func1);
            clicked += Func2;
            ButtonPressed(clicked);

            //3. delegate 객체를 이용해 직접 호출할 수도 있다 -> delegate의 단점 : 외부 호출
            // delegate를 외부에서 호출하지 못하게 랩핑한 것이 event
            clicked(); // delegate가 public이라면 외부 class에서도 호출 가능.
        }


        //Event
        //Observer Pattern : 이벤트가 발생하면 구독자들에게 메세지를 뿌림.
        class InputManager
        {
            public delegate void DelegateInputKey();
            // Delegate를 event로 랩핑
            // delegate와 차이 : 외부에서 직접 호출하지 못하게 한다.
            public event DelegateInputKey EventInputKey; 

            public DelegateInputKey delegateInputKey; // Delegate 외부 호출 Test

            public void Update()
            {
                if(Console.KeyAvailable == false)
                    return;

                ConsoleKeyInfo info = Console.ReadKey();
                if(info.Key == ConsoleKey.A)
                {
                    //여기에 직접 A키가 눌렸을때 로직을 실행하는 부분을 구현하면
                    //InputManager에 의존성이 높아지기 때문에 좋은 코드가 아니다.
                    
                    //Event 구독자들에게 알려준다.
                    EventInputKey();
                }
            }
        }
        
        class EventTest
        {
            static void OnInputTest()
            {
                Console.WriteLine("Input Received");
            }

            static void Run()
            {
                InputManager inputManager = new InputManager();
                inputManager.EventInputKey += OnInputTest; // 구독 신청

                //delegate와 달리 외부에서 직접 호출할 수 없다.
                //inputManager.delegateInputKey(); (delgate가 public일시 실행 가능)
                //inputManager.EventInputKey(); (에러 : event가 public이여도 외부 클래스에서 직접 호출하지 못함)

                while(true)
                {
                    inputManager.Update();
                }
            }
        }

    }
}
