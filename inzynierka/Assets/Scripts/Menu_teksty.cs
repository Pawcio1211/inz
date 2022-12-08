using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_teksty : MonoBehaviour
{
    // Start is called before the first frame update
    public void Badania_tekst()
    {
        GameObject text = new GameObject();
        TextMesh t = text.AddComponent<TextMesh>();
        t.text = "Badania";
        t.fontSize = 30;

        t.transform.localEulerAngles += new Vector3(90, 0, 0);
        t.transform.localPosition += new Vector3(56f, 3f, 40f);
    }
}
