using UnityEngine;

public class GameScene : BaseScene
{
    public override bool Init()
    {
        if (base.Init() == false)
        {
            return false;
        }

        SceneType = Define.EScene.GameScene;

        GameObject map = Managers.Resource.Instantiate("BaseMap");
        map.transform.position = Vector3.zero;
        map.name = "@BaseMap";

        Hero hero = Managers.Object.Spawn<Hero>(Vector3.zero);
        hero.CreatureState = Define.ECreatureState.Idle;

        GameObject camera = Managers.Resource.Instantiate("Camera");
        camera.transform.position = Vector3.zero;
        camera.name = "@Camera";
        CameraController cameraController = camera.GetComponent<CameraController>();
        cameraController.Target = hero;

        Managers.UI.ShowBaseUI<UI_Joystick>();

        //StartLoadAssets();

        return true;
    }

    void StartLoadAssets()
    {
        Managers.Resource.LoadAllAsync<Object>("PreLoad", (key, count, totalCount) =>
        {
            Debug.Log($"{key} {count}/{totalCount}");

            if (count == totalCount)
            {
                //Managers.Data.Init();
            }
        });
    }

    public override void Clear()
    {
    }
}
