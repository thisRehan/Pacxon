using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject grid;
    [SerializeField] Text liveText;
    [SerializeField] int row;
    [SerializeField] int col;
    // Start is called before the first frame update
    void Start()
    {
        spawn();
        //liveText.GetComponent<UnityEngine.UI.Text>().text = "Text";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawn()
    {
        for(int i=0; i<row; i++)
        {
            for(int j=0; j<col; j++)
            {
                Instantiate(grid, new Vector3(i, j, 0), grid.transform.rotation);
            }
        }
    }
}
