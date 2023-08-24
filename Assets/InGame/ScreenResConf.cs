using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenResConf : MonoBehaviour
{
    private int sW;
    private int sH;
    public GameObject txtFon;
    public TextMeshProUGUI txtBox;
    private void Start()
    {
        sW = Screen.width;
        sH = Screen.height;
        RectTransform txtFonRect = txtFon.GetComponent<RectTransform>();
        RectTransform txtBoxRect = txtBox.GetComponent<RectTransform>();
        Vector3 pos = txtFon.transform.position;

        if ( sH == 1280 && sW == 720 || sH == 1920 && sW == 1080 || sH == 2560 && sW == 1440) // 16:9
        {
            txtFonRect.sizeDelta = new Vector2(400, 500);
            txtBoxRect.sizeDelta = new Vector2(380, 492);
            pos += new Vector3(0, sH * -0.07f, 0);
            txtFon.transform.position = pos;
        }
        else if ( sH == 1280 && sW == 800 || sH == 1440 && sW == 900 || sH == 1680 && sW == 1050) // 16:10
        {
             
        }
        else if ( sH == 1440 && sW == 720 || sH == 2160 && sW == 1080 || sH == 2880 && sW == 1440) // 18:9
        {

        }
    }
}
