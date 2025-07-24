using System;
using UnityEngine;

[Serializable]
public class CookieData
{
    public int CookieCount { get; private set; }

    public void AddCookie(int cookie)
    {
        CookieCount += cookie;
    }
}
