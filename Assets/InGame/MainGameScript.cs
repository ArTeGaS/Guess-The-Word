using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainGameScript : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // ��������� �� ��'��� TextMeshPro, �� �� ���������� �����.
    public static int currentPage = 1; // ������� ������� ������.

    public static TextMeshProUGUI textMeshProS;
    public static int totalPages;

    private void Start()
    {
        textMeshProS = textMeshPro;
    }

    public static void CalculateTotalPages()
    {
        totalPages = textMeshProS.textInfo.pageCount;
    }

    public static void NextPage()
    {
        CalculateTotalPages();
        if (currentPage <= totalPages)
        {
            currentPage = totalPages;
            textMeshProS.pageToDisplay = currentPage;
        }
        else
        {
            currentPage++;
            textMeshProS.pageToDisplay = currentPage;
        }
    }

    public static void PreviousPage()
    {
        CalculateTotalPages();
        switch (currentPage){
            case <= 1:
                currentPage = 1;
                textMeshProS.pageToDisplay = currentPage;
                break;
            case > 1:
                currentPage--;
                textMeshProS.pageToDisplay = currentPage;
                break;
        }
    }
}
