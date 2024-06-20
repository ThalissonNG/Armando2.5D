using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private float JumpForce = 5f;
    [SerializeField] public int Life = 10;

    [Header("World Variables")]
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float GroundCheckRadius = 0.2f;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private bool IsGrounded;

    [SerializeField] private Rigidbody _Rigidbody;
    [SerializeField] private Animator _Animator;
    [SerializeField] private SpriteRenderer _SpriteRender;
    [SerializeField] private AudioSource footstepSound;

    private bool isMoving = false;

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

        if (Life <= 0)
        {
            SceneManager.LoadScene(1);
        }

        // Animação e Sons
        if (move != 0)
        {
            _Animator.SetBool("IsRun", true);
            if (!footstepSound.isPlaying)
            {
                footstepSound.Play();
            }

            if (move < 0)
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
            footstepSound.Stop();
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