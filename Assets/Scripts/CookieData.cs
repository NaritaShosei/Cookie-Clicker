using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CookieData
{
    public int CookieCount;
    public List<FactoryData> FactoryDatas = new();
    public void AddCookie(int cookie)
    {
        CookieCount += cookie;
    }
}
