using UnityEngine;

public static class Util
{
    // GameObject에서 제네릭 타입 T의 컴포넌트를 가져온다.
    // 만약 T 타입의 컴포넌트가 없다면, 해당 컴포넌트를 GameObject에 추가한다.
    // 기존에 존재하거나 새로 추가된 T 타입의 컴포넌트를 반환한다.
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
        {
            component = go.AddComponent<T>();
        }

        return component;
    }

    // GameObject의 name에 해당하는 GameObject 검색
    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if(transform == null)
        {
            return null;
        }

        return transform.gameObject;
    }

    // Transform을 사용하여 GameObject의 자식 객체를 검색하고 특정 컴포넌트를 찾는 기능
    // Transform을 사용 => GameObject의 계층 구조에 관련된 모든 작업을 Transform 컴포넌트를 통해 이루어짐
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
        {
            return null;
        }

        if (recursive == false)
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                    {
                        return component;
                    }
                }
            }
        }
        else
        {
            foreach (T component in go.transform.GetComponents<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                {
                    return component;
                }
            }
        }

        return null;
    }
}
