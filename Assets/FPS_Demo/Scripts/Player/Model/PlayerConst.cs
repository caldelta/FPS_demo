using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConst
{
    public const float MOVEMENT_SPEED = 10;
    public const float ROTATION_SPEED = 50;

    public static readonly int RunStateHash = Animator.StringToHash("speed");
    public static readonly int FireStateHash = Animator.StringToHash("fire");
}