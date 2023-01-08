using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Sanity : MonoBehaviour
{   
    public static Sanity manager;
    private int sanity;
    [SerializeField]private GameObject gameOverScreen;
    [SerializeField]private AudioClip soundHit;
    [SerializeField] TextMeshProUGUI m_Object;
    // Start is called before the first frame update
    void Start()
    {
        sanity = 100;
        manager = this;
    }

    // Update is called once per frame
    void Update()
    {
        m_Object.text = sanity.ToString();
        if(sanity <= 0){
            CharacterMove.cm.SetCanMovement(false);
            gameOverScreen.SetActive(true);
            if(Input.GetButtonDown("Fire1")){
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
            return;
        }

    }

    public void Hit(int amount){
        sanity -= amount;
        if(sanity < 0) sanity = 0;
        AudioManager.manager.Play(soundHit);
    }

    public void Restore(){
        sanity += 25;
        if(sanity > 100) sanity = 100;
    }
}
