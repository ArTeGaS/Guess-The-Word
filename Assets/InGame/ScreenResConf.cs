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

    public int testFonW;
    public int testFonH;
    public float testPosMod;

    private RectTransform txtFonRect;
    private RectTransform txtBoxRect;
    private Vector3 pos;

    private void Start()
    {
        sW = Screen.width;
        sH = Screen.height;
        txtFonRect = txtFon.GetComponent<RectTransform>();
        txtBoxRect = txtBox.GetComponent<RectTransform>();
        pos = txtFon.transform.position;

        if (sH == 1280 && sW == 720 || sH == 1920 && sW == 1080 || sH == 2560 && sW == 1440) // 16:9
        {
            txtFonRect.sizeDelta = new Vector2(400, 600);
            txtBoxRect.sizeDelta = new Vector2(380, 592);
            pos += new Vector3(0, (float)(sH * -0.14), 0);
            txtFon.transform.position = pos;
        }
        else if (sH == 1280 && sW == 800 || sH == 1440 && sW == 900 || sH == 1680 && sW == 1050) // 16:10
        {
            txtFonRect.sizeDelta = new Vector2(testFonW, testFonH);
            txtBoxRect.sizeDelta = new Vector2(380, 592);
            pos += new Vector3(0, (float)(sH * testPosMod), 0);
            txtFon.transform.position = pos;
        }
        else if (sH == 1440 && sW == 720 || sH == 2160 && sW == 1080 || sH == 2880 && sW == 1440) // 18:9
        {
            txtFonRect.sizeDelta = new Vector2(400, 690);
            txtBoxRect.sizeDelta = new Vector2(380, 682);
            pos += new Vector3(0, (float)(sH * - 0.18), 0);
            txtFon.transform.position = pos;
        }
    }
    private void Update()
    {

    }
}
