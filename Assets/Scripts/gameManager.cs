using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


public class gameManager : MonoBehaviour
{
    public Text timeText;
    public Text matchText;
    public Text failText;
    public GameObject endText;
    public GameObject card;
    float time;
    
    public GameObject firstCard;
    public GameObject secondCard;
    public AudioClip match;
    public AudioSource audioSource;

    

    public static gameManager I;//어디서든 gameManager에 인스턴스에 쉽게 접근하게 해주기위 한 싱글톤
    void Awake()
    {
        I = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        


        int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };//카드를 매칭시키기 위해 배열을 통해 안에 있는 값들을 2개 씩 매칭시키게 한다.
        rtans = rtans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray(); //rtan 변수에 값들을 무작위로 정렬 
        Time.timeScale = 1f;//시간을 초기화
        for (int i = 0; i < 16; i++)  
        {
            GameObject newCard= Instantiate(card);
            newCard.transform.parent = GameObject.Find("cards").transform;

            float x = i % 4 * 1.4f-2.1f;
            float y = (i / 4) * 1.4f-3.0f;
            newCard.transform.position = new Vector3(x,y,0);

            string rtanName = "rtan" + rtans[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
        }
    }
        
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeText.text=time.ToString();
        if(time>=30f)
        {
            endText.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void isMatched()
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage=secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        
        if(firstCardImage == secondCardImage)
        {
            audioSource.PlayOneShot(match);
            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();
            matchname();


            int cardsLeft = GameObject.Find("cards").transform.childCount;
            if(cardsLeft==2)
            {
                
                Time.timeScale = 0f;
                endText.SetActive(true);
                
            }
        }
        else
        {
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
            FailText();
            audioManager.I.failSound();


        }

        firstCard = null;
        secondCard = null;
       
    }
   
   
    public void FailText()
    {
        failText.transform.gameObject.SetActive(true);
        failText.text = "실패";
        Invoke("InvokeFaileText", 2f);
        matchText.transform.gameObject.SetActive(false);
    }

    public void InvokeFaileText()
    {
        failText.transform.gameObject.SetActive(false);
    }
    public void matchname()
    {
        string[] teamNames = new string[] {"심선규","이영선","박민수","이서현","염고운"};
        matchText.transform.gameObject.SetActive(true);
        matchText.text = teamNames[Random.Range(0,4)];
        Invoke("Invokematchname",2.0f);
        failText.transform.gameObject.SetActive(false);
    }
    public void Invokematchname()
    {
        matchText.transform.gameObject.SetActive(false);

    }
    
    public void retryGame()
    {
        SceneManager.LoadScene("MainScene");
    }


}
