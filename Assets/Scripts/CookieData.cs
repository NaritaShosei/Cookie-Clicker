using System;
using UnityEngine;

[Serializable]
public class CookieData
{
    public int CookieCount;

    public void AddCookie(int cookie)
    {
        CookieCount += cookie;
    }
}
