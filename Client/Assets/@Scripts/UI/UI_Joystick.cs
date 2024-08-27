using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Joystick : UI_Base
{
    enum GameObjects
    {
        JoystickBG,
        JoystickCursorm,
    }

    private GameObject _background;
    private GameObject _cursor;
    private float _radius;
    private Vector2 _touchPos;
}
