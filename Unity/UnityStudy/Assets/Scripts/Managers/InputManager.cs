using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    // Action : 반환형이 없는 델리게이트
    public Action KeyAction;

    public void OnUpdate()
    {
        if (Input.anyKey == false)
            return;

        if (KeyAction != null)
            KeyAction.Invoke();
    }
}
