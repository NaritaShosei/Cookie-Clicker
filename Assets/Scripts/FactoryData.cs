using UnityEngine;

[System.Serializable]
public class FactoryData
{
    public string Name = "";
    public int AutoClickCount;

    public void AddClicker()
    {
        AutoClickCount++;
    }
}
