using UnityEngine;
public class CanvasManager : Singleton<CanvasManager>
{
   [SerializeField] private Ui_MainMenu uiMainMenuPrefab;
   [SerializeField] private Ui_TextAlive uiTextAlivePrefab; 
   public FloatingJoystick floatingJoystick;
   public Ui_TextAlive textAlive;
   public Ui_MainMenu uiMainMenu;
   private void Start()
   {
      OnInit();
   }

   private void OnInit()
   {  
      floatingJoystick.gameObject.SetActive(false);
      uiMainMenu = Instantiate(uiMainMenuPrefab, gameObject.transform);
      uiMainMenu.OnInit();
   }

   public void SpawnUiTextAlive()
   {
      textAlive = Instantiate(uiTextAlivePrefab, gameObject.transform);
      textAlive.SetText(LevelManager.Ins.currentLevel.amountTotal);
   }
}
