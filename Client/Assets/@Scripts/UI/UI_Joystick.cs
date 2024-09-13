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
    private RectTransform _cursorRectTransform;
    private float _radius;
    private Vector2 _touchPos;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObjects(typeof(GameObjects));

        _background = GetObject((int)GameObjects.JoystickBG);
        _cursor = GetObject((int)GameObjects.JoystickCursor);
        _radius = _background.GetComponent<RectTransform>().sizeDelta.y / 5;

        gameObject.BindEvent(OnPointerDown, Define.EUIEvent.PointerDown);
        gameObject.BindEvent(OnPointerUp, Define.EUIEvent.PointerUp);
        gameObject.BindEvent(OnDrag, Define.EUIEvent.Drag);

        _cursorRectTransform = (RectTransform)_cursor.transform;

        return true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown test");
        _background.transform.position = eventData.position;
        _cursor.transform.position = eventData.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        var inputDir = eventData.position - _cursorRectTransform.anchoredPosition;
        _cursorRectTransform.anchoredPosition = inputDir;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp test");
        _cursorRectTransform.anchoredPosition = ((RectTransform)_background.transform).anchoredPosition;
    }


}
