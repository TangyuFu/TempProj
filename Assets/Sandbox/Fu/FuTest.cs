using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuTest : MonoBehaviour
{
    private ResourceRequest _request1;
    private ResourceRequest _request2;
    // Start is called before the first frame update
    void Start()
    {
        _request1 = Resources.LoadAsync<GameObject>("SplashForm");
        _request2 = Resources.LoadAsync<GameObject>("SplashForm1");
    }

    // Update is called once per frame
    void Update()
    {
        while (!_request1.isDone)
        {
            Debug.Log(_request1.progress);
        }
        Debug.Log(_request1.asset);
        
        
        // while (!_request2.isDone)
        // {
        //     
        // }
        // Debug.Log(_request2.asset);
    }
}
