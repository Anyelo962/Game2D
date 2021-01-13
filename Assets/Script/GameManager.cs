using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Renderer fondo;
    public bool gameOver = false;
    public GameObject column;
    public List<GameObject> cols;
    public float velocidad = 2;
    public GameObject piedraUno;
    public GameObject piedraDos;
    public List<GameObject> obstaculos;
    public bool startGame = false;
    public GameObject menuPrincipal;
    public GameObject gameOver_game;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 21; i++)
        {
           cols.Add(Instantiate(column, new Vector2(-11+i, -3), Quaternion.identity));

        }
        //Crear piedras.

        obstaculos.Add(Instantiate(piedraUno, new Vector3(14, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(piedraDos, new Vector3(20, -2), Quaternion.identity));

    }

    // Update is called once per frame
    void Update()
    {
        moverFondo();
    }

    void moverFondo()
    {
        if (startGame == false)
        {

            if (Input.GetKeyDown(KeyCode.X))
            {
                startGame = true;
            }
        }

        if (startGame == true && gameOver == true)
        {
            gameOver_game.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (startGame == true && gameOver == false)
        {
           menuPrincipal.SetActive(false);
            gameOver_game.SetActive(false);
    

            fondo.material.mainTextureOffset += new Vector2(0.15f, 0) * Time.deltaTime;

            //Mover el mapa.
            for (int i = 0; i < cols.Count; i++)
            {
                if (cols[i].transform.position.x <= -11)
                {
                    cols[i].transform.position = new Vector3(11, -3, 0);
                }
                cols[i].transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }

            //Mover piedras.
            for (int i = 0; i < obstaculos.Count; i++)
            {
                if (cols[i].transform.position.x <= -11)
                {
                    float random = Random.Range(11, 18);
                    obstaculos[i].transform.position = new Vector3(random, -2, 0);
                }
                obstaculos[i].transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }

        }
    }
}
