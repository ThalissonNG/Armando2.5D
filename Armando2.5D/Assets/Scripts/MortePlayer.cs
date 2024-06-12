using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MortePlayer : MonoBehaviour
{
    [SerializeField] private PlayerControl _PlayerControl;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _PlayerControl.Life = 0;
        }
    }
}
