using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public void Fase1()
    {
        SceneManager.LoadScene(1);
    }
    public void Fase2()
    {
        SceneManager.LoadScene(2);
        Debug.Log("Fase 2");
    }
    public void Fase3()
    {
        SceneManager.LoadScene(3);
        Debug.Log("Fase 3");
    }
    public void Fase4()
    {
        SceneManager.LoadScene(4);
        Debug.Log("Fase 4");
    }
    public void Fase5()
    {
        SceneManager.LoadScene(5);
        Debug.Log("Fase 5");
    }
}
