using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    Transform selectedPiece;
    Transform selectedSquare;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SelectPiece(Transform piece)
    {
        
        DeselectPiece();
        selectedPiece = piece;
        GameState._instance.CheckPosMov(selectedPiece);
        Renderer[] renderers = selectedPiece.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.material.EnableKeyword("_EMISSION");
            r.material.SetColor("_EmissionColor", Color.red);
        }
    }

    void DeselectPiece()
    {
        if (selectedPiece)
        {

            Renderer[] renderers = selectedPiece.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)
            {
                r.material.DisableKeyword("_EMISSION");
                r.material.SetColor("_EmissionColor", Color.black);
            }
            GameState._instance.UpdateChessborad(selectedSquare.GetComponent<Square>(), selectedPiece);
            GameState._instance.UnhighlightSquare();
        }
        selectedPiece = null;
    }

    void SelectSquare(Transform square)
    {
        DeselectSquare();
        selectedSquare = square;

        square.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
    }

    void DeselectSquare()
    {
        if (selectedSquare)
        {
            
            selectedSquare.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.0f);

        }
        selectedSquare = null;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == "square")
                {
                    SelectSquare(hit.transform);
                    //hit.transform.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
                    if (selectedPiece)
                    {
                        selectedPiece.position = hit.transform.position;
                        
                        DeselectPiece();
                        //selectedPiece.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
                    }
                }

                if (hit.transform.tag == "piece")
                {

                    SelectPiece(hit.transform);

                }
            }

        }
    }
}
