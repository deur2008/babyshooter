using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//顯示選單，用來處理要重新開始還是回到主畫面
public class RestartDialogCondition : ShowUIStageCondition
{

    //如果是選擇"是"
    protected override void OnPanelSelect()
    {
        RestartGame();
    }

    //如果選擇"不是"
    protected override void OnPanelCancel()
    {
        BackToMainMenu();
    }

    //重新開始
    void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    //回到主畫面
    void BackToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneIndex.MainMenu);
    }
}
