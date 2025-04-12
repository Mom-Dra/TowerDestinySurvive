using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBack : IZombieState
{
    public void Enter(Zombie zombie)
    {
        zombie.ZombieState = ZombieState.RunBack;
        zombie.Rigid.mass = zombie.ZombieData.RunBackMass;

        zombie.RunBackTargetPosX = zombie.Rigid.position.x + zombie.Size.x + 0.3f;
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
        zombie.Rigid.velocity = new Vector2(zombie.ZombieData.RunSpeed, zombie.Rigid.velocity.y);

        if (zombie.Rigid.position.x > zombie.RunBackTargetPosX) zombie.ChangeState(Zombie.RUNSTATE);

        //RaycastHit2D forwardRaycastHit2D = Physics2D.Raycast(zombie.Rigid.position + new Vector2(-zombie.Collider.size.x + 0.1f, 0f), Vector2.left, zombie.RayDistance);
        //Debug.DrawRay(zombie.Rigid.position + new Vector2(-zombie.Collider.size.x + 0.1f, 0f), Vector2.left * zombie.RayDistance, Color.red);

        //if (forwardRaycastHit2D.collider == null) zombie.ChangeState(Zombie.RUNSTATE);
    }
}
