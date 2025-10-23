using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class YapımSüreci : MonoBehaviour
{
    [SerializeField]
    private Aşama1 aşama1;
    [SerializeField]
    private Aşama2 aşama2;
    [SerializeField]
    private Aşama3 aşama3;
    [SerializeField]
    private ToplamÇalışanGücü ToplamÇalışanGücü;
    [SerializeField]
    private YapımSüreciUI YapımSüreciui;

    public int Maliyet;
    public double Süre;

    [System.Serializable]
    public class Özellikler
    {
        public string ÖzellikAdı;
        [Tooltip("Özellik eklendiği takdirde ek olarak kaç tane daha geliştirme puanı gerekeceğini belirler.")]
        public int EkleyeceğiGeliştirmePuanı;
        [Tooltip("Özellik eklenmiş mi.")]
        public bool AçıkMı;
    }
    public List<Özellikler> özellikler;

    private void Awake()
    {
        aşama1 = FindFirstObjectByType<Aşama1>(FindObjectsInactive.Include);
        aşama2 = FindFirstObjectByType<Aşama2>(FindObjectsInactive.Include);
        aşama3 = FindFirstObjectByType<Aşama3>(FindObjectsInactive.Include);
        ToplamÇalışanGücü = FindFirstObjectByType<ToplamÇalışanGücü>(FindObjectsInactive.Include);
        YapımSüreciui = FindFirstObjectByType<YapımSüreciUI>(FindObjectsInactive.Include);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //aşama2.ÖzelliklerProfiliniYapımSürecineKopyala();
    }

    // Update is called once per frame
    void Update()
    {
        Süre = (aşama1.GerekenToplamAraştırmaPuanı / ToplamÇalışanGücü.ToplamAraştırmaGücü) + (aşama2.GerekenToplamKodlamaPuanı / ToplamÇalışanGücü.ToplamKodlamaGücü) + (aşama3.GerekenToplamTasarımPuanı / ToplamÇalışanGücü.ToplamTasarımGücü);

        #region Maliyet Hesabı
        Maliyet = 0;
            foreach (var araştırmacı in ToplamÇalışanGücü.araştırmacılar)
            {
                Maliyet += araştırmacı.MaaşBeklentisi;
            }
            foreach (var kodlamacı in ToplamÇalışanGücü.kodlamacılar)
            {
                Maliyet += kodlamacı.MaaşBeklentisi;
            }
            foreach (var tasarımcı in ToplamÇalışanGücü.tasarımcılar)
            {
                Maliyet += tasarımcı.MaaşBeklentisi;
            }
        #endregion

        #region Panel Açılınca Zamanı durdurup kapanınca devam ettirmek için
        if (YapımSüreciui.MaliyetveZamanText.activeInHierarchy)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        #endregion
    }
}
