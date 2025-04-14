using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IZombieState
{
    void Enter(Zombie zombie);

    void Exit(Zombie zombie);

    void Update(Zombie zombie);

    void FixedUpdate(Zombie zombie);

    void OnCollisionEnter2D(Collision2D collision, Zombie zombie);

    void OnCollisionStay2D(Collision2D collision, Zombie zombie);

    void OnCollisionExit2D(Collision2D collision, Zombie zombie);
}
