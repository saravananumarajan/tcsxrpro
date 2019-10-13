using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VBMusic : MonoBehaviour,IVirtualButtonEventHandler
{
    public GameObject webbtn;
    public MeshRenderer meshRenderer;
    public Sprite sprite;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started");
        meshRenderer.gameObject.SetActive(false);
        webbtn = GameObject.Find("Music");
        webbtn.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

    }

    public void OnButtonPressed(VirtualButtonBehaviour virtualButtonBehaviour)
    {
        Debug.Log("pressed");
        //Destroy(webbtn);
        meshRenderer.material.mainTexture = sprite.texture;
        meshRenderer.gameObject.SetActive(true);
        //StoreValues.getValue = 1;
        /// Debug.Log(storeValues.getValue);
        //        Destroy(webbtn);

    }
    public void OnButtonReleased(VirtualButtonBehaviour virtualButtonBehaviour)
    {
        Debug.Log("Released");
        //plane.SetActive(false);
    }

}
