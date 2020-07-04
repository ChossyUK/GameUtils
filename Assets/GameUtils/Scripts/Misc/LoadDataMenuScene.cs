using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDataMenuScene : MonoBehaviour
{
    public DataManager dataManager;

    public void LoadData()
    {
        dataManager.LoadOptionsData();
    }
}
