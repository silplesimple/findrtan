using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioSource bgmAudiosource;
    public AudioSource mainsource;
    public AudioClip bgmusic;
    public AudioClip failmusic;
    // Start is called before the first frame update
    public static audioManager I;//어디서든 gameManager에 인스턴스에 쉽게 접근하게 해주기위 한 싱글톤
    void Awake()
    {
        I = this;
    }
    void Start()
    {
        bgmAudiosource.clip = bgmusic;
        bgmAudiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void failSound()
    {
            mainsource.clip = failmusic;
            mainsource.Play();
            Debug.Log("소리 나왔다!");
            Invoke("nullclip", 1f);
        
    }
    public void nullclip()
    {
        mainsource.clip=null;
    }
    
}
