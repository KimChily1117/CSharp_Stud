using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FC;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance {
        get 
        {
            Init();
            return s_instance;        
        }
    }    
    
    private InputManager _input = new InputManager(); // InputManager를 객체화시킨다.
    
    public static InputManager Input { get { return Instance._input; }  }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        
    }
    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (!go)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();               
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }
    }   
}
