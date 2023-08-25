using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenResConf : MonoBehaviour
{
    private int sW;
    private int sH;
    private float gameAspectRatio;
    public GameObject txtFon;
    public TextMeshProUGUI txtBox;

    public int testFonH;
    public float testPosMod;

    private RectTransform txtFonRect;
    private RectTransform txtBoxRect;
    private Vector3 pos;

    private void TextBoxCorrect(int txtFonRectH, float posModifier)
    {
        txtFonRect.sizeDelta = new Vector2(400, txtFonRectH);
        txtBoxRect.sizeDelta = new Vector2(380, txtFonRectH - 8);
        pos += new Vector3(0, sH * posModifier, 0);
        txtFon.transform.position = pos;
    }
    private void Start()
    {
        sW = Screen.width;
        sH = Screen.height;
        gameAspectRatio = (float)sH / sW;

        txtFonRect = txtFon.GetComponent<RectTransform>();
        txtBoxRect = txtBox.GetComponent<RectTransform>();
        pos = txtFon.transform.position;

        switch (gameAspectRatio)
        {
            case 1280f / 720f: //16:9
                TextBoxCorrect(600, -0.14f);
                break;
            case 1280f / 800f: //16:10
                TextBoxCorrect(527, -0.1f);
                break;
            case 1440f / 720f: // 18:9
                TextBoxCorrect(690, -0.18f);
                break;
            case 1600f / 720f: //20:9
                TextBoxCorrect(776, -0.2125f);
                break;
            case 1440f / 960f: //3:2
                TextBoxCorrect(490, -0.073f);
                break;
            case 800f / 600f: //4:3
                TextBoxCorrect(424, -0.02f);
                break;
        }
    }
    private void Update()
    {

    }
}
