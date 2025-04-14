using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public static readonly IZombieState RUNSTATE = new RunState();
    public static readonly IZombieState ATTACKSTATE = new AttackState();
    public static readonly IZombieState CLIMBSTATE = new ClimbState();
    public static readonly IZombieState RUNBACKSTATE = new RunBack();
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
    private ZombieData zombieData;

    public ZombieData ZombieData => zombieData;

    [SerializeField]
    private bool isGround;

    public bool IsGround => isGround;

    public float RunBackTargetPosX { get; set; }

    public Vector2 Size { get; private set; }

    public float OriginalMass { get; private set; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        zombieCollider = GetComponent<CapsuleCollider2D>();

        Size = zombieCollider.size;
        OriginalMass = rigid.mass;
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

    }

    internal void ChangeState(IZombieState nextState)
    {
        if (currState == nextState) return;

        currState.Exit(this);
        currState = nextState;
        currState.Enter(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currState.OnCollisionEnter2D(collision, this);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        currState.OnCollisionStay2D(collision, this);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        currState.OnCollisionExit2D(collision, this);
    }
}
