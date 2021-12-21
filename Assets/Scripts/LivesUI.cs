using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Image fireBar;    

    private void Update() {
        fireBar.fillAmount = StatusPlayer.amountFire;    
    }
}
