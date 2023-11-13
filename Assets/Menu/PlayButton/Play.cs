using UnityEngine;

public class Play : MonoBehaviour
{
    public void PlayGameButton()
    {
        MainGameScript.mainMenu.SetActive(false);

        ListOfSections.CountersUpdate();
        ListOfSections.ListsUpdate();

        MainGameScript.sectionsWindow.SetActive(true);
    }
}
