using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retrivevalues : MonoBehaviour
{
    public GameObject gameObject;
    
    // Update is called once per frame
    private void Start()
    {
        gameObject = GameObject.Find("googlelaptop");
        gameObject.SetActive(false);
    }
    void Update()
    {
        StoreValues storeValues = new StoreValues();
        if (StoreValues.getValue != 0)
        {
            if (StoreValues.getValue != 1)
            {
                gameObject.SetActive(true);
            }
            }
    }
}
