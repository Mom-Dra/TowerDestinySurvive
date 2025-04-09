using System.Collections;
using System.Collections.Generic;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump!!");

            zombie.Rigid.velocity = new Vector2(zombie.Rigid.velocity.x, zombie.ClimbSpeed);
        }
    }

    public void FixedUpdate(Zombie zombie)
    {
        //zombie.Rigid.MovePosition(zombie.Rigid.position + Vector2.left * zombie.RunSpeed * Time.fixedDeltaTime);
        zombie.Rigid.velocity = new Vector2(-zombie.RunSpeed, zombie.Rigid.velocity.y);

        Debug.Log($"{zombie.Rigid.velocity}");

        RaycastHit2D raycastHit2D = Physics2D.Raycast(zombie.Rigid.position + new Vector2(-zombie.Collider.size.x + 0.1f, zombie.Collider.size.y / 2f), Vector2.left, zombie.RayDistance);
        Debug.DrawRay(zombie.Rigid.position + new Vector2(-zombie.Collider.size.x + 0.1f, zombie.Collider.size.y / 2f), Vector2.left * zombie.RayDistance, Color.red);

        if (raycastHit2D.collider != null)
        {
            if (raycastHit2D.transform.gameObject.layer == zombie.gameObject.layer)
            {
                zombie.Rigid.velocity = new Vector2(zombie.Rigid.velocity.x, zombie.ClimbSpeed);
                zombie.ChangeState(Zombie.CLIMBSTATE);
            }
            else if (raycastHit2D.transform.gameObject.layer == LayerMask.NameToLayer("Box"))
            {
                zombie.ChangeState(Zombie.ATTACKSTATE);
            }
        }
        else Debug.Log("collider null");
    }
}
