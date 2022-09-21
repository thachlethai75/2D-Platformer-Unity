using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public static int heath = 3;
    [SerializeField] Image[] Hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emtyHeart;

    private void Awake()
    {
        heath = 3;
    }
    void Update()
    {
        foreach(Image img in Hearts)
        {
            img.sprite = emtyHeart;
        }
        for (int i = 0; i < heath; i++)
        {
            Hearts[i].sprite = fullHeart;
        }
    }
}
