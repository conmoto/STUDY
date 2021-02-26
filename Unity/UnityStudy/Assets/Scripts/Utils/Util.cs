
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util 
{
    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform == null)
            return null;
        return transform.gameObject;
    }

    // GameObejct go�� �ڽĿ�����Ʈ���� name���� ã��
    // �� �ڽĿ�����Ʈ�� T ������Ʈ�� ��ȯ�ϴ� �Լ�
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
            return null;

        if(recursive == false)
        {
            for(int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);

                // �̸��� �������� �ʾҴٸ� T ������Ʈ�� �߰��ϸ� ��ȯ
                // �̸��� �����ߴٸ� �̸��� name�� ������Ʈ�� T ������Ʈ ��ȯ
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }
        else
        {
            foreach(T component in go.GetComponentsInChildren<T>())
            {
                // �̸��� �������� �ʾҴٸ� T ������Ʈ�� �߰��ϸ� ��ȯ
                // �̸��� �����ߴٸ� �̸��� name�� ������Ʈ�� T ������Ʈ ��ȯ
                // ex) T: Button, name : PointButton -> Button ������Ʈ�� �̸��� PointButton�� ������Ʈ ��ȯ
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }

        return null;
    }
}
