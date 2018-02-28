using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class outcomeText : MonoBehaviour {
    Text outcome;
    bool won;
    public float speed;
	// Use this for initialization
	void Start () {
        outcome = GetComponent<Text>();
        won = GameObject.FindGameObjectWithTag("result").GetComponent<result>().finish;
        if (won)
        {
            outcome.color = new Color(0, 0, 1, 0);
            outcome.text="You Win";
        }
        else
        {
            outcome.color = new Color(1, 0, 0, 0);
            outcome.text = "You Lose"+"\n"+ GameObject.FindGameObjectWithTag("result").GetComponent<result>().percentage;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (won)
        {
            outcome.color = Color.Lerp(outcome.color,new Color(0, 0, 1, 1),speed);
            
        }
        else
        {
            outcome.color = Color.Lerp(outcome.color, new Color(1, 0, 0, 1), speed);
            
        }
    }
}
