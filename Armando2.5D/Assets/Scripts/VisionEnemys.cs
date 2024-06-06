using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionEnemys : MonoBehaviour
{
    [SerializeField] private bool IsVision;

    [SerializeField] private AiEnemys _AiEnemys;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _AiEnemys.IsFollow = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _AiEnemys.IsFollow = false;
        }
    }
}
