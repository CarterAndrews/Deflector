using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneSwitch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public void Switch()
    {
        SceneManager.LoadScene("Easy");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
