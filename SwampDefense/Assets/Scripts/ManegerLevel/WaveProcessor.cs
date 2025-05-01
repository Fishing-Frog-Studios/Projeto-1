using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveProcessor : MonoBehaviour
{
    public Button waveButton;    // Referência ao botão da UI

    private int waveAtual = 0;
    private bool processandoWave = false;

    private void Start()
    {
        waveButton.onClick.AddListener(IniciarProximaWave); // Conecta o botão à função
        waveButton.gameObject.SetActive(true); // Mostra o botão no início
    }

    public void IniciarProximaWave()
    {
        if (!processandoWave)
        {
            waveButton.gameObject.SetActive(false); // Esconde o botão durante a wave
            StartCoroutine(ProcessarWaveAtual());
        }
    }

    private IEnumerator ProcessarWaveAtual()
    {
        List<Tabela> waves = WavesConfig.main.waves;

        if (waveAtual >= waves.Count)
        {
            yield break;
        }

        processandoWave = true;
        Tabela wave = waves[waveAtual];


        foreach (var entry in wave.enemyList)
        {
            if (entry.enemy == null)
            {
                continue;
            }

            for (int j = 0; j < entry.quantity; j++)
            {
                Instantiate(entry.enemy, RoadEnemy.main.start.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(wave.spawnDelay);
            }

        }

        
        waveAtual++;
        processandoWave = false;

        if (waveAtual < waves.Count)
        {
            waveButton.gameObject.SetActive(true); // Mostra o botão novamente
        }
        else
        {
           
        }
    }
}

