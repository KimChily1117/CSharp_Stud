using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : MonoBehaviour
{
    public GameObject parentObject;

    public GameObject prefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefabs, parentObject.transform);
            // 인스턴시에이트 함수를 사용하면 부모 오브젝트의 자식위치에 객체회가 됨 

        }        
    }
}
