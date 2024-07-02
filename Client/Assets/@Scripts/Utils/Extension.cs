using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Utils 기능에 확장된 역할을 하는 함수를 모아놓은 클래스
public static class Extension
{
    // GameObject에서 T 제네릭 타입의 Component를 가져오거나 추가할 때 사용하는 함수
    public static T GetOrAddComponent<T>(this GameObject go) where T : UnityEngine.Component
    {
        return Util.GetOrAddComponent<T>(go);
    }

    // Event를 바인딩하는 함수
    // UI에 Event를 바인딩하고 해당 Event 실행 시 실행 될 함수(action)를 바인딩합니다.
    public static void BindEvent(this GameObject go, Action<PointerEventData> action = null, Define.EUIEvent type = Define.EUIEvent.Click)
    {
        UI_Base.BindEvent(go, action, type);
    }

    // GameObject 활성화 및 null 여부 체크
    public static bool IsValid(this GameObject go)
    {
        return go != null && go.activeSelf;
    }

    // GameObject의 childs를 전부 Destory
    public static void DestroyChilds(this GameObject go)
    {
        foreach (Transform child in go.transform)
            Managers.Resource.Destroy(child.gameObject);
    }

    // 인자로 넘어온 list를 임의에 순서로 섞는 함수
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;

        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            (list[k], list[n]) = (list[n], list[k]); //swap
        }
    }
}
