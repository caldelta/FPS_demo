using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConst
{
    public const float HEALH_POINT = 10;
    public const int ATTACK_RANGE = 30;
    public const int ATTACK_DAMAGE = 1;
    public const int GRENADE_DAMAGE = 2;

    public const float MOVEMENT_SPEED = 10;
    public const float ROTATION_SPEED = 50;

    public static readonly int RunStateHash = Animator.StringToHash("speed");
    public static readonly int FireStateHash = Animator.StringToHash("fire");
    public static readonly int GrenadeStateHash = Animator.StringToHash("grenade");

    public static readonly Vector3 CrossHairPos = new Vector3(Screen.width >> 1, Screen.height >> 1);

    public const float CAMERA_ROT_MIN_X = -360F;
    public const float CAMERA_ROT_MAX_X = 360F;
    public const float CAMERA_ROT_MIN_Y = -40F;
    public const float CAMERA_ROT_MAX_Y = 40F;

    public const float CAMERA_ROT_SENSITIVITY = 1;

}