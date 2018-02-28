using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeIn : MonoBehaviour {
    public Text[] fades;
    public float fadeSpeed;
	// Use this for initialization
	void Start () {
		foreach(Text a in fades)
        {
            a.color = new Color(0, 0, 0, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Text a in fades)
        {
            a.color = Color.Lerp(a.color,new Color(0, 0, 1, 1),fadeSpeed);
        }
    }
}
