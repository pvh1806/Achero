using UnityEngine;
public enum HatType
{   
    arow  = 0,
    cap = 1,
    cowboy = 2,
    crown = 3,
    earn = 4,
    horn = 5,
    police_cap = 6,
    strea_hat = 7,
}
[CreateAssetMenu(fileName = "ColorHat", menuName = "ScriptableObjects/ColorHat")]
public class HatData : ScriptableObject
{

    [SerializeField] private Hat[] hatObj;
    public HatType hatType;
    public Hat GetHatType(HatType hatType)
    {
        return hatObj[(int)hatType];
    }
    public HatType GetRandomItem() 
    {
        int randomValue = Random.Range(0,7);
        HatType randomItemType = (HatType)randomValue;
        return randomItemType;
    }

}