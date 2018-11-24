using UnityEngine;
using UnityEngine.Monetization;

public class UnityAdsController : MonoBehaviour{
    public bool __testMode = true;
    string __placement_id = "video";

#if UNITY_IOS
    string __gameId = "2890908";
#elif UNITY_ANDROID
    string __gameId = "2890907";
#endif

    // Use this for initialization
    void Start () {
        Monetization.Initialize(__gameId, __testMode);
	}

    public void ShowAd() {
        ShowAdPlacementContent ad;
        ad = Monetization.GetPlacementContent(__placement_id) as ShowAdPlacementContent;
        ad.Show();
    }
}
