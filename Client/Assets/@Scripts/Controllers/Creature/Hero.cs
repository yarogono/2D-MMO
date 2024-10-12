using System;
using UnityEngine;
using static Define;
using static UnityEngine.GraphicsBuffer;

public class Hero : Creature
{
    bool _needArrange = true;
    public bool NeedArrange
    {
        get { return _needArrange; }
        set
        {
            _needArrange = value;

            //if (value)
            //    ChangeColliderSize(EColliderSize.Big);
            //else
            //    TryResizeCollider();
        }
    }

    public override ECreatureState CreatureState
    {
        get { return _creatureState; }
        set
        {
            if (_creatureState != value)
            {
                base.CreatureState = value;

                if (value == ECreatureState.Move)
                    RigidBody.mass = CreatureData.Mass;
                else
                    RigidBody.mass = CreatureData.Mass * 0.1f;
            }
        }
    }

    EHeroMoveState _heroMoveState = EHeroMoveState.None;
    public EHeroMoveState HeroMoveState
    {
        get { return _heroMoveState; }
        private set
        {
            _heroMoveState = value;
            switch (value)
            {
                case EHeroMoveState.CollectEnv:
                    NeedArrange = true;
                    break;
                case EHeroMoveState.TargetMonster:
                    NeedArrange = true;
                    break;
                case EHeroMoveState.ForceMove:
                    NeedArrange = true;
                    break;
            }
        }
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        CreatureType = ECreatureType.Hero;
        MoveSpeed = 5.0f;

        Managers.Game.OnJoystickStateChanged -= HandleOnJoystickStateChanged;
        Managers.Game.OnJoystickStateChanged += HandleOnJoystickStateChanged;

        StartCoroutine(CoUpdateAI());

        return true;
    }

    public override void SetInfo(int templateID)
    {
        base.SetInfo(templateID);

        // State
        CreatureState = ECreatureState.Idle;
    }

    public Transform HeroCampDest
    {
        get
        {
            HeroCamp camp = Managers.Object.Camp;
            if (HeroMoveState == EHeroMoveState.ReturnToCamp)
                return camp.Pivot;

            return camp.Destination;
        }
    }

    #region AI
    public float SearchDistance { get; private set; } = 8.0f;
    //public float AttackDistance
    //{
    //    get
    //    {
    //        float targetRadius = (_target.IsValid() ? _target.ColliderRadius : 0);
    //        return ColliderRadius + targetRadius + 2.0f;
    //    }
    //}

    public float StopDistance { get; private set; } = 1.0f;
    BaseObject _target;

    protected override void UpdateIdle()
    {
        // 0. 이동 상태라면 강제 변경
        if (HeroMoveState == EHeroMoveState.ForceMove)
        {
            CreatureState = ECreatureState.Move;
            return;
        }

        // 0. 너무 멀어졌다면 강제로 이동

        // 1. 몬스터
        //Creature creature = FindClosestInRange(SearchDistance, Managers.Object.Monsters) as Creature;
        //if (creature != null)
        //{
        //    _target = creature;
        //    CreatureState = ECreatureState.Move;
        //    HeroMoveState = EHeroMoveState.TargetMonster;
        //    return;
        //}

        // 2. 주변 Env 채굴
        //Env env = FindClosestInRange(SearchDistance, Managers.Object.Envs) as Env;
        //if (env != null)
        //{
        //    _target = env;
        //    CreatureState = ECreatureState.Move;
        //    HeroMoveState = EHeroMoveState.CollectEnv;
        //    return;
        //}

        // 3. Camp 주변으로 모이기
        //if (NeedArrange)
        //{
        //    CreatureState = ECreatureState.Move;
        //    HeroMoveState = EHeroMoveState.ReturnToCamp;
        //    return;
        //}
    }

    protected override void UpdateMove()
    {
        // 0. 누르고 있다면, 강제 이동
        if (HeroMoveState == EHeroMoveState.ForceMove)
        {
            Vector3 dir = HeroCampDest.position - transform.position;
            SetRigidBodyVelocity(dir.normalized * MoveSpeed);
            return;
        }
    }

    protected override void UpdateSkill()
    {

    }

    protected override void UpdateDead()
    {

    }
    #endregion

    private void HandleOnJoystickStateChanged(EJoystickState joystickState)
    {
        switch (joystickState)
        {
            case Define.EJoystickState.PointerDown:
                HeroMoveState = EHeroMoveState.ForceMove;
                break;
            case Define.EJoystickState.Drag:
                HeroMoveState = EHeroMoveState.ForceMove;
                break;
            case Define.EJoystickState.PointerUp:
                HeroMoveState = EHeroMoveState.None;
                break;
            default:
                break;
        }
    }
}
