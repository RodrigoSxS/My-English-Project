using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
public class ADsUnityMenu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize("4564237", true); // inicialização para android                                   
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        chamabunner();
        LoadBanner();
    }
    public void LoadBanner()
    {


        // Load the Ad Unit with banner content:
        Advertisement.Banner.Load("Banner_Android");
    }
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
    // Update is called once per frame
    void Update()
    {

        

    }

    private void FixedUpdate()
    {
        //Debug.Log(Advertisement.Banner.isLoaded);
    }
    void chamabunner()
    {


        Advertisement.Banner.Show("Banner_Android");

    }

    void HideBannerAd()
    {
        // Hide the banner:
        Advertisement.Banner.Hide();

    }
}
