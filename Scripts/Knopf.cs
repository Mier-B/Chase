using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knopf : MonoBehaviour
{
    public void StartGame()
    {
        // loads the game scene
        SceneManager.LoadScene("Stunde 1");
    }
}
