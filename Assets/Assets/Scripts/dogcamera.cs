using System.Collections;
using UnityEngine;
using Cinemachine;

public class dogcamera : MonoBehaviour
{
    public GameObject mainCamera, character;
    public GameObject playerCamObj;
    CinemachineBrain cinemachineBrain;
    bool isGameStarted = false;

    private void Start()
    {
        cinemachineBrain = mainCamera.GetComponent<CinemachineBrain>();
        playerCamObj.SetActive(false);
        StartCoroutine(FinishToPlayerCam());
    }

    IEnumerator FinishToPlayerCam()
    {
        yield return new WaitForSeconds(2);
        playerCamObj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // vcam is no longer participating in a blend and can safely be teleported 
        if (!cinemachineBrain.IsBlending && !isGameStarted)
        {
            isGameStarted = true;
        }
    }
}