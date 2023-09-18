using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFuncs : MonoBehaviour
{
    public static void CalculateTotalPages()
    {
        MainGameScript.totalPages = MainGameScript.textMeshProS.textInfo.pageCount;
    }

    public static void NextPage()
    {
        CalculateTotalPages();
        if (MainGameScript.currentPage <= MainGameScript.totalPages)
        {
            MainGameScript.currentPage = MainGameScript.totalPages;
            MainGameScript.textMeshProS.pageToDisplay = MainGameScript.currentPage;
        }
        else
        {
            MainGameScript.currentPage++;
            MainGameScript.textMeshProS.pageToDisplay = MainGameScript.currentPage;
        }
    }

    public static void PreviousPage()
    {
        CalculateTotalPages();
        switch (MainGameScript.currentPage)
        {
            case <= 1:
                MainGameScript.currentPage = 1;
                MainGameScript.textMeshProS.pageToDisplay = MainGameScript.currentPage;
                break;
            case > 1:
                MainGameScript.currentPage--;
                MainGameScript.textMeshProS.pageToDisplay = MainGameScript.currentPage;
                break;
        }
    }
}
