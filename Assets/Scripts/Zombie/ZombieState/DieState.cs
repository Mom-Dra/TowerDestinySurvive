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

    public void OnCollisionEnter2D(Collision2D collision, Zombie zombie)
    {

    }

    public void OnCollisionStay2D(Collision2D collision, Zombie zombie)
    {

    }

    public void OnCollisionExit2D(Collision2D collision, Zombie zombie)
    {

    }
}
