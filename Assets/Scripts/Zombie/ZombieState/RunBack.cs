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
        zombie.Rigid.velocity = new Vector2(zombie.ZombieData.RunSpeed * 0.8f, zombie.Rigid.velocity.y);

        if (zombie.Rigid.position.x > zombie.RunBackTargetPosX) zombie.ChangeState(Zombie.RUNSTATE);
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
