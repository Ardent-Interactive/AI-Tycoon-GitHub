using UnityEngine;
using UnityEngine.UI;
using static GelenİşlerEkranı;

public class YapımSüreciUI : MonoBehaviour
{
    public GameObject MaliyetveZamanText;
    public GameObject[] Paneller;
    public Text MaliyetText, SüreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MaliyetText.text = "Maliyet: " + gameObject.GetComponent<YapımSüreci>().Maliyet + "$";
        SüreText.text = "Süre: " + gameObject.GetComponent<YapımSüreci>().Süre.ToString(string.Format("00")) + "gün";
    }

    public void SonrakiPaneleGeç(GameObject SonrakiPanel)
    {
        MaliyetveZamanText.SetActive(true);
        for (int i = 0; i < Paneller.Length; i++)
        {
            if(Paneller[i] == SonrakiPanel)
            {
                Paneller[i].gameObject.SetActive(true);
            }
            else
            {
                Paneller[i].gameObject.SetActive(false);
            }
        }
    }

    public void KontratıYapmayaBaşla()
    {
        MaliyetveZamanText.SetActive(false);
        print("Fonksiyon tetiklendi ama içi boş");

        for (int i = 0; i < Paneller.Length; i++)
        {
        Paneller[i].gameObject.SetActive(false);
        }
    }
}
