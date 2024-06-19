using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    #region Status
    [Header("Status")]
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private float JumpForce = 5f;
    [SerializeField] public int Life = 10;
    [Space(20)]
    #endregion

    #region Variables Worlds
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float GroundCheckRadius = 0.2f;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private bool IsGrounded;

    [SerializeField] private Rigidbody _Rigidbody;
    [SerializeField] private Animator _Animator;
    [SerializeField] private SpriteRenderer _SpriteRender;
    #endregion

    void Start()
    {
        _SpriteRender = GetComponent<SpriteRenderer>();
        _Animator = GetComponent<Animator>();
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

        if(Life <= 0)
        {
            SceneManager.LoadScene(1);
        }
        //animação
        if (Input.GetAxis("Horizontal") != 0)
        {
            _Animator.SetBool("IsRun", true);
            if (Input.GetAxis("Horizontal") < 0)
            {
                _SpriteRender.flipX = true;
            }
            else
            {
                _SpriteRender.flipX = false;
            }
        }
        else
        {
            _Animator.SetBool("IsRun", false);
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

