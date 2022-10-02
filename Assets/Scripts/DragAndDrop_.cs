using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
public class DragAndDrop_ : MonoBehaviour
{
    private GameObject _descriptionPanel;
    private TMP_Text _descriptionText;

    public Sprite[] Levels;
    public GameObject EndMenu;
    public GameObject SelectedPiece;
    int OIL = 1;    
    public int PlacedPieces = 0;

    public static int earnedCoins;

    void Start()
    {
        earnedCoins = Random.Range(8000, 30000);
        _descriptionPanel = GameObject.Find("DescriptionPanel").gameObject;
        _descriptionText = GameObject.Find("Description").GetComponent<TMP_Text>();
        _descriptionPanel.SetActive(false);

        for (int i = 0;i < 36; i++)
        {
            GameObject.Find("Piece (" + i + ")").transform.Find("Puzzle").GetComponent<SpriteRenderer>().sprite = Levels[PlayerPrefs.GetInt("Level")];
        }
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("Puzzle"))
            {
                if (!hit.transform.GetComponent<piceseScript>().InRightPosition)
                {
                    SelectedPiece = hit.transform.gameObject;
                    SelectedPiece.GetComponent<piceseScript>().Selected = true;
                    SelectedPiece.GetComponent<SortingGroup>().sortingOrder = OIL;
                    OIL++;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (SelectedPiece != null)
            {
                SelectedPiece.GetComponent<piceseScript>().Selected = false;
                SelectedPiece = null;
            }
        }
        if (SelectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(MousePoint.x,MousePoint.y,0);
        }
        if (PlacedPieces == 36)
        {
            _descriptionPanel.SetActive(true);
            _descriptionText.text = $"You have earned: {earnedCoins} coins";
        }
    }
    public void NextLevel()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level")+1);
        SceneManager.LoadScene("Game");
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}