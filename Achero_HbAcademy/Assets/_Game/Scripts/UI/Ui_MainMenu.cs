using UnityEngine;
using UnityEngine.UI;

public class Ui_MainMenu : MonoBehaviour
{
    [SerializeField] private Button btnPlay,btnChangeWeapon;
    public void OnInit()
    {
        btnPlay.onClick.AddListener(OnClickBtnPlay);
    }

    private void OnClickBtnPlay()
    {
        CanvasManager.Ins.floatingJoystick.gameObject.SetActive(true);
        if (CanvasManager.Ins.textAlive == null)
        {
            CanvasManager.Ins.SpawnUiTextAlive();
        }
        else
        {
            CanvasManager.Ins.textAlive.gameObject.SetActive(true);
        }
        gameObject.SetActive(false);
        LevelManager.Ins.currentLevel.OnInit();
    }
}
