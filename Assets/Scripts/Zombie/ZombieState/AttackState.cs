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
        RaycastHit2D raycastHit2D = Physics2D.Raycast(zombie.Rigid.position + new Vector2(-zombie.Collider.size.x + 0.1f, zombie.Collider.size.y / 2f), Vector2.left, zombie.RayDistance);
        Debug.DrawRay(zombie.Rigid.position + new Vector2(-zombie.Collider.size.x + 0.1f, zombie.Collider.size.y / 2f), Vector2.left * zombie.RayDistance, Color.red);

        if (raycastHit2D.collider != null)
        {
            if (raycastHit2D.transform.gameObject.layer != LayerMask.NameToLayer("Box"))
            {
                zombie.ChangeState(Zombie.RUNSTATE);
            }
        }
        else zombie.ChangeState(Zombie.RUNSTATE);
    }
}
