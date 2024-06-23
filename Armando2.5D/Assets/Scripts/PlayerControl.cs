using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    #region(Status)
    [Header("Status")]
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private float JumpForce = 5f;
    [SerializeField] public int Life = 10;
    [SerializeField] private string TagPlayer;
    [SerializeField] bool IsPlayer;
    #endregion

    #region(World Variables)
    [Header("World Variables")]
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float GroundCheckRadius = 0.2f;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private bool IsGrounded;
    #endregion

    #region(Components)
    [Header("Components")]
    [SerializeField] private Rigidbody _Rigidbody;
    [SerializeField] private Animator _Animator;
    [SerializeField] private SpriteRenderer _SpriteRender;
    [SerializeField] private AudioSource footstepSound;
    [SerializeField] private Transform _Transform;
    #endregion

    #region(Sound Effects)
    [Header("Sound Effects")]
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip landSound;
    [SerializeField] private AudioSource audioSource;

    // Ajuste de volume dos sons
    [Header("Volume Settings")]
    [SerializeField] private float footstepVolume = 1.0f;
    [SerializeField] private float jumpVolume = 1.0f;
    [SerializeField] private float landVolume = 1.0f;
    #endregion

    private bool wasGrounded;

    void Start()
    {
        IsPlayer = true;
        TagPlayer = gameObject.tag;

        _SpriteRender = GetComponent<SpriteRenderer>();
        _Animator = GetComponent<Animator>();
        _Rigidbody = GetComponent<Rigidbody>();
        wasGrounded = true;

        // Define os volumes iniciais
        footstepSound.volume = footstepVolume;
        audioSource.volume = jumpVolume;  // Padrão para som de salto
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.z = 0.5f;
        transform.position = currentPosition;

        float move = Input.GetAxis("Horizontal");
        _Rigidbody.velocity = new Vector3(move * MoveSpeed, _Rigidbody.velocity.y, 0);

        IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundCheckRadius, GroundLayer);

        if (IsGrounded && !wasGrounded)
        {
            PlayLandSound();
        }

        if (IsGrounded && Input.GetButtonDown("Jump"))
        {
            _Rigidbody.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
            _Animator.SetBool("IsJump", true);
            PlayJumpSound();
        }

        if (Life <= 0)
        {
            SceneManager.LoadScene(1);
        }

        // Animação e Sons
        if (move != 0)
        {
            _Animator.SetBool("IsRun", true);
            if (IsGrounded && !footstepSound.isPlaying)
            {
                footstepSound.volume = footstepVolume;
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

        wasGrounded = IsGrounded;

        Debug.Log(IsPlayer);
        UpdateTag();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("barril"))
        {
            IsPlayer = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("barril"))
        {
            IsPlayer = true;
        }
    }
    private void UpdateTag()
    {
        if (IsPlayer == true)
        {
            gameObject.tag = "Player";
            _SpriteRender.enabled = true;
                }
        else
        {
            gameObject.tag = "NoPlayer";
            _SpriteRender.enabled = false;
        }
    }
    void PlayJumpSound()
    {
        if (audioSource != null && jumpSound != null)
        {
            audioSource.clip = jumpSound;
            audioSource.volume = jumpVolume;
            audioSource.Play();
        }
    }

    void PlayLandSound()
    {
        if (audioSource != null && landSound != null)
        {
            audioSource.clip = landSound;
            audioSource.volume = landVolume;
            audioSource.Play();
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