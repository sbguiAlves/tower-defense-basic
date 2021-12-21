using UnityEngine;
using UnityEngine.SceneManagement;

public class Configuration : MonoBehaviour
{
    private bool isAbout;
    private bool isPressed;
    public GameObject MenuUI;
    public GameObject AboutUI;

    void Start()
    {
        isAbout=false;
        isPressed=false;
    }

    void Update()
    {
        if(isPressed==true)
        {
            MenuUI.SetActive(false);
            Time.timeScale = 1f;
        }
        else if(isPressed==false)
        {
            Time.timeScale = 0f;

            if(isAbout==true)
                MenuUI.SetActive(false);
            else
                MenuUI.SetActive(true);
        }
    }

    public void PlayClick()
    {
        if(isPressed)
            isPressed=false;
        else
            isPressed=true;
    }

    public void Leave()
    {
        Application.Quit();
    }

    public void About()
    {
        isAbout=true;
        AboutUI.SetActive(true);
    }

    public void Back()
    {
        isAbout=false;
        AboutUI.SetActive(false);
    }
    
}
