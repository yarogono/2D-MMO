using UnityEngine;
using UnityEngine.EventSystems;
using static Define;

public class BaseScene : InitBase
{
    public EScene SceneType { get; protected set; } = EScene.Unknown;

    public override bool Init()
    {
        if (base.Init() == false)
        {
            return false;
        }

        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        if (obj == null)
        {
            GameObject gameObject = new GameObject { name = "@EventSystem" };
            gameObject.AddComponent<EventSystem>();
            gameObject.AddComponent<StandaloneInputModule>();
        }

        return true;
    }
}
