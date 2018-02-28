using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    public float fadeDuration;
    public bool fading;
    public float fadeSpeed;
    string sceneIndex;
    public Text[] textfaders;
    public Image[] buttonfaders;
	// Use this for initialization
	void Start () {
        fading = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (fading)
        {
            for(int i = 0; i < textfaders.Length; i++)
            {
                textfaders[i].color = Color.Lerp(textfaders[i].color, new Color(0, 0, 0, 0), fadeSpeed);
            }
            for (int i = 0; i < buttonfaders.Length; i++)
            {
                buttonfaders[i].color = Color.Lerp(buttonfaders[i].color, new Color(0, 0, 0, 0), fadeSpeed);
            }
        }
	}
    public void Easy()
    {
        sceneIndex = "controls";
        StartCoroutine(fade());
    }
    public void Hard()
    {
        sceneIndex = "Hard";
        StartCoroutine(fade());
    }
    public void medium()
    {
        sceneIndex = "Medium";
        StartCoroutine(fade());
    }
    public IEnumerator fade()
    {
        fading = true;
        yield return new WaitForSeconds(fadeDuration);
        SceneManager.LoadScene(sceneIndex);
    }
}
