using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class VBSend : MonoBehaviour,IVirtualButtonEventHandler
{
    public GameObject webbtn;
    public MeshRenderer meshRenderer,plane;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started");
        meshRenderer.gameObject.SetActive(false);
        webbtn = GameObject.Find("send");
        webbtn.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

    }

    public void OnButtonPressed(VirtualButtonBehaviour virtualButtonBehaviour)
    {
        Debug.Log("pressed");
        //Destroy(webbtn);
        meshRenderer.material.mainTexture = plane.material.mainTexture;
        meshRenderer.gameObject.SetActive(true);
        //StoreValues.getValue = 1;
        /// Debug.Log(storeValues.getValue);
        //       Destroy(webbtn);

    }
    public void OnButtonReleased(VirtualButtonBehaviour virtualButtonBehaviour)
    {
        Debug.Log("Released");
        //plane.SetActive(false);
    }
}
