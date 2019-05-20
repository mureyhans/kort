using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningSystem : MonoBehaviour
{
    public static WarningSystem instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public Text warningText;
    Animator warningAnim;
    // Start is called before the first frame update
    void Start()
    {
        warningAnim = warningText.GetComponent<Animator>();
    }

    public void showMessage(string message)
    {
        warningText.text = message;
        warningAnim.SetTrigger("show");
    }
}
