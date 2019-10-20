using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuGenerator : MonoBehaviour
{
    [Header("Prefabs :")]
    public GameObject gameLogoPrefab;
    public GameObject backgroundPrefab;
    public GameObject buttonPrefab;

    [Header("Réglages :")]
    public string[] buttonNames;
    public float gameLogoMarginTop;
    public float gameLogoSize;
    public float buttonsOffset;
    public float spaceBewteenButtons;
    public float buttonFontSize;

    public void CreateMenu()
    {
        //Clear du menu
        int nbChildren = transform.childCount;
        for (int i = 0; i < nbChildren; i++)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }

        //Background Image
        Instantiate(backgroundPrefab, new Vector3(GetComponent<RectTransform>().rect.width / 2, GetComponent<RectTransform>().rect.height / 2, 0), Quaternion.identity, transform);

        //Game Logo
        GameObject gameLogo = Instantiate(gameLogoPrefab, new Vector3(0, 0, 0), Quaternion.identity, transform);
        gameLogo.transform.position = new Vector3(GetComponent<RectTransform>().rect.width / 2, GetComponent<RectTransform>().rect.height - gameLogo.GetComponent<RectTransform>().rect.height/2 - gameLogoMarginTop, 0);
        gameLogo.GetComponent<RectTransform>().sizeDelta = new Vector2(gameLogoSize, gameLogoSize);

        //Boutons
        for (int i = 0; i < buttonNames.Length; i++)
        {
            GameObject button = Instantiate(buttonPrefab, new Vector3(GetComponent<RectTransform>().rect.width / 2, GetComponent<RectTransform>().rect.height / 2, 0), Quaternion.identity, transform);
            SetButtonText(button, buttonNames[i]);
            button.transform.position += new Vector3(0, buttonsOffset - (i * spaceBewteenButtons), 0);
            button.GetComponent<ButtonManager>().SetButtonIndex(i);
        }
    }

    //change le text du bouton
    public void SetButtonText(GameObject button, string buttonText)
    {
        Transform child;
        for (int i = 0; i < button.transform.childCount; i++)
        {
            if (button.transform.GetChild(i).GetComponent<TextMeshProUGUI>() != null)
            {
                child = button.transform.GetChild(i);
                TextMeshProUGUI text = child.GetComponent<TextMeshProUGUI>();
                text.fontSize = buttonFontSize;

                text.SetText(buttonText); //set le texte
                child.GetComponent<RectTransform>().sizeDelta = new Vector2(buttonFontSize * buttonText.Length, buttonFontSize); //adapte la boite pour être sur qu'elle soit plus grande que le texte
            }

            if (button.transform.GetChild(i).gameObject.name.Contains("BG"))
            {
                child = button.transform.GetChild(i);
                child.GetComponent<RectTransform>().sizeDelta = new Vector2(buttonFontSize * buttonText.Length, 2 * buttonFontSize);
            }
        }

    }

}
