using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    [SerializeField] private bool ColliderPlayer = false;

    [SerializeField] private TextMeshProUGUI TextMeshPro;
    [SerializeField] private string FalaPersonagem;
    [SerializeField] private GameObject CaixaDeDialogo;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip dialogSound;
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ColliderPlayer = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ColliderPlayer = false;
            ClearText();
        }
    }

    void Update()
    {
        if (ColliderPlayer && Input.GetButtonDown("Fire1"))
        {
            DisplayText();
        }
    }
    private void DisplayText()
    {
        CaixaDeDialogo.SetActive(true);
        TextMeshPro.text = FalaPersonagem;
        PlayDialogSound();
    }
    private void ClearText()
    {
        CaixaDeDialogo.SetActive(false);
        TextMeshPro.text = string.Empty;
    }

    private void PlayDialogSound()
    {
        if (audioSource != null && dialogSound != null)
        {
            audioSource.clip = dialogSound;
            audioSource.Play();
        }
    }
}