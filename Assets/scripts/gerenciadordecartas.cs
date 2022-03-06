using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;




public class gerenciadordecartas : MonoBehaviour
{
    public GameObject canvacartas, canvatips, canvasemcartas;
    // Falta Ajustar tempos e sistema de save das listas;
    public int tempoadd_facil, tempoadd_facilNV2, tempoadd_dificil, tempoadd_muito_dificil;// teste
    public CartasSR[] vetorcartas;// vetor que contem as cartas
    public Image recebeimagemcarta;//objeto que recebe o valor da carta
    public Text recebenomedacarta,recebenomedacartaparaaudio;
    
    AudioSource AudioSourcecartas;

           int indexselecionado, CalcListaSoma;
    int Currenthourbyseconds;
    public List<int> Lista_facil = new List<int>(), Lista_dificil = new List<int>(), Lista_muito_dificil = new List<int>(), Lista_facilNv2 = new List<int>(), Lista_especial = new List<int>();
           List<int> tempoListaFacil = new List<int>(), tempoLista_Dificil = new List<int>(), Tempo_lista_muito_dificil = new List<int>(), tempoListaFacilNV2 = new List<int>();
    public int contaadscartas = 0;



    private void Awake()
    {
        AudioSourcecartas = GetComponent<AudioSource>();
    }

    void Start()
    {


        Sorteiacarta();
        StartCoroutine("invokeremove");
        ResgatadadoslistaF();// Carrega a lista facil com os itens nela contido antes da saida do player do app
        ResgatadadoslistaF2();
        ResgataListaEspec();
        ResgatadadoslistaDificil();
        ResgatadadoslistaMuitoDificil();

    }



    // essa parte faz a verificação nas lista para saber se o numero sorteado ja esta em alguma lista  e não pode ser mostrado

    void Sorteiacarta()//sorteia as cartas e chama os metodos de verificação.
    {
        CalcListaSoma = calculatamanhodaslista();
        if (CalcListaSoma < vetorcartas.Length)
        {

            indexselecionado = UnityEngine.Random.Range(0, vetorcartas.Length);
            verificacaode_facil_nv1();
        }
        else
        {
            fim_das_cartas();
        }

    }
    void verificacaode_facil_nv1() // metodo de verificação para saber se carta já foi selecionada.Está na lista de cartas faceis de nv1.
                                   //chma a proxima verificação
    {
        if (Lista_facil.Contains(indexselecionado))
        {

            Sorteiacarta();

        }
        else
        {
            CalcListaSoma = calculatamanhodaslista();
            if (CalcListaSoma < vetorcartas.Length)
            {
                Verificacao_facilnv2();
            }
            else
            {
                fim_das_cartas();
            }
        }
    }
    void Verificacao_facilnv2()
    {
        if (Lista_facilNv2.Contains(indexselecionado))
        {

            Sorteiacarta();

        }
        else
        {
            CalcListaSoma = calculatamanhodaslista(); // calculo para saber se já é o fim das cartas
            if (CalcListaSoma < vetorcartas.Length)
            {
                Verificacao_Dificil();
            }
            else
            {
                fim_das_cartas();
            }
        }
    }
    void Verificacao_Dificil() // metodo de verificação para saber se carta já foi selecionada.Está na lista de cartas dificil
                               //chma a proxima verificação
    {
        if (Lista_dificil.Contains(indexselecionado))
        {
            Sorteiacarta();

        }
        else
        {
            CalcListaSoma = calculatamanhodaslista();
            if (CalcListaSoma < vetorcartas.Length)
            {
                Verfificacao_muitoDificil();

            }
            else
            {
                fim_das_cartas();
            }

        }

    }
    void Verfificacao_muitoDificil() // metodo de verificação para saber se carta já foi selecionada.Está na lista de cartas Muito dificil.
                                     //chma a proxima verificação
    {
        if (Lista_muito_dificil.Contains(indexselecionado))
        {
            Sorteiacarta();

        }
        else
        {
            CalcListaSoma = calculatamanhodaslista();
            if (CalcListaSoma < vetorcartas.Length)
            {
                primeiravez();
            }
            else
            {
                fim_das_cartas();
            }
        }
    }
    void primeiravez()// é chamada apenas quando a primeira vez que a carta é Selecionada. 
    {
        recebeimagemcarta.GetComponent<Image>().sprite = vetorcartas[indexselecionado].imagemcarta;
        recebenomedacarta.GetComponent<Text>().text = vetorcartas[indexselecionado].nomedacarta;
        recebenomedacartaparaaudio.GetComponent<Text>().text = vetorcartas[indexselecionado].nomedacarta;

    }



