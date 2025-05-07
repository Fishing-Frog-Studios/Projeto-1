using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveProcessor : MonoBehaviour
{


    public Button waveButton;    // Refer�ncia ao bot�o da UI

    private bool processandoWave = false;

    private void Start()
    {
        waveButton.onClick.AddListener(IniciarProximaWave); // Conecta o bot�o � fun��o
        waveButton.gameObject.SetActive(true); // Mostra o bot�o no in�cio
    }

    public void IniciarProximaWave()
    {
        if (!processandoWave)
        {
            waveButton.gameObject.SetActive(false); // Esconde o bot�o durante a wave
            StartCoroutine(ProcessarWaveAtual());
        }
    }

    private IEnumerator ProcessarWaveAtual()
    {
        List<Tabela> waves = WavesConfig.main.waves;

        if (WavesConfig.main.waveAtual >= waves.Count)
        {
            yield break;
        }

        processandoWave = true;
        Tabela wave = waves[WavesConfig.main.waveAtual];

        

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


        WavesConfig.main.waveAtual++;
        processandoWave = false;

        if (WavesConfig.main.waveAtual < waves.Count)
        {
            waveButton.gameObject.SetActive(true); // Mostra o bot�o novamente
        }
        else
        {
           
        }
    }
}

