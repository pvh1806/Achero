using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ui_TextAlive : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI textAlive;

   public void SetText(int alive)
   {
      textAlive.SetText(alive.ToString());
   }
}