    public void tocarcartaFrase()//Chama caso o usuario clique em reproduzir audio da carta;
    {
        AudioSourcecartas.clip = vetorcartas[indexselecionado].audiodacarta;
        AudioSourcecartas.Play();
    }
    public void tocarcartaPalavra()//Chama caso o usuario clique em reproduzir audio da carta;
    {
        AudioSourcecartas.clip = vetorcartas[indexselecionado].AudioclipWord;
        AudioSourcecartas.Play();
    }




    // metodos chamados pelos botoes que o usuario apertar facil, dificl, muito dificl.

    public void Escolha_Facil() // é chamada pela escolha do usuario, Para indicar que a carta é facil. a funão adiciona a carta a lista de cartas indisponiveis faceis
    {
        if (Lista_especial.Contains(indexselecionado))
        {
            Escolha_Facil_segundainsta();
        }
        else
        {
            Lista_facil.Add(indexselecionado);
            //tempoListaFacil.Add(Get_current_hour() + getdaysbyseconfs(1)); // add aqui quantidade de dias que demora para remoção lista.
            tempoListaFacil.Add(Get_current_hour() + tempoadd_facil); // testes
            Lista_especial.Add(indexselecionado);
            salvalistafacil(indexselecionado,Get_current_hour()+tempoadd_facil);
            Salvalistaespecial(indexselecionado);
            Sorteiacarta();
            chamaanuncio();
        }

    }
    public void Escolha_Facil_segundainsta() // é chamada pela escolha do usuario, Para indicar que a carta é facil. a funão adiciona a carta a lista de cartas indisponiveis faceis
    {

        Lista_facilNv2.Add(indexselecionado);
        //tempoListaFacil.Add(Get_current_hour() + getdaysbyseconfs(1)); // add aqui quantidade de dias que demora para remoção lista.
        tempoListaFacilNV2.Add(Get_current_hour() + tempoadd_facilNV2); // testes
        salvalistafacilsegundainsta(indexselecionado, Get_current_hour() + tempoadd_facilNV2);
        Sorteiacarta();
        chamaanuncio();
    }
    public void Escolha_dificil()// é chamada pela escolha do usuario, Para indicar que a carta é Dificil. a funão adiciona a carta a lista de cartas indisponiveis dificeis
    {
        if (Lista_especial.Contains(indexselecionado))
        {
            Lista_especial.Remove(indexselecionado);
            delatalistaespec(indexselecionado);
        }
        Lista_dificil.Add(indexselecionado);
        tempoLista_Dificil.Add(Get_current_hour() + tempoadd_dificil);
        SalvaListaDificil(indexselecionado, Get_current_hour() + tempoadd_dificil);
        Sorteiacarta();
        chamaanuncio();
    }
    public void Escolha_muito_dificil()//é chamada pela escolha do usuario, Para indicar que a carta é Dificil. a funão adiciona a carta a lista de cartas indisponiveis muito dificeis
    {
        if (Lista_especial.Contains(indexselecionado))
        {
            Lista_especial.Remove(indexselecionado);
            delatalistaespec(indexselecionado);
        }
        Lista_muito_dificil.Add(indexselecionado);
        Tempo_lista_muito_dificil.Add(Get_current_hour() + tempoadd_muito_dificil);
        SalvaListaMuitoDificil(indexselecionado, Get_current_hour() + tempoadd_muito_dificil);
        Sorteiacarta();
        chamaanuncio();
    }


   

   
    void chamaanuncio()
    {
        contaadscartas++;
        if(contaadscartas > 15)
        {
           int testeramdom = UnityEngine.Random.Range(0, 2);
            if (testeramdom == 0)
            {
                
                gameObject.GetComponent<InterstitialAdExample>().ShowAd();

            }
            else
            {
                
                gameObject.GetComponent<RewardedAdsButton>().ShowAd();

            }

            contaadscartas = 0;
            salvacontagemanuncio();
        }
        salvacontagemanuncio();
    }

    void salvacontagemanuncio()
    {
        PlayerPrefs.SetInt("contagemadscartas", contaadscartas);
    }
    void Getvalorcartaads()
    {
        if (PlayerPrefs.HasKey("contagemadscartas"))
        {
            contaadscartas = PlayerPrefs.GetInt("contagemadscartas");
        }
        else
        {
            PlayerPrefs.SetInt("contagemadscartas", contaadscartas);
        }
    }

    


