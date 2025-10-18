using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KontratListesi : MonoBehaviour
{
    public List<Kontrat> kontratList = new List<Kontrat>();

    [System.Serializable]
    public struct KontratVeri
    {
        public string ÝþverenÝsmi;
        public int VerilenGünSüresi;
        public int VerilenPara;
        public int ÝtibarPuaný;
        public int BaþvuruGeçerlilikGünü;
        public bool AlýndýMý;
        public string Açýklama;
        public Kontrat.ÝþTürü iþTürü;
        [Tooltip("Kontratýn bitmesine kalan gün sayýsý.")]
        public int KalanGeçerlilikGünü;
        public Sprite ÞirketLogosu;
    }
    [Tooltip("Önceden ayarlanmýþ þirketler.")]
    public List<KontratVeri> kontratVeri = new List<KontratVeri>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ListeyiTemizle(); // Null olan kontratlarý her frame temizle
    }

    /// <summary>
    /// Destroy edilmiþ kontrat objelerini listeden çýkarýr. Struct havuzu bozulmaz.
    /// </summary>
    public void ListeyiTemizle()
    {
        for (int i = kontratList.Count - 1; i >= 0; i--)
        {
            if (kontratList[i] == null) // GameObject yok edilmiþse
            {
                Debug.Log("Liste temizlendi: Destroy edilmiþ kontrat kaldýrýldý.");
                kontratList.RemoveAt(i);
            }
        }
    }
}
