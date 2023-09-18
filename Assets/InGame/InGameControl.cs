using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameControl : MonoBehaviour
{
    public void NextPage()
    {
        GameFuncs.NextPage();
    }
    public void PreviousPage()
    {
        GameFuncs.PreviousPage();
    }
}
