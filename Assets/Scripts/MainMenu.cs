using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenu : MonoBehaviour
{


    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button quitButton;

    public  void OnClickPlay()
    {
        SceneManager.LoadScene(sceneName:"GameScene");
    }
    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void Start()
    {
        //playButton.onClick.AddListener(() => {
            
            //OnClickPlay();
            //Debug.Log(message: "Opening Game Scene");

        //}) ;
       // playButton.onClick.AddListener(OnClickQuit);
      }

}

