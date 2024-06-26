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
    [SerializeField] private GameObject PressB;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip dialogSound;
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ColliderPlayer = true;
            PressB.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ColliderPlayer = false;
            ClearText();
            PressB.SetActive(false);
        }
    }

    void Update()
    {
        if (ColliderPlayer && Input.GetButtonDown("Fire2"))
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