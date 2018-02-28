using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreeenShake : MonoBehaviour {

    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount;
    public float decreaseFactor;//1

    Vector3 originalPos;

    bool shaking = false;

    public AudioSource hitSound;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (shaking)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;          
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }
    public IEnumerator shake()
    {
        hitSound.Play();
        shaking = true;
        yield return new WaitForSeconds(shakeDuration);
        shaking = false;
    }
}
