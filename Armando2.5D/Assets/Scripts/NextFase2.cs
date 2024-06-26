using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextFase2 : MonoBehaviour
{
    [SerializeField] private GameObject FadeImage;
    [SerializeField] private GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.SetActive(false);
            FadeImage.SetActive(true);
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene(0);
    }
}
