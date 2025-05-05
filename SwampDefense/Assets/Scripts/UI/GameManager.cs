using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public int vidas = 3;
    public TextMeshProUGUI vidasTexto;


    public GameObject gameOverTela;
    public GameObject vitoriaTela;

    private bool jogoAcabou = false;

    void Start()
    {
        AtualizarTextoVidas();
        gameOverTela.SetActive(false);
        vitoriaTela.SetActive(false);
    }

    void Update()
    {
        if (jogoAcabou) return;

        // Checa se ainda há inimigos na cena
        if (WavesConfig.main.waveAtual > WavesConfig.main.waves.Count)
        {
            VencerJogo();
        }
    }

    public void PerderVida()
    {
        if (jogoAcabou) return;

        vidas--;
        AtualizarTextoVidas();

        if (vidas <= 0)
        {
            GameOver();
        }
    }

    void AtualizarTextoVidas()
    {
        vidasTexto.text = "Vidas: " + vidas;
    }

    void GameOver()
    {
        jogoAcabou = true;
        gameOverTela.SetActive(true);
    }

    void VencerJogo()
    {
        jogoAcabou = true;
        vitoriaTela.SetActive(true);
    }
}
