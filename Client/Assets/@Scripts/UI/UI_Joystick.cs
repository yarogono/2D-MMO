using UnityEngine;
using UnityEngine.EventSystems;

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

        joystickCursor.BindEvent(OnBeginDrag, Define.EUIEvent.OnBeginDrag);
        joystickCursor.BindEvent(OnDrag, Define.EUIEvent.Drag);
        joystickCursor.BindEvent(OnEndDrag, Define.EUIEvent.OnEndDrag);


        return base.Init();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag test");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag test");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag test");
    }
}
