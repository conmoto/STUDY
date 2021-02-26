using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    // Action : ��ȯ���� ���� ��������Ʈ
    public Action KeyAction;
    // ���ڰ� Define.MouseEvent, ��ȯ���� void�� ��������Ʈ
    public Action<Define.MouseEvent> MouseAction;
    bool _pressed = false;

    public void OnUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();


        // ���콺 Ŭ�� Invoke
        if(MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                _pressed = true;
            }
            else
            {
                if (_pressed)
                {
                    MouseAction.Invoke(Define.MouseEvent.Click);
                }
                _pressed = false;
            }
        }
        
    }
}
