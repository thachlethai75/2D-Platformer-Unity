using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTip : MonoBehaviour
{
    [SerializeField] GameObject tip;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Tutorial());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Tutorial()
    {
        tip.SetActive(true);
        yield return new WaitForSeconds(5);
        tip.SetActive(false);
    }
}
