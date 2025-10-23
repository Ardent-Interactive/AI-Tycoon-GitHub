using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class KontratYarat : MonoBehaviour
{
    private Şirket şirket;
    private KontratListesi kontratListesi; // isim daha net oldu

    [Tooltip("Değişken belirtilen saniye sıklığında iş üretir.")]
    public float İşYaratmaSıklığı;

    [HideInInspector]
    public float İlkSıklık;

    private void Awake()
    {
        şirket = FindFirstObjectByType<Şirket>();
        kontratListesi = FindFirstObjectByType<KontratListesi>();

        if (kontratListesi == null)
            Debug.LogError("KontratListesi sahnede bulunamadı!");

        İlkSıklık = İşYaratmaSıklığı;
    }

    private void Start()
    {
        StartCoroutine(İşYaratmaDöngüsü());
    }

    private void Update()
    {
        if (şirket != null)
            İşYaratmaSıklığı = İlkSıklık - (şirket.İtibarPuanı / 100f);
    }

    public Kontrat İşiYarat(string işverenİsmi, int verilenGünSüresi,int KalanGünSüresi, int maaş, int itibarPuanı, int başvuruGeçerlilikGünü, bool alındıMı, string açıklama, Kontrat.İşTürü işTürü, float KalanGeçerlilikGünü, Sprite Şirketlogosu, Image Logoimage)
    {
        var i = Random.Range(0, kontratListesi.kontratVeri.Count);
        Kontrat yeniİş = new Kontrat
        {
            İşverenİsmi = işverenİsmi,
            VerilenGünSüresi = verilenGünSüresi,
            KalanGünSüresi = verilenGünSüresi,
            VerilecekPara = maaş,
            İtibarPuanı = itibarPuanı,
            BaşvuruGeçerlilikGünü = başvuruGeçerlilikGünü,
            AlındıMı = alındıMı,
            Açıklama = açıklama,
            ŞirketLogosu = Şirketlogosu,
            LogoImage = Logoimage
        };

        return yeniİş;
    }

    private IEnumerator İşYaratmaDöngüsü()
    {
        while (true) // sürekli kontrol
        {
            // Liste doluysa bekle
            if (kontratListesi.kontratList.Count >= 4)
            {
                yield return null; // bir frame bekle ve tekrar kontrol et
                continue;
            }

            // İş yaratma timer
            float timer = 0f;
            while (timer < İşYaratmaSıklığı)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            // Yeni GameObject oluştur ve Kontrat component'ini ekle
            GameObject kontratObjesi = new GameObject("Kontrat_" + Random.Range(1000, 9999));
            int i = Random.Range(0, kontratListesi.kontratVeri.Count);
            Kontrat yeniİş = kontratObjesi.AddComponent<Kontrat>();
            kontratObjesi.transform.parent = GameObject.Find("kontrat parent").transform;

            yeniİş.İşverenİsmi = kontratListesi.kontratVeri[i].İşverenİsmi;
            yeniİş.VerilenGünSüresi = kontratListesi.kontratVeri[i].VerilenGünSüresi;
            yeniİş.KalanGünSüresi = kontratListesi.kontratVeri[i].VerilenGünSüresi;
            yeniİş.VerilecekPara = kontratListesi.kontratVeri[i].VerilenPara;
            yeniİş.İtibarPuanı = kontratListesi.kontratVeri[i].İtibarPuanı;
            yeniİş.BaşvuruGeçerlilikGünü = kontratListesi.kontratVeri[i].BaşvuruGeçerlilikGünü;
            yeniİş.KalanGeçerlilikGünü = kontratListesi.kontratVeri[i].BaşvuruGeçerlilikGünü;
            yeniİş.AlındıMı = false;
            yeniİş.Açıklama = kontratListesi.kontratVeri[i].Açıklama;
            yeniİş.işTürü = kontratListesi.kontratVeri[i].işTürü;
            yeniİş.ŞirketLogosu = kontratListesi.kontratVeri[i].ŞirketLogosu;
            yeniİş.LogoImage = kontratListesi.kontratVeri[i].LogoImage;

            kontratListesi.kontratList.Add(yeniİş);
            Debug.Log($"Yeni iş yaratıldı ve listeye eklendi: {yeniİş.İşverenİsmi}");
            FindFirstObjectByType<GelenİşlerEkranı>().KontratPaneliniGüncelle();
        }  
    }
}
