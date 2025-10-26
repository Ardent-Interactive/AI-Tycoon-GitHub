using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class Aşama2 : MonoBehaviour
{
    private Aşama2UI aşama2UI;
    private YapımSüreci yapımSüreci;

    [Tooltip("Kaç token hafızanın bir kodlama puanına denk olduğunu ölçer.")]
    public int Bölüm;

    [System.Serializable]
    public class Özellikler
    {
        public string ÖzellikAdı;
        public int EkleyeceğiGeliştirmePuanı;
        public int EkleyeceğiMaliyet;
        public bool AçıkMı;
    }
    public Özellikler[] özellikler;

    [InfoBox("Aşamanın tamamlanması için kazanılması gereken geliştirme puanı. Zamanı belirler.")]
    public int GerekenToplamKodlamaPuanı;

    private void Awake()
    {
        aşama2UI = FindFirstObjectByType<Aşama2UI>();
        yapımSüreci = FindFirstObjectByType<YapımSüreci>();
        print(yapımSüreci);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ÖzelliklerProfiliniYapımSürecineKopyala();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AraştırmaPuanınıHesapla()
    {
        GerekenToplamKodlamaPuanı = 0;
        for (int i = 0; i < özellikler.Length; i++) 
        {
            if (özellikler[i].AçıkMı)
            {
                GerekenToplamKodlamaPuanı += özellikler[i].EkleyeceğiGeliştirmePuanı;
                
            }
        }
        if (aşama2UI.HafızaSliderGroup.activeInHierarchy)
        {
            GerekenToplamKodlamaPuanı += (int)aşama2UI.HafızaSliderGroup.transform.GetChild(1).gameObject.GetComponent<Slider>().value / Bölüm;
            aşama2UI.HafızaText.text = (int)aşama2UI.HafızaSliderGroup.transform.GetChild(1).gameObject.GetComponent<Slider>().value + "";
        }
    }

    public void ÖzelliğiAçKapa(int index)
    {
        özellikler[index].AçıkMı = !özellikler[index].AçıkMı;
        ÖzelliklerProfiliniYapımSürecineKopyala();
    }

    public void ÖzelliklerProfiliniYapımSürecineKopyala()
    {
        // Listeyi temizle ki eski elemanlar karışmasın
        yapımSüreci.özellikler.Clear();

        for (int i = 0; i < özellikler.Length; i++)
        {
            // Yeni YapımSüreci.Özellikler nesnesi oluştur
            var yeniÖzellik = new YapımSüreci.Özellikler();
            yeniÖzellik.ÖzellikAdı = özellikler[i].ÖzellikAdı;
            yeniÖzellik.AçıkMı = özellikler[i].AçıkMı;

            // Listeye ekle
            yapımSüreci.özellikler.Add(yeniÖzellik);
        }
    }
}
