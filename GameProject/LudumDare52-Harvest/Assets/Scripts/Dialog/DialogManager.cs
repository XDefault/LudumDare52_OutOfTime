using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{   
    public static DialogManager manager;
    public DialogScript currentDialog;

    [SerializeField] TextMeshProUGUI m_Object;

    float timer;
    public float waitFor = 5;
    // Start is called before the first frame update
    void Start()
    {   
        UpdateText();
        manager = this;
        timer = waitFor;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <=0){
            timer = waitFor;
            UpdateText();
        }
    }

    void UpdateText(){
        if(currentDialog == null){
            m_Object.text = "";
            return;
        }
        m_Object.text = currentDialog.text;
        currentDialog = currentDialog.next;
        
    }

    public void SetDialog(DialogScript dialog){
        currentDialog = dialog;
    }
}
