using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNoStop : MonoBehaviour
{
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("bgMusic");
        if(objs.Length >1 ){
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
