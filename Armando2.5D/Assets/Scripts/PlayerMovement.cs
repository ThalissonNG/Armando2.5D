using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Status
    [Header("Status")]
    [SerializeField] private float MoveSpeed = 5f;
    public float JumpForce = 5f;
    #endregion

    public Transform GroundCheck;
    public float GroundCheckRadius = 0.2f;
    public LayerMask GroundLayer;

    [SerializeField] private Rigidbody _Rigidbody;
    [SerializeField] private bool IsGrounded;

    void Start()
    {
        _Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        _Rigidbody.velocity = new Vector3(move * MoveSpeed, _Rigidbody.velocity.y, 0);

        IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundCheckRadius, GroundLayer);

        if (IsGrounded && Input.GetButtonDown("Jump"))
        {
            _Rigidbody.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (GroundCheck == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(GroundCheck.position, GroundCheckRadius);
    }
}

