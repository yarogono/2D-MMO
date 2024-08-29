using UnityEngine;

public class UI_Joystick : UI_Base
{
    enum GameObjects
    {
        JoystickBG,
        JoystickCursor,
    }

    private GameObject _background;
    private GameObject _cursor;
    private float _radius;
    private Vector2 _touchPos;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObjects(typeof(GameObjects));

        GameObject joystickBG = GetObject((int)GameObjects.JoystickBG);
        GameObject joystickCursor = GetObject((int)GameObjects.JoystickCursor);

        joystickBG.BindEvent((evt) =>
        {
            Debug.Log("Test");
        }, Define.EUIEvent.OnBeginDrag);


        return base.Init();
    }
}
