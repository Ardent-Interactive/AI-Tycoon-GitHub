using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KontratListesi : MonoBehaviour
{
    public List<Kontrat> kontratList = new List<Kontrat>();  
    [Tooltip("Önceden ayarlanmýþ þirketler.")]
    public List<KontratVeri> kontratVeri = new List<KontratVeri>();

    [System.Serializable] 

    public class KontratVeri
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

        [Foldout("Teknik Bilgiler")]
        public TeknikBilgiler teknikBilgiler;
    }
    
    [System.Serializable]
    public class TeknikBilgiler
    {
        [InfoBox("Bu aralýklar müþterilerin kabul edeceði aralýklardýr. Eðer yapýlan iþ bu aralýðýn dýþýndaysa verilen not azalýr. \n  Resmiyet_SamimiyetAralýðý : Müþterinin yapay zekanýn üslubu hakkýndaki beklentileri 0-100 \n Yapay zekanýn kendi verilen bilginin dýþýna çýkarak ne kadar araþtýrmaya yatkýn olacaðý \n Yapay zekanýn ne kadar açýklamaya önem vereceði. Mesela bir iþlemin cevabýný vermek veya adým adým çözümün anlatmak. 0-100")]
        [Header("Müþteri Beklentileri")]
        [MinMaxSlider(0, 100)]  
        [Tooltip("")]
        public Vector2 Resmiyet_SamimiyetAralýðý;
        [MinMaxSlider(0, 100)] 
        public Vector2 Araþtýrmacý;
        [MinMaxSlider(0, 100)]
        public Vector2 Eðitimsel;
        [Tooltip("Kaç paramentre ile memnun kalcaklarý")]
        public int MinParametreSayýsý;
        [Tooltip("Ne kadar büyük veri setiyle memnun kalacaklarý")]
        public int MinVeriSetiBüyüklüðü;
        [MinMaxSlider(0, 100)]
        [Tooltip("Müþteri ne kadar randomness'ý tolera edebilir 0-100")]
        public Vector2 RandomnessAralýðý;
        [Space(10)]
        public bool KilitliKaynakVarMý;
        public string KilitliKaynakAdý;
    }



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
