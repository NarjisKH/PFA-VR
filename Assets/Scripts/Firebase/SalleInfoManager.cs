using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SalleInfoManager :  MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI  infoTitle;
    [SerializeField] private TextMeshProUGUI  infoMat;
    [SerializeField] private TextMeshProUGUI  infoDesc;

    public static SalleInfoManager Instance;
    private void Awake() {
        Instance = this;
    }

    public void ChangeSalleUIInfo(IDictionary sceneData){
        infoTitle.text = sceneData["titre"].ToString();
        infoMat.text = sceneData["matiere"].ToString();
        infoDesc.text = sceneData["description"].ToString();
    }
    public void ResetSalleUIInfo(){
        infoTitle.text = "Titre";
        infoMat.text = "Matière";
        infoDesc.text = "Description";
    }
}
