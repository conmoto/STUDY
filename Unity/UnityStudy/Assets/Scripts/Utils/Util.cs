
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

    // GameObejct go의 자식오브젝트들을 name으로 찾고
    // 그 자식오브젝트의 T 컴포넌트를 반환하는 함수
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
            return null;

        if(recursive == false)
        {
            for(int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);

                // 이름을 지정하지 않았다면 T 컴포넌트를 발견하면 반환
                // 이름을 지정했다면 이름이 name인 오브젝트의 T 컴포넌트 반환
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
                // 이름을 지정하지 않았다면 T 컴포넌트를 발견하면 반환
                // 이름을 지정했다면 이름이 name인 오브젝트의 T 컴포넌트 반환
                // ex) T: Button, name : PointButton -> Button 오브젝트중 이름이 PointButton인 오브젝트 반환
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }

        return null;
    }
}
