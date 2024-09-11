using System;
using UnityEngine;
using UnityEngine.EventSystems;

// UI에 대한 Event를 Handle 하는 곳
// IPointerClickHandler : 클릭 이벤트 처리로 UI요소에 대한 클릭 이벤트를 감지하고 처리합니다.
//  - 상호작용 추가로 버튼, 이미지 등 UI 요소에 클릭 기능을 쉽게 추가할 수 있다.
//  - 클릭한 위치, 사용된 마우스 버튼 등의 이벤트 데이터 정보를 제공한다.
//  - 마우스, 터치스크린, 컨트롤러 등 다양한 입력 방식을 지원한다.
// IPointerDownHandler: 버튼을 누르는 순간의 동작, 드래그 시작 지점 설정 등에 사용됩니다.
// IPointerUpHandler : 버튼을 떼는 순간의 동작, 드래그 종료 처리 등에 사용됩니다.
// IDragHandler : UI 요소의 위치 변경, 슬라이더 조작, 스크롤 뷰 제어 등에 사용됩니다.

public class UI_EventHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public event Action<PointerEventData> OnClickHandler = null;
    public event Action<PointerEventData> OnPointerDownHandler = null;
    public event Action<PointerEventData> OnPointerUpHandler = null;
    public event Action<PointerEventData> OnDragHandler = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickHandler?.Invoke(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnPointerDownHandler?.Invoke(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnPointerUpHandler?.Invoke(eventData);
    }
    public void OnDrag(PointerEventData eventData)
    {
        OnDragHandler?.Invoke(eventData);
    }
}
