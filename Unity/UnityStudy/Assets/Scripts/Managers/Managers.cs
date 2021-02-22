using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_Instance; // ���ϼ��� �����ϱ� ���� static���� ����
    static Managers Instance { get { Init(); return s_Instance; } }
    // TODO: ������Ƽ�� �����ϴ� �Լ��� �������� �ѹ� �Ẹ��..

    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();
    public static InputManager Input { get { return Instance._input; } }
    public static ResourceManager Resource { get { return Instance._resource; } }

    void Start()
    {
        // Instance = this; => ��ũ��Ʈ�� ������ ������Ʈ�� ������ �� �κ��� ����� �ȴ�.

        // Start()���� �ʱ�ȭ ���� �ʰ�Init() �Լ��� ������ ������ �ϴ� ����.
        // 1. �� ������Ʈ�� Start()�� ȣ��Ǳ� ����
        // �ٸ� ������Ʈ���� GetInstance()�� ȣ���� �� ����
        // 2. Start()�� Scene�� ��ġ�� ������Ʈ�� �����Ǿ��־�� ȣ��ǹǷ�
        // ������Ʈ�� �����ص��� �ʾ��� ��쿡 ���
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
                // Scene�� @Managers��� ���� ������Ʈ ���� 
                // ��ü �̴ϼȶ������� ����� �ʱ�ȭ ���. https://docs.microsoft.com/ko-kr/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-objects-by-using-an-object-initializer
                // �Ű� ���� ���� �����ڰ� public�̾�� �Ѵ�.
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            s_Instance = go.GetComponent<Managers>();
            DontDestroyOnLoad(go);
        }
    }

}
