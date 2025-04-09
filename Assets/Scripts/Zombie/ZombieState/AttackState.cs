using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IZombieState
{
    public void Enter(Zombie zombie)
    {
        zombie.ZombieState = ZombieState.Attack;
        zombie.Animator.SetBool("IsAttacking", true);
    }

    public void Exit(Zombie zombie)
    {
        zombie.Animator.SetBool("IsAttacking", false);
    }

    public void Update(Zombie zombie)
    {

    }

    public void FixedUpdate(Zombie zombie)
    {

    }
}
