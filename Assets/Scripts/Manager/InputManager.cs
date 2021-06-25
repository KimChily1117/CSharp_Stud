using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputManager 
{
    public Action KeyAction = null;
    public Action<Define.MouseInput> MouseAction = null;

    bool _pressed = false;

    public void OnUpdate()
    {
        if (Input.anyKey && KeyAction != null)
        {
            KeyAction.Invoke();
        }
    


    }


    
}

                     