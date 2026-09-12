using UnityEngine;
using TMPro;

public class EnergyUI : MonoBehaviour
{
    public Player player;
    public TMP_Text battery;

    void Update()
    {
        battery.text = "Energy: " + player.energy;
    }
}