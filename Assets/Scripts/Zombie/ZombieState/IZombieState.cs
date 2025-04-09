using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IZombieState
{
    void Enter(Zombie zombie);

    void Exit(Zombie zombie);

    void Update(Zombie zombie);

    void FixedUpdate(Zombie zombie);
}
