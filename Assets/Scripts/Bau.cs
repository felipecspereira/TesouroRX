using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bau : MonoBehaviour
{

    [Header("Baú Settings")]
    [SerializeField] private bool coletavel;
    [SerializeField] private GameObject ItemColetavel;
    [SerializeField] private Transform tampa;
    [SerializeField] private float velocidadeAbertura = 2f;
    [SerializeField] private GameObject textoInteração;

    private bool bauAberto = false;
    private bool playerPerto = false;
    private int alternar = 0; 

    private Quaternion posicaoAberta;
    private Quaternion posicaoFechada;

    void Start()
    {
        textoInteração.SetActive(false);
        posicaoAberta = Quaternion.Euler(-200f, 0f, 0f);
        posicaoFechada = Quaternion.Euler(-90f, 0f, 0f);
    }



    void Update()
    {
        if (playerPerto && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("Tecla E foi pressionada");
            alternar++;
            if (alternar == 1)
            {
                bauAberto = true;
                textoInteração.SetActive(false);

                if (coletavel)
                {
                    Instantiate(ItemColetavel, transform.position + Vector3.up, Quaternion.Euler(-90f, 0f, 0f)  );
                }
                
            }
            else
            {
                bauAberto = false;
                alternar = 0;
                textoInteração.SetActive(false);
            }
        }
        
        if (bauAberto)
        {
            tampa.localRotation = Quaternion.Lerp(tampa.localRotation, posicaoAberta, velocidadeAbertura * Time.deltaTime);
        }
        else
        {
            tampa.localRotation = Quaternion.Lerp(tampa.localRotation, posicaoFechada, velocidadeAbertura * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textoInteração.SetActive(true);
            playerPerto = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textoInteração.SetActive(false);
            playerPerto = false;
        }
    }

}
