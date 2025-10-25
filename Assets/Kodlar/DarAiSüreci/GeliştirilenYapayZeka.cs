using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class GeliştirilenYapayZeka : MonoBehaviour
{
    private KontratListesi kontratListesi;
    private AlınanKontrat alınanKontrat;

    [Header("Teknik Bilgiler")]
    public int Resmiyet_Samimiyet;
    public int Araştırmacı;
    public int Eğitimsel;
    [Tooltip("Modelin verilen işi ne kadar iyi  yaptığı. (veri seti boyutu ve batch_size belirler)")]
    public int EğitimKalitesi;
    [Tooltip("Model ne kadar sıklıkla yanlış bilgi veriyor. (batch-size)")]
    public int HalüsilasyonOranı;
    [Tooltip("Modelin ne kadar değişken cevap verdiği. (paramentre sayısı ve randomness belirler)")]
    public int Dinamiklik;

    private void Awake()
    {
        kontratListesi = FindFirstObjectByType<KontratListesi>();
        alınanKontrat = FindFirstObjectByType<AlınanKontrat>();
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
    }

}
