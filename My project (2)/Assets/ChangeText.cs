using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public Transform target;
    public Text newTextX;
    public Text newTextY;
    public Text newTextZ;



    void LateUpdate()
    {
        newTextX.text = "Oś X: " + target.rotation.eulerAngles.x.ToString();
        newTextY.text = "Oś Y: " + target.rotation.eulerAngles.y.ToString();
        newTextZ.text = "Oś Z: " + target.rotation.eulerAngles.z.ToString();
        
    }

}
