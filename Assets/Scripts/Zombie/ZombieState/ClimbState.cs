using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbState : IZombieState
{
    public void Enter(Zombie zombie)
    {
        zombie.ZombieState = ZombieState.Climb;
    }

    public void Exit(Zombie zombie)
    {

    }

    public void Update(Zombie zombie)
    {

    }

    public void FixedUpdate(Zombie zombie)
    {
        zombie.Rigid.velocity = new Vector2(-zombie.RunSpeed, zombie.ClimbSpeed);
    }
}
