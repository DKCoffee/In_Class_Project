using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {
    [SerializeField]
    public Button Button;

	// Use this for initialization
	void Start () {
        Button buttonn = Button.GetComponent<Button>();
        buttonn.onClick.AddListener(LoadLevel); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void LoadLevel()
    {
        SceneManager.LoadScene("FirstLevel");
    }
}
