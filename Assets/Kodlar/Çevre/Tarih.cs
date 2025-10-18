using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Tarih : MonoBehaviour
{
    public KontratListesi kontratListesi;
    public Þirket þirket;
    public int Yýl;
    [Range(1,12)]
    public int Ay;
    [Range(1, 30)]
    public int Gün;
    public float DayInSeconds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        þirket = FindAnyObjectByType<Þirket>();
        StartCoroutine(TarihiÝlerlet());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TarihiÝlerlet()
    {
        while (true)
        {
            yield return new WaitForSeconds(DayInSeconds);
            GünEkle();
            GeçerlilikGünüAzalt();
        }
    }

    public void GünEkle()
    {
        //Gün artýþý
        Gün++;

        #region Ay artýþý
        if (Ay == 1 || Ay == 3 || Ay == 5 || Ay == 7 || Ay == 8 || Ay == 10 || Ay == 12)
        {
            if (Gün > 31)
            {
                Gün = 0;
                Ay++;
                þirket.KiraÖde();
            }
        }

        else if (Ay == 4 || Ay == 6 || Ay == 9 || Ay == 11)
        {
            if (Gün > 30)
            {
                Gün = 0;
                Ay++;
                þirket.KiraÖde();
            }
        }

        else if (Ay == 2)
        {
            if(Yýl % 4 == 0)
            {
                if (Gün > 29)
                {
                    Gün = 0;
                    Ay++;
                    þirket.KiraÖde();
                }
            }
            else
            {
                if (Gün > 28)
                {
                    Gün = 0;
                    Ay++;
                    þirket.KiraÖde();
                }
            }
        }
        #endregion

        //Yýl artýþý
        if(Ay > 12)
        {
            Yýl++;
            Ay = 0;
        }
    }

    public void GeçerlilikGünüAzalt()
    {
        foreach (Kontrat kontrat in kontratListesi.kontratList)
        {
            if(!kontrat.AlýndýMý)
                kontrat.KalanGeçerlilikGünü--;
        }       
        if (FindFirstObjectByType<AlýnanKontrat>().AlýndýMý)
                FindFirstObjectByType<AlýnanKontrat>().KalanGünSüresi--;
    }
}
