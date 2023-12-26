using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour //card클래스에 스크립트를 카드 오브젝트(gameobject)에 넣어 카드 오브젝트에 값도 스크립트 에서 사용 할 수 있음
{
    public Animator anim; //public 으로 선언하여 animator를 넣게 해주는 변수anim를 선언
    public AudioClip flip; //public 으로 선언하여 audioClip을 넣게 해주는 변수 flip을 선언
    public AudioSource audioSouce; //public 으로 선언하여 AudioSource를 넣게 해주는 변수 audioSouce를 선언
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openCard()//함수 opencard를 선언하여 오픈했을때에 상황에 대해 가독성 좋게 open 카드라고 선언한 것이다.
    {//카드가 오픈됐을때
        audioSouce.PlayOneShot(flip);//audioSouce를 한번만 재생해라
        anim.SetBool("isOpen", true);//애니메이터에 변수 bool isOpen에 값을 true로 바꿔라
        transform.Find("front").gameObject.SetActive(true);//자식오브젝트중front라는 이름에 게임오브젝트를 찾아서 setactive를 true로 변환해라
        transform.Find("back").gameObject.SetActive(false);//자식오브젝트중bakc라는 이름에 게임오브젝트를 찾아서 setactive 를 false로 변환해라
        
        if(gameManager.I.firstCard==null)//만약 첫번째 카드가 비어있다면
        {
            gameManager.I.firstCard = gameObject;//첫번째 카드를 넣어라
        }
        else
        {
            gameManager.I.secondCard = gameObject;
            gameManager.I.isMatched();
        }
    }
    public void destroyCard()
    {
        Invoke("destroyCardInvoke", 1.0f);
    }

    void destroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void closeCard()
    {
        Invoke("closeCardInvoke", 1.0f);
    }

    void closeCardInvoke()
    {
        anim.SetBool("isOpen", false);
        transform.Find("back").gameObject.SetActive(true);
        transform.Find("front").gameObject.SetActive(false);
    }
}
