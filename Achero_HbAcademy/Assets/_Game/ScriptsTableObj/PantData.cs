using UnityEngine;
public enum PantType
{   
    pant  =  0,
    pant_1 = 1,
    pant_2 = 2,
    pant_3 = 3,
    pant_4 = 4,
    pant_5 = 5,
    pant_6 = 6,
    pant_7 = 7,
}
[CreateAssetMenu(fileName = "ColorPant", menuName = "ScriptableObjects/ColorPant")]
public class PantData : ScriptableObject
{

    [SerializeField] private Material[] pantColor;
    public PantType pantType;
    public Material GetPantType(PantType pantType)
    {
        return pantColor[(int)pantType];
    }
    public PantType GetRandomItem() 
    {
        int randomValue = Random.Range(0,7);
        PantType randomItemType = (PantType)randomValue;
        return randomItemType;
    }
}