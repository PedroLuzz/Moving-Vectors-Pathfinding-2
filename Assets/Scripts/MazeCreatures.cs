using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeCreatures : MonoBehaviour
{
    public float speed;
    public GameObject target; // Seleciona Alvo do movimento, onde o objeto irá parar
    public AudioSource ScrapingSound;
    private bool Moving = false;
    public GameObject GameOverScreen;
    public AudioSource DeathSound;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Waiter());
    }

    // Update is called once per frame
    void Update()
    {
        if (Moving)
        {
            float step = speed * Time.deltaTime; // Velocidade de movimento do objeto adaptada para o deltaTime para ser Frame Independent
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step); // Move o objeto em direção ao alvo, utilizando o step de distância em cada atualização
        }

        // Verifica se objeto chegou na posição do alvo
        if (transform.position == target.transform.position)
        {
            ScrapingSound.Stop(); // Desativa o som do objeto
            Moving = false; // Define o Booleano de movimento para falso
        }
    }
    // Corotina para lidar com movimento
    private IEnumerator Waiter()
    {
        yield return new WaitForSeconds(5); // Espera 5 segundos antes de iniciar movimento
        Moving = true; // Define o Booleano de movimento para verdadeiro
        ScrapingSound.Play(); // Ativa o som do objeto
    }

    private IEnumerator GameOver()
    {
        //Coloca a UI de gameover
        yield return new WaitForSeconds(0.06f); // Espera 6 segundos antes de reiniciar a cena
        SceneManager.LoadScene("Part 2 Scene 1"); // Reinicia
    }

    private void OnTriggerEnter(Collider other) // Check de colisão com as criaturas
    {
        if (other.gameObject == target)
        {
            DeathSound.Play(); // Toca som de morte
            Time.timeScale = 0.01f;
            GameOverScreen.SetActive(true); // Mostra tela de morte
            StartCoroutine(GameOver()); // Inicia rotina para reiniciar
        }
    }


}