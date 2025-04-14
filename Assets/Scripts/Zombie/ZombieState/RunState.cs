using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RunState : IZombieState
{
    public void Enter(Zombie zombie)
    {
        zombie.ZombieState = ZombieState.Run;
        zombie.Animator.SetBool("IsIdle", true);
    }

    public void Exit(Zombie zombie)
    {
        zombie.Animator.SetBool("IsIdle", false);
    }

    public void Update(Zombie zombie)
    {
        
    }

    public void FixedUpdate(Zombie zombie)
    {
        zombie.Rigid.velocity = new Vector2(-zombie.ZombieData.RunSpeed, zombie.Rigid.velocity.y);
    }

    public void OnCollisionEnter2D(Collision2D collision, Zombie zombie)
    {
        if (collision.transform.gameObject.layer == zombie.gameObject.layer)
        {
            Zombie collisionZombie = collision.gameObject.GetComponent<Zombie>();

            if (collisionZombie.transform.position.x < zombie.transform.position.x && collisionZombie.ZombieData.RunSpeed <= zombie.ZombieData.RunSpeed)
                zombie.ChangeState(Zombie.CLIMBSTATE);
        }
    }

    public void OnCollisionStay2D(Collision2D collision, Zombie zombie)
    {
        if (collision.transform.gameObject.layer == LayerMask.NameToLayer("Box"))
            zombie.ChangeState(Zombie.ATTACKSTATE);
    }

    public void OnCollisionExit2D(Collision2D collision, Zombie zombie)
    {

    }
}
