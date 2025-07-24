using UnityEngine;

public class DataManager : MonoBehaviour
{
    public CookieData CookieData {  get; private set; }

    private void Awake()
    {
        CookieData = new CookieData();
        ServiceLocator.Set(this);
    }
}
