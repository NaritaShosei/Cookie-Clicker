using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public CookieData CookieData { get; private set; }

    private void Awake()
    {
        CookieData = SaveLoadService.Load<CookieData>();
        ServiceLocator.Set(this);
        if (CookieData == null)
        {
            CookieData = new CookieData();
        }
    }

    public void DataReset()
    {
        var factories = FindObjectsByType<FactoryView>(FindObjectsSortMode.None);

        foreach (var factory in factories)
        {
            factory.ResetFactory();
        }

        CookieData = SaveLoadService.Reset<CookieData>();
    }

    public FactoryData GetFactory(string name)
    {
        if (CookieData == null) { return null; }
        return CookieData.FactoryDatas.Find(f => f.Name == name);
    }

    public void AddFactory(FactoryData data)
    {
        CookieData.FactoryDatas.Add(data);
    }

    public void Save()
    {
        SaveLoadService.Save(CookieData);
    }

    private void OnDisable()
    {
        SaveLoadService.Save(CookieData);
    }
}
