using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
   [SerializeField] private Text BulletsAvaible;
   [SerializeField] private Image  Healthbar;
   
   public void SetHealtbar(float maxHP, float avaibleHP)
   {
       Healthbar.fillAmount = avaibleHP / maxHP;
   }

   public void SetBulletsAvaible(int bullets)
   {
      BulletsAvaible.text = "Bullets: " + bullets;
   }
   
}
