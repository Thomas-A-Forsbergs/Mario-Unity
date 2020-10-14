using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    public Animator startButton;
    public Animator settingsButton;
    public Animator dialog;

    public void StartGame() 
    {
        //SceneManager.LoadScene("Main");
    }

    public void OpenSettings() 
    {
        startButton.SetBool("isHidden", true);
        settingsButton.SetBool("isHidden", true);
        dialog.SetBool("isHidden", false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
