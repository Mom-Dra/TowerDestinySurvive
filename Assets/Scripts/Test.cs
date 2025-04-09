using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Rigidbody2D rigid;

    [SerializeField]
    private float jumpPower;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            rigid.AddForce(Vector2.up * jumpPower);
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(rigid.position, Vector2.left, 1f, 1 << transform.gameObject.layer);

        Debug.DrawRay(transform.position, Vector3.left, Color.red);

        if(raycastHit2D.collider != null)
        {
            Debug.Log($"{raycastHit2D.transform.name}: {raycastHit2D.transform.gameObject.layer}");
        }
    }
}
