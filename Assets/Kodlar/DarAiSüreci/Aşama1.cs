using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class Aşama1 : MonoBehaviour
{
    public int MaxVeriSetiBoyutu;
    public int MaxParametreSayısı;
    public int MaxBatchBoyutu;
    public int MaxRastgelelik;

    public int VeriSetiBoyutu;
    public int ParametreSayısı;
    public int BatchBoyutu;
    public int Rastgelelik;


    [System.Serializable]
    public class KaynakInfo
    {
        public string KaynakAdı;
        public enum KaynakTürü
        { 
            Web,
            Pdf
        };
        public KaynakTürü kaynakTürü;
        [Range(0, 100)]
        public int Samimi_Resmi;
        [Range(0, 100)]
        public int Araştırmacı;
        [Range(0, 100)]
        public int Eğitimsel;
        public bool KilidiAçıldıMı;
        public Button AtanmışButon;
        public Text AtanmışYazı;
    }
        [InfoBox("Buraya işverenin vereceği seçili kaynak dahil edilmeyecek.")]
        public KaynakInfo[] SeçilebilecekKaynaklar;

    [Space(10)]
    [InfoBox("Aşamanın tamamlanması için kazanılması gereken araştırma puanı. Zamanı belirler.")]
    public int GerekenToplamAraştırmaPuanı;
    [Foldout("1 Araştırma Puanı İçin")]
    public float VeriSetiBoyutuBaşına;
    [Foldout("1 Araştırma Puanı İçin")]
    public float ParametreSayısıBaşına;
    [Foldout("1 Araştırma Puanı İçin")]
    public float BatchBoyutuArttırmaÇarpanı;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GerekenToplamAraştırmaPuanı = (int)((VeriSetiBoyutu / VeriSetiBoyutuBaşına) + (ParametreSayısı / ParametreSayısıBaşına) * (BatchBoyutu * BatchBoyutuArttırmaÇarpanı));
    }

    public void KaynaklarıAyarla()
    {
        foreach (var kaynak in SeçilebilecekKaynaklar)
        {
            if (kaynak.KilidiAçıldıMı)
            {
                kaynak.AtanmışButon.gameObject.SetActive(true);
                kaynak.AtanmışYazı.text = kaynak.KaynakAdı + " (" + kaynak.kaynakTürü + ")";
            }
            else
            {
                kaynak.AtanmışButon.gameObject.SetActive(false);
            }
        }
    }
}
