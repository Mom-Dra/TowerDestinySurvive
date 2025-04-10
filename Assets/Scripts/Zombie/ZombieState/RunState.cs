using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IZombieState
{
    public void Enter(Zombie zombie)
    {
        zombie.ZombieState = ZombieState.Run;
        zombie.Animator.SetBool("IsIdle", true);
        zombie.Rigid.mass = 10f;
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
        zombie.Rigid.velocity = new Vector2(-zombie.RunSpeed, zombie.Rigid.velocity.y);

        RaycastHit2D raycastHit2D = Physics2D.Raycast(zombie.Rigid.position + new Vector2(-zombie.Collider.size.x + 0.1f, zombie.Collider.size.y / 2f), Vector2.left, zombie.RayDistance);
        Debug.DrawRay(zombie.Rigid.position + new Vector2(-zombie.Collider.size.x + 0.1f, zombie.Collider.size.y / 2f), Vector2.left * zombie.RayDistance, Color.red);

        if (raycastHit2D.collider != null)
        {
            if (raycastHit2D.transform.gameObject.layer == zombie.gameObject.layer)
            {
                if(raycastHit2D.transform.TryGetComponent<Zombie>(out Zombie hittedZombie))
                {
                    if (hittedZombie.RunSpeed <= zombie.RunSpeed)
                        zombie.ChangeState(Zombie.CLIMBSTATE);
                }
            }
            else if (raycastHit2D.transform.gameObject.layer == LayerMask.NameToLayer("Box"))
            {
                zombie.ChangeState(Zombie.ATTACKSTATE);
            }
        }
        else Debug.Log("collider is null");
    }
}
