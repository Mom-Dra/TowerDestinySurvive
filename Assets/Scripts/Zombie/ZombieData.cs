using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZombieData", menuName = "ZombieData")]
public class ZombieData : ScriptableObject
{
    public float RunSpeed;

    public Vector2 ClimbSpeed;

    public float RayDistance;

    public float UpRayDistance;

    public float DownRayDistance;

    public float ClimbMass;

    public float RunBackMass;
}
