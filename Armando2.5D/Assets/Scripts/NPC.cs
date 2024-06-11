using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    [SerializeField] private bool ColliderPlayer = false;

    [SerializeField] private TextMeshProUGUI TextMeshPro;
    [SerializeField] private string FalaPersonagem;

    private void Start()
    {
    }
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
        }
    }

    void Update()
    {
        if (ColliderPlayer && Input.GetButtonDown("Fire1"))
        {
            TextMeshPro.text = FalaPersonagem;
        }
        if (ColliderPlayer == false)
        {
            TextMeshPro.text = null;
        }
    }
}