    void salvalistafacil(int key, int Tempoagendado) // salva valores contidos na lista de cartas facil
    {
        PlayerPrefs.SetInt("ListaF" + key, key);
        PlayerPrefs.SetInt("TempolistaF" + key, Tempoagendado);
    }
    void salvalistafacilsegundainsta(int key, int Tempoagendado) // salva valores contidos na lista de cartas facil de segundainstancia
    {
        PlayerPrefs.SetInt("ListaF2" + key, key);
        PlayerPrefs.SetInt("TempolistaF2" + key, Tempoagendado);
    }
    void Salvalistaespecial(int key) // salva valores contidos na lista de cartas lista especial
    {
        PlayerPrefs.SetInt("ListaEspec" + key, key);      
    }
    void SalvaListaDificil (int key, int Tempoagendado) // salva valores contidos na lista de cartas facil de segundainstancia
    {
        PlayerPrefs.SetInt("ListaD" + key, key);
        PlayerPrefs.SetInt("TempoListaD" + key, Tempoagendado);
    }

    void SalvaListaMuitoDificil(int key, int Tempoagendado) // salva valores contidos na lista de cartas facil de segundainstancia
    {
        PlayerPrefs.SetInt("ListaMD" + key, key);
        PlayerPrefs.SetInt("TempoListaMD" + key, Tempoagendado);
    }




    void ResgatadadoslistaF() // chamada no start para carregar os itens da lista facil
    {
       
        for (int i = 0; i <= vetorcartas.Length; i++)
        {
            if (PlayerPrefs.HasKey("ListaF" + i))
            {
                
                int tempoagendadotemp = PlayerPrefs.GetInt("TempolistaF" + i);
               
                if(tempoagendadotemp > Get_current_hour())
                    {
                    
                    Lista_facil.Add(PlayerPrefs.GetInt("ListaF" + i));
                    tempoListaFacil.Add(PlayerPrefs.GetInt("TempolistaF" + i));
                     }
                else
                    {
                    
                   
                    PlayerPrefs.DeleteKey("ListaF" + i);
                    PlayerPrefs.DeleteKey("TempolistaF" + i);

                }
                


            }
        }
    }
    void ResgatadadoslistaF2() // chamada no start para carregar os itens da lista facilnv2
    {
        
        for (int i = 0; i <= vetorcartas.Length; i++)
        {
            if (PlayerPrefs.HasKey("ListaF2" + i))
            {
                
                int tempoagendadotemp = PlayerPrefs.GetInt("TempolistaF2" + i);

                if (tempoagendadotemp > Get_current_hour())
                {
                   
                    Lista_facilNv2.Add(PlayerPrefs.GetInt("ListaF2" + i));
                    tempoListaFacilNV2.Add(PlayerPrefs.GetInt("TempolistaF2" + i));
                }
                else
                {

                    PlayerPrefs.DeleteKey("ListaF2" + i);
                    PlayerPrefs.DeleteKey("TempolistaF2" + i);

                }
            }
          
        }
    }
    void ResgatadadoslistaDificil() // chamada no start para carregar os itens da lista Dificil
    {

        for (int i = 0; i <= vetorcartas.Length; i++)
        {
            if (PlayerPrefs.HasKey("ListaD" + i))
            {

                int tempoagendadotemp = PlayerPrefs.GetInt("TempoListaD" + i);

                if (tempoagendadotemp > Get_current_hour())
                {

                    Lista_dificil.Add(PlayerPrefs.GetInt("ListaD" + i));
                    tempoLista_Dificil.Add(PlayerPrefs.GetInt("TempoListaD" + i));
                }
                else
                {

                    PlayerPrefs.DeleteKey("ListaD" + i);
                    PlayerPrefs.DeleteKey("TempoListaD" + i);

                }
            }

        }
    }

