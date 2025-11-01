using NaughtyAttributes;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GeliştirilenYapayZeka : MonoBehaviour
{
    private KontratListesi kontratListesi;
    private AlınanKontrat alınanKontrat;
    private Aşama1 aşama1;

    [Header("Teknik Bilgiler")]
    public int Resmiyet_Samimiyet;
    public int Araştırmacı;
    public int Eğitimsel;
    [Tooltip("Modelin verilen işi ne kadar iyi  yaptığı. (veri seti boyutu ve batch_size belirler)")]
    public float EğitimKalitesi;
    public int OptimalBatchSize;
    [Tooltip("Optimal batch size, Verisetiboyutu / Bölen ile belirlenir.")]
    public int Bölen;
    [Tooltip("Model ne kadar sıklıkla yanlış bilgi veriyor. (batch-size)")]
    public int HalüsilasyonOranı;
    [Tooltip("Modelin ne kadar değişken cevap verdiği. (paramentre sayısı ve randomness belirler)")]
    public int Dinamiklik;

    private void Awake()
    {
        kontratListesi = FindFirstObjectByType<KontratListesi>();
        alınanKontrat = FindFirstObjectByType<AlınanKontrat>();
        aşama1 = FindFirstObjectByType<Aşama1>(FindObjectsInactive.Include);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!string.IsNullOrEmpty(alınanKontrat.İşverenİsmi))
        {
            foreach (var eşleşenKontrat in kontratListesi.kontratVeri)
            {
                if(eşleşenKontrat.İşverenİsmi == alınanKontrat.İşverenİsmi)
                {
                    Resmiyet_Samimiyet = (int)(eşleşenKontrat.teknikBilgiler.Resmiyet_SamimiyetAralığı.x + eşleşenKontrat.teknikBilgiler.Resmiyet_SamimiyetAralığı.y) / 2;
                    //print(eşleşenKontrat.teknikBilgiler.MinEğitimKalitesi);
                    //print(eşleşenKontrat.teknikBilgiler.MaxHalüsilasyonOranı);
                    //print(eşleşenKontrat.teknikBilgiler.Resmiyet_SamimiyetAralığı.x);
                    //print(eşleşenKontrat.teknikBilgiler.Resmiyet_SamimiyetAralığı.y);
                }
            }
        }
        OptimalBatchSize = aşama1.VeriSetiBoyutu / Bölen;
        EğitimKalitesiniHesapla();
    }

    public void UslübuHesapla()
    {
        #region Eski kod
        //GeliştirilenYapayZeka.Resmiyet_Samimiyet = 0;
        //foreach (var kaynak in aşama1.SeçilenKaynaklar)
        //{
        //    GeliştirilenYapayZeka.Resmiyet_Samimiyet += kaynak.Samimi_Resmi;
        //}
        //if(aşama1.SeçilenKaynaklar.Count != 0)
        //{
        //    GeliştirilenYapayZeka.Resmiyet_Samimiyet /= aşama1.SeçilenKaynaklar.Count;
        //}
        #endregion
        //Kısaca ortalama alıyoruz.
        Resmiyet_Samimiyet = aşama1.SeçilenKaynaklar.Any() ? (int)aşama1.SeçilenKaynaklar.Average(k => k.Samimi_Resmi) : 0;
    }

    public void AraştırmacılığıHesapla()
    {
        #region Eski kod
        //GeliştirilenYapayZeka.Araştırmacı = 0;
        //foreach (var kaynak in aşama1.SeçilenKaynaklar)
        //{
        //    GeliştirilenYapayZeka.Araştırmacı += kaynak.Araştırmacı;
        //}
        //if (aşama1.SeçilenKaynaklar.Count != 0)
        //{
        //    GeliştirilenYapayZeka.Araştırmacı /= aşama1.SeçilenKaynaklar.Count;
        //}
        #endregion
        Araştırmacı = aşama1.SeçilenKaynaklar.Any() ? (int)aşama1.SeçilenKaynaklar.Average(k => k.Araştırmacı) : 0;
    }

    public void EğitimselliğiHesapla()
    {
        #region Eski kod
        //foreach (var kaynak in aşama1.SeçilenKaynaklar)
        //{
        //    GeliştirilenYapayZeka.Eğitimsel += kaynak.Eğitimsel;
        //}
        //if (aşama1.SeçilenKaynaklar.Count != 0)
        //{
        //    GeliştirilenYapayZeka.Eğitimsel /= aşama1.SeçilenKaynaklar.Count;
        //}
        #endregion
        Eğitimsel = aşama1.SeçilenKaynaklar.Any() ? (int)aşama1.SeçilenKaynaklar.Average(k => k.Eğitimsel) : 0;
    }

    public void EğitimKalitesiniHesapla()
    {
        if(Mathf.Abs(aşama1.BatchBoyutu - OptimalBatchSize) != 0)
        {
            EğitimKalitesi = ((1f / Mathf.Abs(aşama1.BatchBoyutu - OptimalBatchSize)))/* * aşama1.VeriSetiBoyutu*/;
            print(EğitimKalitesi);
        }
        else
        {
            EğitimKalitesi = (1);
        }
    }
}
