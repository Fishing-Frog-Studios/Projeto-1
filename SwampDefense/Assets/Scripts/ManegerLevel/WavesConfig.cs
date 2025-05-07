using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveEntry
{
    [Tooltip("Prefab do inimigo.")]
    public GameObject enemy;

    [Tooltip("Quantidade deste inimigo na onda.")]
    public int quantity;
}

[System.Serializable]
public class Tabela
{
    [Tooltip("Entradas de inimigos desta onda.")]
    public List<WaveEntry> enemyList;

    [Tooltip("Multiplicador de força para esta onda.")]
    public float boost = 1f;
    public float spawnDelay = 0.4f;
}

public class WavesConfig : MonoBehaviour
{

    public static WavesConfig main;
    public int waveAtual = 0;
    [Header("Configuração de Ondas")]
    [Tooltip("Lista de das ondas da partida.")]
    public List<Tabela> waves;

    private void Awake()
    {
        main = this;
    }
}