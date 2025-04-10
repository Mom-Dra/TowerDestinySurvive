using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public static readonly IZombieState RUNSTATE = new RunState();
    public static readonly IZombieState ATTACKSTATE = new AttackState();
    public static readonly IZombieState CLIMBSTATE = new ClimbState();
    public static readonly IZombieState DIESTATE = new DieState();
    private IZombieState currState = RUNSTATE;

    [SerializeField]
    private ZombieState zombieState = ZombieState.Run;

    public ZombieState ZombieState { get => zombieState; set => zombieState = value; }

    [Header("Component")]
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Rigidbody2D rigid;

    [SerializeField]
    private CapsuleCollider2D zombieCollider;

    public Animator Animator => animator;

    public Rigidbody2D Rigid => rigid;

    public CapsuleCollider2D Collider => zombieCollider;

    [Header("value")]
    [SerializeField]
    private float runSpeed;

    [SerializeField]
    private Vector2 climbSpeed;

    [SerializeField]
    private float rayDistance;

    public float RunSpeed => runSpeed;

    public float RayDistance => rayDistance;

    public Vector2 ClimbSpeed => climbSpeed;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        zombieCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        currState.Update(this);

        if(Input.GetKeyDown(KeyCode.U))
        {
            ChangeState(CLIMBSTATE);
        }
    }

    private void FixedUpdate()
    {
        currState.FixedUpdate(this);
    }

    public void OnAttack()
    {
        Debug.Log("OnAttack");
    }

    internal void ChangeState(IZombieState nextState)
    {
        if (currState == nextState) return;

        currState.Exit(this);
        currState = nextState;
        currState.Enter(this);
    }
}
