using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] Level[] levels;
    public Level currentLevel;
    private int levelIndex;
    public PlayerController playerController;
    public void Start()
    {
        levelIndex = 0;
        OnLoadLevel(levelIndex);
    }
    public void OnLoadLevel(int level)
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }
        currentLevel = Instantiate(levels[level],gameObject.transform);
    }
    // private void Victory()
    // {
    //     UIManager.Ins.CloseAll();
    //     UIManager.Ins.OpenUI<UIVictory>().SetCoin(player.Coin);
    //     player.ChangeAnim(Constant.ANIM_WIN);
    // }
    //
    //public void Fail()
    //{
        //UIManager.Ins.CloseAll();
        //UIManager.Ins.OpenUI<UIFail>().SetCoin(player.Coin); 
    //}
    
    // public void Home()
    // {
    //     UIManager.Ins.CloseAll();
    //     OnReset();
    //     OnLoadLevel(levelIndex);
    //     OnInit();
    //     UIManager.Ins.OpenUI<UIMainMenu>();
    // }

    public int NextLevel()
    {
        levelIndex++;
        return levelIndex;
    }
}
