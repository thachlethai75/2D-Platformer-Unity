using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] Transform mainCam;
    [SerializeField] Transform midBG;
    [SerializeField] Transform sideBG;
    [SerializeField] float Length = 38f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mainCam.position.x > midBG.position.x)
            sideBG.position = midBG.position + Vector3.right * Length;

        if (mainCam.position.x < midBG.position.x)
            sideBG.position = midBG.position + Vector3.left * Length;
        if(mainCam.position.x > sideBG.position.x || mainCam.position.x < sideBG.position.x)
        {
            Transform z = midBG;
            midBG = sideBG;
            sideBG = z;
        }
    }
}
