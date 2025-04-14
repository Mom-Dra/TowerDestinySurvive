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

    public void OnCollisionEnter2D(Collision2D collision, Zombie zombie)
    {

    }

    public void OnCollisionStay2D(Collision2D collision, Zombie zombie)
    {
        if (collision.gameObject.layer == zombie.gameObject.layer)
        {
            if (collision.transform.position.y > zombie.transform.position.y + 0.3f)
            {
                zombie.ChangeState(Zombie.RUNBACKSTATE);
            }
        }
    }

    public void OnCollisionExit2D(Collision2D collision, Zombie zombie)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Box"))
        {
            zombie.ChangeState(Zombie.RUNSTATE);
        }
    }
}
