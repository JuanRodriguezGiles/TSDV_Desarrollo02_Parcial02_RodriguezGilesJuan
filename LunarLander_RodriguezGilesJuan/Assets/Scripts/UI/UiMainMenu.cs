using UnityEngine;
public class UiMainMenu : MonoBehaviour
{
    public void LoadGamePlayScene()
    {
        GameManager.Get().LoadGameplayScene();
    }
    public void ExitGame()
    {
        GameManager.Get().ExitGame();
    }
}