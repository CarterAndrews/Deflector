using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Deflector : MonoBehaviour {
    public float rotationSpeed;
    public float moveSpeed;
    public float top, bottom, left, right;
    public float shakeDuration;
    public float shakeAmount;
    public bool shaking;
    Material originMat;
    Material currentMat;
    float red;
    float blue;
    float alpha;
    public float decayRate;
    float startingZ;
    public int health = 4;
    public GameObject[] hearts;
    // Use this for initialization
    void Start () {
        originMat = GetComponent<Renderer>().material;
        alpha = originMat.color.a;
        shaking = false;
        startingZ = transform.position.z;
    }
	public void Damage()
    {
        health--;
        hearts[health].active = false;
    }
	// Update is called once per frame
	void Update () {
        if (health < 1)
        {
            GameObject.FindGameObjectWithTag("result").GetComponent<result>().finish = false;
            GameObject.FindGameObjectWithTag("result").GetComponent<result>().percentage = GameObject.FindGameObjectWithTag("score").GetComponent<score>().scoreText.text;
            //Destroy(GameObject.FindGameObjectWithTag("music"));
            SceneManager.LoadScene("results");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("left Rotation");
            transform.RotateAround(transform.forward, rotationSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("right Rotation");
            transform.RotateAround(transform.forward, -rotationSpeed);
        }
        if (Input.GetKey(KeyCode.W)&&transform.position.y<top)
        {
            Debug.Log("move up");
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed, transform.position.z);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y >bottom)
        {
            Debug.Log("move down");
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed, transform.position.z);
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x >left)
        {
            Debug.Log("move left");
            transform.position = new Vector3(transform.position.x-moveSpeed, transform.position.y , transform.position.z);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < right)
        {
            Debug.Log("move right");
            transform.position = new Vector3(transform.position.x+moveSpeed, transform.position.y , transform.position.z);
        }
        
        red = GetComponent<Renderer>().material.color.r;
        blue = GetComponent<Renderer>().material.color.b;
        GetComponent<Renderer>().material.color = new Color(Mathf.Clamp(red -0.008f, 0, 1), 0, Mathf.Clamp(blue + 0.008f, 0, 1), alpha);
        if (!shaking)
        {
            transform.position = Vector3.Lerp(transform.position,new Vector3(transform.position.x,transform.position.y,startingZ),decayRate);
        }
    }
    public void Shake()
    {
        red = GetComponent<Renderer>().material.color.r;
        blue = GetComponent<Renderer>().material.color.b;
        GetComponent<Renderer>().material.color = new Color(Mathf.Clamp(red + 0.85f, 0, 1), 0, Mathf.Clamp(blue - 0.85f, 0, 1),alpha);
        if(!shaking)
            StartCoroutine(stagger());
    }
    private IEnumerator stagger()
    {
        shaking = true;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z-shakeAmount);
        yield return new WaitForSeconds(shakeDuration);
        shaking = false;
    }
}
