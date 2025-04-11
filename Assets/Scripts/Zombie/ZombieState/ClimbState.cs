using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbState : IZombieState
{
    public void Enter(Zombie zombie)
    {
        zombie.ZombieState = ZombieState.Climb;
        zombie.Rigid.mass = zombie.ClimbMass;
    }

    public void Exit(Zombie zombie)
    {
        zombie.Rigid.mass = zombie.OriginalMass;
    }

    public void Update(Zombie zombie)
    {

    }

    public void FixedUpdate(Zombie zombie)
    {
        zombie.Rigid.velocity = new Vector2(-zombie.ClimbSpeed.x, zombie.ClimbSpeed.y);

        RaycastHit2D raycastHit2D = Physics2D.Raycast(zombie.Rigid.position + new Vector2(-zombie.Collider.size.x + 0.1f, 0f), Vector2.left, zombie.RayDistance);
        Debug.DrawRay(zombie.Rigid.position + new Vector2(-zombie.Collider.size.x + 0.1f, 0f), Vector2.left * zombie.RayDistance, Color.red);

        if (raycastHit2D.collider != null)
        {
            if (raycastHit2D.transform.gameObject.layer == LayerMask.NameToLayer("Box"))
            {
                zombie.ChangeState(Zombie.RUNSTATE);
            }
        }
        else
        {
            zombie.ChangeState(Zombie.RUNSTATE);
        }
    }
}
