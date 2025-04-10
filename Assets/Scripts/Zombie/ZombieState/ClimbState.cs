using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbState : IZombieState
{
    public void Enter(Zombie zombie)
    {
        zombie.ZombieState = ZombieState.Climb;
        zombie.Rigid.mass = 1f;
    }

    public void Exit(Zombie zombie)
    {

    }

    public void Update(Zombie zombie)
    {

    }

    public void FixedUpdate(Zombie zombie)
    {
        zombie.Rigid.velocity = new Vector2(-zombie.ClimbSpeed.x, zombie.ClimbSpeed.y);

        RaycastHit2D raycastHit2D = Physics2D.Raycast(zombie.Rigid.position + new Vector2(-zombie.Collider.size.x + 0.1f, zombie.Collider.size.y / 2f), Vector2.left, zombie.RayDistance);
        Debug.DrawRay(zombie.Rigid.position + new Vector2(-zombie.Collider.size.x + 0.1f, zombie.Collider.size.y / 2f), Vector2.left * zombie.RayDistance, Color.red);

        if (raycastHit2D.collider != null)
        {
            if (raycastHit2D.transform.gameObject.layer == LayerMask.NameToLayer("Box"))
            {
                zombie.ChangeState(Zombie.ATTACKSTATE);
            }
        }
        else
        {
            zombie.ChangeState(Zombie.RUNSTATE);
        }
    }
}
