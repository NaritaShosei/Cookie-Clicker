using UnityEngine;

public class DataManager : MonoBehaviour
{
    public CookieData CookieData { get; private set; }

    private void Awake()
    {
        CookieData = SaveLoadService.Load<CookieData>();
        ServiceLocator.Set(this);
    }

    public void DataReset()
    {
        CookieData = SaveLoadService.Reset<CookieData>();
    }

    private void OnDisable()
    {
        SaveLoadService.Save(CookieData);
    }
}
