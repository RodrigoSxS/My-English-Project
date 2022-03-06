using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NovasFrases : MonoBehaviour
{
    public Text EnglishText, PortugueseTExt, SpanishText;
    public Sprite Play_S, Pause_S;
    AudioClip audio1;
    AudioSource AudioSourceGAme;
    public Frasesaudiotex[] Cartas;
    public GameObject[] Grupodefrases;// seleciona com game object todos os canvas que contem as frases
    bool audioplayine = false, tocou;
    public Button BT_PLAy_trocaimage;
    public Slider slideraudio;
    float contadordetempoemplay = 0;
    int fraseativaatual;
    int[] contagem;
    [SerializeField] Text[] textocontagem;
    [SerializeField] Text CurrentfraseText, currentGroupText;
    [SerializeField] GameObject ButtonGroup;
    private int grupoparafrase;
    InterstitialAdExample InterstitialAdExample =new InterstitialAdExample();
    RewardedAdsButton RewardedAdsButton = new RewardedAdsButton();
    [SerializeField]int Contagemads = 0;
    public int testeramdom;
    bool runads;
    void Start()
    {
        runads = false;
        contagem = new int[300];
        AudioSourceGAme = GetComponent<AudioSource>();
        //EnglishText = GetComponent<Text>();
        // PortugueseTExt = GetComponent<Text>();
        //SpanishText = GetComponent<Text>();
        getcontagem();



    }
    public void Abregrupos(int gruposelec) // Seleciona o grupo de frases que será aberto
    {
        grupoparafrase = gruposelec;
        for (int i = 0; i < Grupodefrases.Length; i++)
        {
            Grupodefrases[i].gameObject.SetActive(false);
        }

        Grupodefrases[gruposelec].gameObject.SetActive(true);
        int currentgrouptemp = 1;
        currentgrouptemp += gruposelec;
        currentGroupText.text = ("Grupo " + currentgrouptemp);

    }
    public void PassaFrase(int indexfrase)
    {

        for (int l = 1; l <= 30; l++)
        {
            if (grupoparafrase == l)
            {
                l *= 10;
                indexfrase += l;
                break;
            }

        }


        int CurrentFraseTemp = 1;
        CurrentFraseTemp += indexfrase;
        CurrentfraseText.text = ("Frase " + CurrentFraseTemp);
        audio1 = Cartas[indexfrase].audio;
        AudioSourceGAme.clip = audio1;
        EnglishText.text = Cartas[indexfrase].ingles.ToString();
        PortugueseTExt.text = Cartas[indexfrase].portugues.ToString();
        //SpanishText.text = Cartas[indexfrase].espanhol.ToString();
        fraseativaatual = indexfrase;
        ButtonGroup.gameObject.SetActive(false);
    }

    public void playcurrentaudio()// Da Play no audio Atual;
    {

        
            slideraudio.maxValue = AudioSourceGAme.clip.length;
            if (!AudioSourceGAme.isPlaying)
            {
                BT_PLAy_trocaimage.image.sprite = Pause_S;
                AudioSourceGAme.Play();



            }
            else
            {
                BT_PLAy_trocaimage.image.sprite = Play_S;

                AudioSourceGAme.Pause();

            }
        
        





    }

    public void voltardafraseselc()
    {
        AudioSourceGAme.Stop();
        // BT_PLAy_trocaimage.image.sprite = Play_S;
        contadordetempoemplay = 0;

        slideraudio.value = 0;
        tocou = false;
        getcontagem();

    }
 
    private void Update()
    {
       
        if(runads)
        {
            //int randoin = Random.Range(0, 2);
            
            testeramdom = Random.Range(0, 2);
            if (testeramdom == 0)
            {
                voltardafraseselc();
                gameObject.GetComponent<InterstitialAdExample>().ShowAd();
                
            }
            else
            {
                voltardafraseselc();
                gameObject.GetComponent<RewardedAdsButton>().ShowAd();
                
            }
            runads = false;
            Contagemads = 0;
            PlayerPrefs.SetInt("contagemads", Contagemads);

        }
            
        

        if (AudioSourceGAme.isPlaying)
        {

            tocou = true;
            contadordetempoemplay = contadordetempoemplay + Time.deltaTime;
            slideraudio.value = contadordetempoemplay;

        }



        if (tocou && AudioSourceGAme.clip != null)
        {

            if ((contadordetempoemplay >= AudioSourceGAme.clip.length))
            {

                contadordetempoemplay = 0;
                salvacontagemfraseatual();

            }
        }

        if (Input.GetKeyDown("a"))
        {
            PlayerPrefs.DeleteAll();
        }


        if (AudioSourceGAme.isPlaying)
        {
            BT_PLAy_trocaimage.image.sprite = Pause_S;
        }
        else
        {
            BT_PLAy_trocaimage.image.sprite = Play_S;
        }

    }



    public void salvacontagemfraseatual()
    {
        contagem[fraseativaatual]++;
        Contagemads++;
        runadsset(Contagemads);
        PlayerPrefs.SetInt("indexcontagem" + fraseativaatual, contagem[fraseativaatual]);
        PlayerPrefs.SetInt("contagemads", Contagemads);


    }
    void runadsset(int contagem)
    {
        if (contagem >= 5)
            runads = true;

    }
    public void getcontagem()
    {
        for (int r = 0; r < textocontagem.Length; r++)
        {
            if (PlayerPrefs.HasKey("indexcontagem" + r))
            {
                contagem[r] = PlayerPrefs.GetInt("indexcontagem" + r);

            }
            else
            {
                PlayerPrefs.SetInt("indexcontagem" + r, contagem[r]);
            }
            textocontagem[r].text = contagem[r].ToString();
        }
        if (PlayerPrefs.HasKey("contagemads"))
        {
            Contagemads = PlayerPrefs.GetInt("contagemads");
        }
        else
        {
            PlayerPrefs.SetInt("contagemads", Contagemads);
        }






    }
}
