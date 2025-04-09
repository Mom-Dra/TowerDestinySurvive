using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : IZombieState
{
    public void Enter(Zombie zombie)
    {
        zombie.ZombieState = ZombieState.Die;
        zombie.Animator.SetBool("IsDead", true);
    }

    public void Exit(Zombie zombie)
    {
        zombie.Animator.SetBool("IsDead", false);
    }

    public void Update(Zombie zombie)
    {

    }

    public void FixedUpdate(Zombie zombie)
    {

    }
}
