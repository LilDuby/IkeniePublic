using System.Collections;
using UnityEngine;

public class LightHint : MonoBehaviour
{
    public Light light;
    public bool isTrigger=false;

    public AudioClip onSound;
    AudioSource audioSource;

    private void Start()
    {
        light = GetComponentInChildren<Light>();
        audioSource = GetComponent<AudioSource>();
    }
    public void OnSound()
    {
        audioSource.PlayOneShot(onSound);
    }
    public void OnTriggerEnter(Collider other)
    {  
        if(!isTrigger)
        {
            isTrigger=true;
            StartCoroutine(LightColorChange());
        }        
    }
    IEnumerator LightColorChange()
    {        
        Color[] color=
        {
            new Color(255, 0, 0),
            new Color(255, 255, 0),
            new Color(0, 240, 255),
            new Color(0, 0, 255), 
            new Color(0, 0, 0) 
        };
        //Debug.Log("light ON");
        light.enabled = true;
        OnSound();

        for (int i = 0;i < 5; i ++)
        {                                    
            if(i!=4)
            {   
                light.color=color[i];
            }
            else
            {
                light.enabled = false;
                light.color=color[i]; 
                //Debug.Log("light OFF");                
            } 
            yield return new WaitForSeconds(2.0f);
        } 
        yield return new WaitForSeconds(3.0f);
        //Debug.Log("isTrigger=false"); 
        isTrigger=false;
    }
}

