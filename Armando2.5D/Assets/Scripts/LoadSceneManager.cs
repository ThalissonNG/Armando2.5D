using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject Texto;
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Texto.SetActive(true);
            StartCoroutine(Timer());
        }
    }
    public void Fase1()
    {
        SceneManager.LoadScene(1);
    }
    public void Fase2()
    {
        SceneManager.LoadScene(2);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(25);
        Fase1();
    }
}