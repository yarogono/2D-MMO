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

        _background = GetObject((int)GameObjects.JoystickBG);
        _cursor = GetObject((int)GameObjects.JoystickCursor);

        gameObject.BindEvent(OnPointerDown, Define.EUIEvent.PointerDown);
        gameObject.BindEvent(OnPointerUp, Define.EUIEvent.PointerUp);
        gameObject.BindEvent(OnDrag, Define.EUIEvent.Drag);


        return true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown test");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp test");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag test");
    }

}
