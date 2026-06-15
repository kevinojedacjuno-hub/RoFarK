using UnityEngine;
using System.Collections; // necesario para corrutinas
//bolita - recurso
//bolita - regenerar
//bolita - dubplicar
//bolita - tiempo de spawn

public class BolitaRecurso : MonoBehaviour
{
    [SerializeField] private GameObject bolaPrefab; // Prefab de la bola
    [SerializeField] private float delay = 10f;     // Tiempo de espera en segundos
    [SerializeField] private string sueloTag = "Suelo"; // Tag del suelo

    private void OnCollisionEnter(Collision collision)
    {
        // Si la bolita toca el suelo
        if (collision.gameObject.CompareTag(sueloTag))
        {
            StartCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        // Espera el tiempo definido
        yield return new WaitForSeconds(delay);

        // Instancia una nueva bola en la misma posición
        Instantiate(bolaPrefab, transform.position, Quaternion.identity);

        // Destruye la bola actual (para que no se acumulen infinitamente)
        Destroy(gameObject);
    }
}