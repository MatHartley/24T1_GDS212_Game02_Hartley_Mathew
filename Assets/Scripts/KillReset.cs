using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillReset : MonoBehaviour
{
    public void ResetKills()
    {
        PlayerPrefs.SetInt("Kills", 0);
    }
}
