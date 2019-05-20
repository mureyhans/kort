using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Tutorial(){
		Debug.Log("TUTORIAL!");
	    SceneManager.LoadScene(3);
	}
	public void About(){
		Debug.Log("ABOUT!");
		SceneManager.LoadScene(4);
	}
    public void ExitGame(){
		Debug.Log("EXIT!");
    	Application.Quit();
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
