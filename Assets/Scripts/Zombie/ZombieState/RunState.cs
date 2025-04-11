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
        zombie.Rigid.velocity = new Vector2(-zombie.RunSpeed, zombie.Rigid.velocity.y);

        RaycastHit2D forwardRaycastHit2D = Physics2D.Raycast(zombie.Rigid.position + new Vector2(-zombie.Collider.size.x + 0.1f, 0f), Vector2.left, zombie.RayDistance);
        Debug.DrawRay(zombie.Rigid.position + new Vector2(-zombie.Collider.size.x + 0.1f, 0f), Vector2.left * zombie.RayDistance, Color.red);

        if (forwardRaycastHit2D.collider != null)
        {
            if (forwardRaycastHit2D.transform.gameObject.layer == zombie.gameObject.layer)
            {
                if (forwardRaycastHit2D.transform.TryGetComponent<Zombie>(out Zombie hittedZombie))
                {
                    if (hittedZombie.RunSpeed <= zombie.RunSpeed)
                    {
                        zombie.ChangeState(Zombie.CLIMBSTATE);
                    }
                }
            }
            else if (forwardRaycastHit2D.transform.gameObject.layer == LayerMask.NameToLayer("Box"))
            {
                zombie.ChangeState(Zombie.ATTACKSTATE);
            } 
        }
        else Debug.Log("collider is null");

        // ¹Ù´ÚÀ¸·Î Ray¸¦ ½ð´Ù
        // ¶¥ÀÌ¸é ¿ø·¡ mass, Á»ºñ¸é HeavyMass..!
        // int layerMask = (1 << LayerMask)
        //RaycastHit2D downRaycastHit2D = Physics2D.Raycast(zombie.Rigid.position, Vector2.down, zombie.RayDistance);
        //Debug.DrawRay(zombie.Rigid.position, Vector3.down * zombie.RayDistance, Color.red);

        //if (downRaycastHit2D.collider != null)
        //{
        //    if (downRaycastHit2D.transform.gameObject.layer == LayerMask.NameToLayer("Ground1"))
        //    {
        //        //zombie.Rigid.mass = 10f;
        //    }
        //    else if (downRaycastHit2D.transform.gameObject.layer == zombie.gameObject.layer)
        //    {
        //        //zombie.Rigid.mass = 100f;
        //    }
    }
}
