using UnityEngine;

public class CameraController : InitBase
{
    private BaseObject _target;
    public BaseObject Target
    {
        get { return _target; }
        set { _target = value; }
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Camera.main.orthographicSize = 15.0f;

        return true;
    }

    private void LateUpdate()
    {
        if (Target == null)
            return;

        float cameraZposition = -20f;
        Vector3 targetPosition = new Vector3(Target.CenterPosition.x, Target.CenterPosition.y, cameraZposition);
        gameObject.transform.position = targetPosition;
    }
}


