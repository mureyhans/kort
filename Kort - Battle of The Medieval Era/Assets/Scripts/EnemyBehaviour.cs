using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // List<GameObject> children;
    // Start is called before the first frame update
    void Start()
    {
        var children = new List<GameObject>();
        foreach (Transform child in this.transform) children.Add(child.gameObject);
        children.ForEach(child => child.SetActive(false));
    }

    // Update is called once per frame
    void Update()
    {
        // children.ForEach(child => child.SetActive(false));
    }
}
