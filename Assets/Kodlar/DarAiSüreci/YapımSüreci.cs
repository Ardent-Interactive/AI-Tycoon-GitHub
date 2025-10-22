using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class YapımSüreci : MonoBehaviour
{
    private Aşama2 aşama2;

    public int Maliyet;
    public double Süre;

    [System.Serializable]
    public class Özellikler
    {
        public string ÖzellikAdı;
        public int EkleyeceğiGeliştirmePuanı;
        public bool AçıkMı;
    }
    public List<Özellikler> özellikler;

    private void Awake()
    {
        aşama2 = FindFirstObjectByType<Aşama2>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //aşama2.ÖzelliklerProfiliniYapımSürecineKopyala();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
