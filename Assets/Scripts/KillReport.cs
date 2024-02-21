using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillReport : MonoBehaviour
{
    [Header("Kill Count")]
    private int killCount;

    [Header("UI References")]
    public TextMeshProUGUI killCountText;

    // Start is called before the first frame update
    void Start()
    {
        killCount = PlayerPrefs.GetInt("Kills", 0);

        killCountText.text = killCount.ToString();
    }
}