    void ResgatadadoslistaMuitoDificil()
    {
        for (int i = 0; i <= vetorcartas.Length; i++)
        {
            if (PlayerPrefs.HasKey("ListaMD" + i))
            {

                int tempoagendadotemp = PlayerPrefs.GetInt("TempoListaMD" + i);

                if (tempoagendadotemp > Get_current_hour())
                {

                    Lista_muito_dificil.Add(PlayerPrefs.GetInt("ListaMD" + i));
                    Tempo_lista_muito_dificil.Add(PlayerPrefs.GetInt("TempoListaMD" + i));
                }
                else
                {

                    PlayerPrefs.DeleteKey("ListaMD" + i);
                    PlayerPrefs.DeleteKey("TempoListaMD" + i);

                }
            }

        }
    }
    void ResgataListaEspec() // chamada no start para carregar os itens da lista Espepecial
    {
      for (int i = 0; i <= vetorcartas.Length; i++)
        {
            if (PlayerPrefs.HasKey("ListaEspec" + i))
            {
                Lista_especial.Add(PlayerPrefs.GetInt("ListaEspec" + i));
            }
          
        }
    }
    void delatalistaespec(int key)
    {
        PlayerPrefs.DeleteKey("ListaEspec" + key);
    } // apaga a key apontada da lista de lista especial
    
    
    
    
    
    
    void Update ()
    {

        
        if(Input.GetKeyDown(KeyCode.X))
            {
            PlayerPrefs.DeleteAll();
        }
    } // estou usando para apagar todas as keys para realizar os testes do player prefs

    
    
    
    
    
    
    
    
    
    
    
    
    
    
    int Get_current_hour()//função apenas pega a hora atual e passa para a variavel currentehourbyseconds.
    {
        Currenthourbyseconds = DateTime.Now.Second + DateTime.Now.Minute * 60 + DateTime.Now.Hour * 3600 + DateTime.Now.DayOfYear * 86400;
        return Currenthourbyseconds;

    }
    int getdaysbyseconfs(int dias) // retorna em segundos a quantidade de dias selecionados
    {
        return dias * 24 * 60 * 60;
    }
    int gethourbyseconds(int horas) // retona em segundos as horas passadas por parametro
    {
        return horas * 60 * 60;
    }
    int getminutesbyseconds(int minutos) // retona em segundos os minutos passadas por parametro
    {
        return minutos * 60;
    }
    void fim_das_cartas()// chamar o que vai fazer quando acabar as cartas
    {
        
        canvacartas.gameObject.SetActive(false);
        canvatips.gameObject.SetActive(false);
        canvasemcartas.gameObject.SetActive(true);
    }
    int calculatamanhodaslista()
    {
        int Tamanh9olistafacil = Lista_facil.Count;
        int tamanholistad = Lista_dificil.Count;
        int tamanlistamd = Lista_muito_dificil.Count;
        int tamnhdalistafanv2 = Lista_facilNv2.Count;

        return Tamanh9olistafacil + tamanholistad + tamanlistamd + tamnhdalistafanv2;
    }//Faz o calculo do total de itens das listas

    IEnumerator invokeremove() // em tempo pré determinado ele chama as funçoes de remoçção de lista.
    {
        yield return new WaitForSeconds(3); // tempo que chama os metodos de remoção da lista, criado para não precisar ficar chamando ela no update o no fixed update  
        Checklist_facil();
        Checklist_facilnv2();
        Checklist_dificil();
        Checklist_muitodificil();
        StartCoroutine("invokeremove");
    }


    void Checklist_facil()
    {
        if (tempoListaFacil.Count >= 1)
        {
            if (tempoListaFacil[0] < Get_current_hour())
            {

                Lista_facil.RemoveAt(0);
                tempoListaFacil.RemoveAt(0);
                Lista_facil.TrimExcess();
                tempoListaFacil.TrimExcess();
            }
        }


    } // remove os itens da lista facil
    void Checklist_facilnv2()
    {
        if (tempoListaFacilNV2.Count >= 1)
        {
            if (tempoListaFacilNV2[0] < Get_current_hour())
            {

                Lista_facilNv2.RemoveAt(0);
                tempoListaFacilNV2.RemoveAt(0);
                tempoListaFacilNV2.TrimExcess();
                Lista_facilNv2.TrimExcess();
            }
        }

    } // remove os itens da lista FAcil NV2
    void Checklist_dificil()
    {
        if (tempoLista_Dificil.Count >= 1)
        {
            if (tempoLista_Dificil[0] < Get_current_hour())
            {

                Lista_dificil.RemoveAt(0);
                tempoLista_Dificil.RemoveAt(0);
                Lista_dificil.TrimExcess();
                tempoLista_Dificil.TrimExcess();
            }
        }

    } // remove os itens da lista dificl
    void Checklist_muitodificil()
    {
        if (Tempo_lista_muito_dificil.Count >= 1)
        {
            if (Tempo_lista_muito_dificil[0] < Get_current_hour())
            {

                Lista_muito_dificil.RemoveAt(0);
                Tempo_lista_muito_dificil.RemoveAt(0);
                Lista_muito_dificil.TrimExcess();
                Tempo_lista_muito_dificil.TrimExcess();
            }
        }

    }  //Remove os itens da lista muito dificil
}



