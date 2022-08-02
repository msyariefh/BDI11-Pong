using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Created by M Syarief Hidayatullh - BDI11");
        SceneManager.LoadScene(1);
    }
}
