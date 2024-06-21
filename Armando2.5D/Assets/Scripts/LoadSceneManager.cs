using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Fase1();
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
}
