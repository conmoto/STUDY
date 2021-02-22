using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_Instance; // 유일성을 보장하기 위해 static으로 선언
    static Managers Instance { get { Init(); return s_Instance; } }
    // TODO: 프로퍼티가 생성하는 함수가 무엇인지 한번 써보자..

    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();
    public static InputManager Input { get { return Instance._input; } }
    public static ResourceManager Resource { get { return Instance._resource; } }

    void Start()
    {
        // Instance = this; => 스크립트가 부착된 오브젝트가 많을시 이 부분을 덮어쓰게 된다.

        // Start()에서 초기화 하지 않고Init() 함수를 별도로 만들어야 하는 이유.
        // 1. 이 오브젝트의 Start()가 호출되기 전에
        // 다른 오브젝트에서 GetInstance()를 호출할 수 있음
        // 2. Start()는 Scene에 배치한 오브젝트에 부착되어있어야 호출되므로
        // 오브젝트에 부착해두지 않았을 경우에 대비
        Init();
    }

    void Update()
    {
        _input.OnUpdate();
    }

    static void Init()
    {
        if (s_Instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                // Scene에 @Managers라는 게임 오브젝트 생성 
                // 개체 이니셜라이저를 사용한 초기화 방법. https://docs.microsoft.com/ko-kr/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-objects-by-using-an-object-initializer
                // 매개 변수 없는 생성자가 public이어야 한다.
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            s_Instance = go.GetComponent<Managers>();
            DontDestroyOnLoad(go);
        }
    }

}
