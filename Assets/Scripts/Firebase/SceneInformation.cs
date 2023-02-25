using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class SceneInformation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private IDictionary sceneInformation;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Get the information you want to send from the button
        //IDictionary sceneData = eventData.pointerEnter.GetComponent<SceneInformation>().GetInformation();

        // Modify the UI based on the information
        SalleInfoManager.Instance.ChangeSalleUIInfo(sceneInformation);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Reset the UI when the mouse exits the button
        SalleInfoManager.Instance.ResetSalleUIInfo();
    }
    
    public void SetInformation(IDictionary sceneData){
        this.sceneInformation = sceneData;
    }
    public IDictionary GetInformation(){
        return sceneInformation;
    }
}
