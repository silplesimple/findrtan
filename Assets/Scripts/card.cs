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
            gameManager.I.firstCard = gameObject;//오브젝트를 첫번째 카드에 넣어라
        }
        else//그게 아니라면
        {
            gameManager.I.secondCard = gameObject;//오브젝트를 두번째 카드에 넣어라
            gameManager.I.isMatched();//그리고 둘을 매치시켜라
        }
    }
    public void destroyCard()//카드를 부시는 함수
    {
        Invoke("destroyCardInvoke", 1.0f);//destroyCardInvoke 함수를 1초 이따가 불러라
    }

    void destroyCardInvoke()//Invoke 시킬 함수
    {
        Destroy(gameObject);//오브젝트를 파괴해라
    }

    public void closeCard()//카드를 다시 닫는 함수
    {
        Invoke("closeCardInvoke", 1.0f);//closeCardInvoke 함수를 1초 이따 불러라
    }

    void closeCardInvoke()//Invoke 시킬 함수
    {
        anim.SetBool("isOpen", false);//애니메이터에 bool isOpen함수를 false시켜 원상태로 되돌린다.
        transform.Find("back").gameObject.SetActive(true);//자식오브젝트에 이름중에 back을 찾아서 setActive를 true로 바꿔 활성화 시킨다.
        transform.Find("front").gameObject.SetActive(false);//자식오브젝트에 이름중에 front을 찾아서 setActive를 false로 바꿔 비활성화 시킨다.
    }
}
