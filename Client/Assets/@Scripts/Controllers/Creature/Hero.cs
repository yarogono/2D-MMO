using System;
using UnityEngine;
using static Define;

public class Hero : Creature
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        CreatureType = ECreatureType.Hero;
        CreatureState = ECreatureState.Idle;
        Speed = 5.0f;

        Managers.Game.OnJoystickStateChanged -= HandleOnJoystickStateChanged;
        Managers.Game.OnJoystickStateChanged += HandleOnJoystickStateChanged;

        return true;
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
