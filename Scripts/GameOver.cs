using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
   public Text zeit ;

   public void Setup(float t){

    gameObject.SetActive(true);

    string minutes = ((int)t / 60).ToString();
    string seconds = (t % 60).ToString("f2");
    zeit.text=minutes + ":" + seconds;
   }

   public void restart(){
   SceneManager.LoadScene("Stunde 1");
   }

   public void exit (){
   Application.Quit();
   }

}
