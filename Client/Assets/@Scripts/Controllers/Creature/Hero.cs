using System;
using UnityEngine;
using static Define;

public class Hero : Creature
{
    Vector2 _moveDir = Vector2.zero;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        CreatureType = ECreatureType.Hero;
        CreatureState = ECreatureState.Idle;
        Speed = 5.0f;

        Managers.Game.OnMoveDirChanged -= HandleOnMoveDirChanged;
        Managers.Game.OnMoveDirChanged += HandleOnMoveDirChanged;

        Managers.Game.OnJoystickStateChanged -= HandleOnJoystickStateChanged;
        Managers.Game.OnJoystickStateChanged += HandleOnJoystickStateChanged;

        return true;
    }

    private void Update()
    {
        
        switch(CreatureState)
        {
            case ECreatureState.Idle:
                break;
            case ECreatureState.Move:
                HeroMove();
                break;
        }
    }

    private void HeroMove()
    {
        transform.Translate(_moveDir * Time.deltaTime * Speed);
        if (_moveDir.x > 0)
            LookLeft = false;
        else
            LookLeft = true;
    }

    private void HandleOnMoveDirChanged(Vector2 dir)
    {
        _moveDir = dir;
    }

    private void HandleOnJoystickStateChanged(EJoystcikState joystickState)
    {
        switch (joystickState)
        {
            case EJoystcikState.PointerDown:
                CreatureState = ECreatureState.Move;
                break;
            case EJoystcikState.Drag:
                break;
            case EJoystcikState.PointerUp:
                CreatureState = ECreatureState.Idle;
                break;
            default:
                break;
        }
    }
}
