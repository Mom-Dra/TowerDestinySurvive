using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbState : IZombieState
{
    public void Enter(Zombie zombie)
    {
        zombie.ZombieState = ZombieState.Climb;
        zombie.Rigid.mass = zombie.ZombieData.ClimbMass;
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
        zombie.Rigid.velocity = new Vector2(-zombie.ZombieData.ClimbSpeed.x, zombie.ZombieData.ClimbSpeed.y);
    }

    public void OnCollisionEnter2D(Collision2D collision, Zombie zombie)
    {
        if(collision.transform.gameObject.layer == LayerMask.NameToLayer("Box"))
        {
            zombie.ChangeState(Zombie.ATTACKSTATE);
        }
    }

    public void OnCollisionStay2D(Collision2D collision, Zombie zombie)
    {
        if (collision.transform.gameObject.layer == zombie.gameObject.layer)
        {
            Zombie collisionZombie = collision.gameObject.GetComponent<Zombie>();

            if (collisionZombie.transform.position.x < zombie.transform.position.x && collisionZombie.ZombieState == ZombieState.Climb)
                zombie.ChangeState(Zombie.RUNSTATE);
        }
    }

    public void OnCollisionExit2D(Collision2D collision, Zombie zombie)
    {
        if (collision.transform.gameObject.layer == zombie.gameObject.layer)
        {
            Zombie collisionZombie = collision.gameObject.GetComponent<Zombie>();

            zombie.ChangeState(Zombie.RUNSTATE);
        }
    }
}
