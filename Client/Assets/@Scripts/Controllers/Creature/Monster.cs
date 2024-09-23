using UnityEngine;
using static Define;

public class Monster : Creature
{
    public override bool Init()
    { 
        if (base.Init() == false)
            return false;

        CreatureType = ECreatureType.Monster;
        CreatureState = ECreatureState.Idle;
        Speed = 3.0f;

        StartCoroutine(CoUpdateAI());

        return true;
    }


    #region AI
    protected override void UpdateIdle()
    {
        Debug.Log("Idle");
    }


    protected override void UpdateMove()
    {
        Debug.Log("Move");
    }

    protected override void UpdateSkill()
    {
        Debug.Log("Skill");
    }

    protected override void UpdateDead()
    {
        Debug.Log("Dead");
    }
    #endregion
}
