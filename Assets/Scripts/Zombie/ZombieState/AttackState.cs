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
        RaycastHit2D forwardRaycastHit2D = Physics2D.Raycast(zombie.Rigid.position + new Vector2(-zombie.Collider.size.x + 0.1f, 0f), Vector2.left, zombie.ZombieData.RayDistance);
        Debug.DrawRay(zombie.Rigid.position + new Vector2(-zombie.Collider.size.x + 0.1f, 0f), Vector2.left * zombie.ZombieData.RayDistance, Color.red);

        if (forwardRaycastHit2D.collider != null)
        {
            if (forwardRaycastHit2D.transform.gameObject.layer != LayerMask.NameToLayer("Box"))
            {
                zombie.ChangeState(Zombie.RUNSTATE);
            }
        }
        else zombie.ChangeState(Zombie.RUNSTATE);

        RaycastHit2D upRaycastHit2D = Physics2D.Raycast(zombie.Rigid.position + new Vector2(0f, zombie.Collider.size.y), Vector2.up, zombie.ZombieData.UpRayDistance);
        Debug.DrawRay(zombie.Rigid.position + new Vector2(0f, zombie.Collider.size.y), Vector2.up * zombie.ZombieData.UpRayDistance, Color.red);

        if(upRaycastHit2D.collider != null)
        {
            if(upRaycastHit2D.transform.gameObject.layer == zombie.gameObject.layer)
            {
                //zombie.Rigid.velocity = new Vector2(zombie.RunSpeed, zombie.Rigid.velocity.y);
                //zombie.Rigid.AddForce(Vector2.right * 300f, ForceMode2D.Impulse);

                //if (zombie.IsGround)
                    zombie.ChangeState(Zombie.RUNBACKSTATE);
            }
        }
    }
}
