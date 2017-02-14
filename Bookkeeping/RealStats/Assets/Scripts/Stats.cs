using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Stats : MonoBehaviour {

    public GameObject menu_opening;
    public GameObject menu_add;
    public GameObject menu_stats;

    public Text text1;
    public Text text2;

    public enum Menus {Opening, Add, Stats};


    // Use this for initialization
    void Start () {
        text1.text = "Active: " + System.DateTime.Now.Day + "th";
        text2.text = "Active: " + System.DateTime.Now.Day + "th";

        menu_opening.SetActive(true);
        menu_add.SetActive(false);
        menu_stats.SetActive(false);
    }
	
    public void Increment() {
        string button = EventSystem.current.currentSelectedGameObject.name;
        if (PlayerPrefs.HasKey(button)) {
            int current_count = PlayerPrefs.GetInt(button);
            PlayerPrefs.SetInt(button, ++current_count);
            GameObject buttonGameObj = GameObject.Find(button);
            buttonGameObj.GetComponentInChildren<Text>().text = buttonGameObj.activeSelf && PlayerPrefs.HasKey(buttonGameObj.name) ? PlayerPrefs.GetInt(buttonGameObj.name).ToString() : "0";
        } else {
            PlayerPrefs.SetInt(button, 1);
        }
    }

    public void Decrement() {
        string button = EventSystem.current.currentSelectedGameObject.name;
        if (PlayerPrefs.HasKey(button)) {
            int current_count = PlayerPrefs.GetInt(button);
            PlayerPrefs.SetInt(button, --current_count);
        } else {
            PlayerPrefs.SetInt(button, 0);
        }
        displayStats();
    }

    public void displayNames() {
        Button[] buttons = FindObjectsOfType(typeof(Button)) as Button[];
        Debug.Log(buttons.Length);
        foreach (Button button in buttons) {
            GameObject buttonGameObj = button.transform.gameObject;
            if (buttonGameObj.name == "Back") continue;
            buttonGameObj.GetComponentInChildren<Text>().text = buttonGameObj.name;
        }
    }

    public void displayStats() {
        Button[] buttons = FindObjectsOfType(typeof(Button)) as Button[];
        Debug.Log(buttons.Length);
        foreach(Button button in buttons){
            GameObject buttonGameObj = button.transform.gameObject;
            if (buttonGameObj.name == "Back") continue; 
            buttonGameObj.GetComponentInChildren<Text>().text = buttonGameObj.activeSelf && PlayerPrefs.HasKey(buttonGameObj.name) ? PlayerPrefs.GetInt(buttonGameObj.name).ToString() : "0";
            }
        }

    public void changeMenu(string menu) {
        print(EventSystem.current.currentSelectedGameObject.name);
        switch (menu) {
            case "Opening":
                menu_opening.SetActive(true);
                menu_add.SetActive(false);
                menu_stats.SetActive(false);
                break;
            case "Add":
                menu_opening.SetActive(false);
                menu_add.SetActive(true);
                menu_stats.SetActive(false);
                displayNames();
                break;
            case "Stats":
                menu_opening.SetActive(false);
                menu_add.SetActive(false);
                menu_stats.SetActive(true);
                displayStats();
                break;
        } 
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            menu_opening.SetActive(true);
            menu_add.SetActive(false);
            menu_stats.SetActive(false);
        }
    }
}
