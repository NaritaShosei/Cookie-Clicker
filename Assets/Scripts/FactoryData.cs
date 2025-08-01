using UnityEngine;

[System.Serializable]
public class FactoryData
{
    public string Name = "";
    public int AutoClickCount;
    public int BaseCost;
    public int CookiePerSecond;
    public void AddClicker()
    {
        AutoClickCount++;
        Debug.Log(AutoClickCount);
    }
    public int GetCurrentCost() => Mathf.RoundToInt(BaseCost * Mathf.Pow(1.15f, AutoClickCount));
}
