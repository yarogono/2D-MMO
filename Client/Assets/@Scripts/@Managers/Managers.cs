using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers s_instance;
    private static Managers Instance { get { Init(); return s_instance; } }

    #region Contents
    #endregion

    #region Core
    private GameManager _game = new GameManager();
    private DataManager _data = new DataManager();
    private ResourceManager _resource = new ResourceManager();
    private SceneManagerEx _scene = new SceneManagerEx();
    private UIManager _ui = new UIManager();
    private WebManager _web = new WebManager();
    private SoundManager _sound = new SoundManager();
    #endregion

    public static GameManager Game { get { return Instance._game; } }
    public static DataManager Data { get { return Instance._data; } }
    public static ResourceManager Resource { get { return Instance._resource;} }
    public static SceneManagerEx Scene { get { return Instance._scene; } }
    public static UIManager UI { get { return Instance._ui; } }
    public static WebManager Web { get { return Instance._web; } }
    public static SoundManager Sound { get { return Instance._sound; } }

    void Start()
    {
        Init();
    }

    private static void Init()
    {
        if (s_instance == null)
        {
            GameObject managers = GameObject.FindGameObjectWithTag("Managers");

            if (managers == null)
            {
                managers = new GameObject() { name = "@Managers" };
                managers.AddComponent<Managers>();
            }

            DontDestroyOnLoad(managers);
            s_instance = managers.GetComponent<Managers>();
        }
    }

    public static void Clear()
    {
        UI.Clear();
        Sound.Clear();
    }

}
