using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameControl : MonoBehaviour
{
    public void NextPage()
    {
        MainGameScript.NextPage();
    }
    public void PreviousPage()
    {
        MainGameScript.PreviousPage();
    }
}
