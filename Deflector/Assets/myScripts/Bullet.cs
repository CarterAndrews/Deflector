using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour {
    public float bulletSpeed;
    public float horizontalSpread, verticleSpread,horizontalRange,verticleRange;    
    public LineRenderer line;
    RaycastHit hit;
    public Material greenMat;
    public Material redMat;
    public GameObject ghost;
    public float ghostDistance;
    public GameObject ghostInst;
    public Material ghostInstMat;
    GameObject deflector;
    float initDeflectorDistance;
    float currDeflectorDistance;
    bool blocked=false;
    public AudioSource deflectSound;
    public GameObject sparks;
    public ScreeenShake screenShake;
    private float swag = 1;
    GameObject Screen;
    
    // Use this for initialization
    void Start () {
        transform.position= new Vector3(transform.position.x + Random.RandomRange(-horizontalRange, horizontalRange), transform.position.y + Random.RandomRange(-verticleRange, verticleRange), transform.position.z);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + Random.RandomRange(-verticleSpread,verticleSpread), transform.localEulerAngles.y + Random.RandomRange(-horizontalSpread,horizontalSpread), transform.localEulerAngles.z);
        GetComponent<Rigidbody>().velocity = transform.up * bulletSpeed;
        line = GetComponent<LineRenderer>();
        ghostInst=Instantiate(ghost, transform.position + transform.up * get_ghost_distance(), transform.rotation);
        deflector = GameObject.FindGameObjectWithTag("deflector");
        initDeflectorDistance = Vector3.Distance(transform.position, deflector.transform.position);
        //GameObject.FindGameObjectWithTag("score").GetComponent<score>().total++;
        screenShake = Camera.main.GetComponent<ScreeenShake>();
        Screen = GameObject.FindGameObjectWithTag("Screen");
    }
	public float get_ghost_distance()
    {
        if (Physics.Linecast(transform.position, transform.position + transform.up * 100,out hit))
        {
            if(hit.collider.CompareTag("Screen"))
            return Vector3.Distance(hit.point, transform.position);
            else
                return Vector3.Distance(hit.point, transform.position)+1;

        }

            return -1;
    }
	// Update is called once per frame
	void Update () {
        currDeflectorDistance = Vector3.Distance(transform.position, deflector.transform.position);
        float a = Mathf.Clamp(1-currDeflectorDistance/initDeflectorDistance,0,1);
        Debug.Log("");
        if (blocked)
        {
            if (ghostInst != null)
                ghostInst.GetComponent<Renderer>().material.color = new Color(0, 1, 0,a);
            GetComponent<Renderer>().material.color = new Color(0, 1, 0);
            GetComponentInChildren<ParticleSystem>().startColor = new Color(0, 1, 0);
        }
        else
        {
            if(ghostInst!=null)
            ghostInst.GetComponent<Renderer>().material.color = new Color(1, 0,0 , a);
            GetComponent<Renderer>().material.color = new Color(1,0, 0);
            GetComponentInChildren<ParticleSystem>().startColor = new Color(1, 0, 0);
        }
        if (Physics.Raycast(transform.position,transform.up,out hit,50))
        {
            if (hit.collider.CompareTag("deflector"))
            {
                line.material = greenMat;
                blocked = true;
                //Debug.Log("hit");
            }
            else
            {
                line.material = redMat;
                
                blocked = false;
            }
        }
        else
        {
            line.material = redMat;
        }
        line.SetPosition(0, transform.position);
        line.SetPosition(1,transform.position + transform.up * 50);
	}
    private void OnCollisionEnter(Collision collision)
    {
        line.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "deflector")
        {
            Debug.Log("Deflect");          
            GetComponent<Rigidbody>().velocity = Vector3.Reflect(GetComponent<Rigidbody>().velocity,other.transform.forward);
            transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + 90, transform.localEulerAngles.y, transform.localEulerAngles.z);
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            line.enabled = false;
            Destroy(ghostInst);
            StartCoroutine(die());
            GetComponent<TrailRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("score").GetComponent<score>().blocked++;
            GameObject.FindGameObjectWithTag("score").GetComponent<score>().streak++;
            deflectSound.Play();
            Instantiate(sparks, transform.position, Quaternion.Euler(-90,0,0));
            deflector.GetComponent<Deflector>().Shake();
            screenShake.StartCoroutine("shake");
            
            //deflector.GetComponentInChildren<Animator>().Play("shake");
        }
        if (other.tag == "Health")
        {
            GameObject.FindGameObjectWithTag("score").GetComponent<score>().streak = 0;
            screenShake.StartCoroutine("shake");
            Screen.GetComponent<Renderer>().material.color=new Color(1, 0, 0, 0.3f);
            Destroy(ghostInst);
            Destroy(gameObject);
            deflector.GetComponent<Deflector>().Damage();
        }
    }
    private IEnumerator die()
    {
        yield return new WaitForSeconds(5);
        Destroy(ghostInst);
        Destroy(gameObject);
    }
}
