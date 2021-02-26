using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    // Action : 반환형이 없는 델리게이트
    public Action KeyAction;
    // 인자가 Define.MouseEvent, 반환형이 void인 델리게이트
    public Action<Define.MouseEvent> MouseAction;
    bool _pressed = false;

    public void OnUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();


        // 마우스 클릭 Invoke
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
