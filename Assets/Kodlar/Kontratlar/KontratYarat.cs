using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class KontratYarat : MonoBehaviour
{
    private Şirket şirket;
    [Tooltip("Değişken belirtilen saniye sıklığında iş üretir.")]
    public float İşYaratmaSıklığı;
    [HideInInspector]
    public float İlkSıklık;

    private void Awake()
    {
        şirket = FindFirstObjectByType<Şirket>();
        İlkSıklık = İşYaratmaSıklığı;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(İşYaratmaDöngüsü());
    }

    // Update is called once per frame
    void Update()
    {
        İşYaratmaSıklığı = İlkSıklık + (şirket.İtibarPuanı / 100f);
    }

    public Kontrat İşiYarat(string _İşverenİsmi, int _VerilenGünSüresi, int _Maaş, int _İtibarPuanı, int _BaşvuruGeçerlilikGünü, bool _AlındıMı)
    {
        Kontrat Yeniİş = new Kontrat
        {
            İşverenİsmi = _İşverenİsmi,
            VerilenGünSüresi = _VerilenGünSüresi,
            Maaş = _Maaş,
            İtibarPuanı = _İtibarPuanı,
            BaşvuruGeçerlilikGünü = _BaşvuruGeçerlilikGünü,
            AlındıMı = _AlındıMı
        };

        return Yeniİş;
    }

    private IEnumerator İşYaratmaDöngüsü()
    {
        while (true)
        {
            float timer = 0f;

            // İşYaratmaSıklığı değiştikçe süreyi anlık olarak kontrol et
            while (timer < İşYaratmaSıklığı)
            {
                timer += Time.deltaTime; // geçen süreyi ekle
                yield return null;       // bir frame bekle
            }

            // İş yarat
            Kontrat yeniİş = İşiYarat("Şirket X", 5, 1000, 10, 3, false);
            print($"Yeni iş yaratıldı: {yeniİş.İşverenİsmi}");
        }
    }

}
