using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class score : MonoBehaviour {
    public float total;
    public float blocked;
    public int streak;
    public Text scoreText;
    public Text streakText;
    
	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (blocked == total)
        {
            finish();
        }
        scoreText.text = "" + blocked + "/" + total + " = " + (blocked / total * 100-blocked / total * 100%0.1f) +"%";
        streakText.text = "Streak: " + streak;
	}
    void finish()
    {
        GameObject.FindGameObjectWithTag("result").GetComponent<result>().finish = true;
        //Destroy(GameObject.FindGameObjectWithTag("music"));
        SceneManager.LoadScene("results");
    }
}
