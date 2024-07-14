using UnityEngine;

// Init 함수가 Awake 단계에서 호출되고 Init(초기화) 최초로 호출 되었는지 bool 값을 활용해 관리하는 클래스
public class InitBase : MonoBehaviour
{
    protected bool _init = false;
    void Awake()
    {
        Init();
    }

    public virtual bool Init()
    {
        if (_init)
            return false;

        _init = true;
        return true;
    }

}