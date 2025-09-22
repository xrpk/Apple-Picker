using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;
   
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            // get a referece to the applePickercomponetn of main camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            // Call the public Applemissed() method of apScript
            apScript.AppleMissed();
        }
    }
}
