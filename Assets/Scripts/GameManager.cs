using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int TotalItemCount;
    public int Stage;
    public Text stageCountText;
    public Text playerCountText;

    void Awake()
    {

        stageCountText.text = "/ " + TotalItemCount;

    }

    public void GetItem(int count)
    {

        playerCountText.text = "" + count;

    }

}
