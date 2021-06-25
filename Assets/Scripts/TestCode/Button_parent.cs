using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using DataManagement;
using FC;


namespace FC
{
    public class Button_parent : MonoBehaviour
    {
        public delegate void DelegateTest();
        public DelegateTest delegateT;

        public readonly string apikey = "BtdlavOgrqvxKQ0iUsVEGs02r53EQ888";

        public string str = "칠리맛초콜릿";

        public string temp;

        [Header("Prefab_Img_Source")]
        public Image pref_img;
        

        [Space(50)]   
        public GameObject Button_Obj;
       
        private void Start()
        {
           
        }

        //https://img-api.neople.co.kr/df/servers/bakal/characters/a683f1008078d43a3046a8c69ea63b6e?zoom=2
        //캐릭터(이미지) 불러오는 URL

        // https://api.neople.co.kr/df/servers/all/characters?characterName=%ec%b9%a0%eb%a6%ac%eb%a7%9b%ec%b4%88%ec%bd%9c%eb%a6%bf&limit=%3Climit%3E&wordType=%3CwordType%3E&apikey=BtdlavOgrqvxKQ0iUsVEGs02r53EQ888URL 
        // 캐릭터 정보 받아오는 (영어닉네임은 상관없는거 같고 한글닉네임같은경우 URL 인코딩이 필요함)

        // UnityWebRequest클래스(WWW클래스 업그레이드 버전)안에 EsecapeURL 함수 사용하면되는듯 

        //https://tenlie10.tistory.com/124
        //점프(중력가속도)
        //https://202psj.tistory.com/1261
        //Json파싱관련 

        IEnumerator GetDeta()
        {
            string url = "https://api.neople.co.kr/df/servers?apikey=" + apikey;
            
            UnityWebRequest www = UnityWebRequest.Get(url);
      
            yield return www.SendWebRequest();

            if (www.isDone)
            {
                Debug.Log("Complete!!");
                Debug.Log(www.downloadHandler.text);
                temp = www.downloadHandler.text;
            }
            else
            {
                Debug.Log("error!!");
            }
        }       


        public void OnClickInstImage()
        {
            Instantiate(pref_img, Button_Obj.transform); 
            StartCoroutine(GetDeta());
        }


      
    }

}