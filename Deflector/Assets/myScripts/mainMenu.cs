using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour {
    public void Menu()
    {
        Destroy(GameObject.FindGameObjectWithTag("music"));
        Destroy(GameObject.FindGameObjectWithTag("result"));
        SceneManager.LoadScene("Menu");
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
