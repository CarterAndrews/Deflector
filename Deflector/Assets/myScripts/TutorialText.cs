using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialText : MonoBehaviour {
    public Text rotateText;
    public Text WASDtext;
    public Text scoreText;
    public Text streakText;
    public float textDuration;
    public float fadeSpeed;
    public bool WASDON;
    public bool finished;
	// Use this for initialization
	void Start () {
        StartCoroutine(wait());
        finished = false;
        WASDtext.color = new Color(0, 0, 0, 0);
        scoreText.color = new Color(0, 0, 0, 0);
        streakText.color = new Color(0, 0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.color = Color.Lerp(scoreText.color, new Color(0, 0, 1, 1), fadeSpeed);
        streakText.color = Color.Lerp(streakText.color, new Color(0, 0, 1, 1), fadeSpeed);
        if (!WASDON)
        {
            WASDtext.color = Color.Lerp(WASDtext.color, new Color(0, 0, 1, 0), fadeSpeed);
        }
        else
        {
            WASDtext.color = Color.Lerp(WASDtext.color, new Color(0, 0, 1, 1), fadeSpeed);
        }
        if (WASDtext.color.a <0.2f&&!finished&&!WASDON)
        {
            rotateText.color = Color.Lerp(rotateText.color, new Color(0, 0, 1, 1), fadeSpeed);
        }
        if (rotateText.color.a > 0.9)
        {
            finished = true;            
        }
        if (finished)
        {
            rotateText.color = Color.Lerp(rotateText.color, new Color(0, 0, 1, 0), fadeSpeed);
        }
	}
  
    private IEnumerator wait()
    {
        WASDON = true;
        yield return new WaitForSeconds(textDuration);
        WASDON = false;
    }
}
