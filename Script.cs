using UnityEngine;

public class MovimentoGiocatore : MonoBehaviour
{
    [SerializeField] private float velocitaAvanti = 5f;
    [SerializeField] private float velocitaLaterale = 3f;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform posizioneIstanziazione;

    private Vector3 direzione;
    private Rigidbody rb;

    private void Awake()
    {
        Debug.Log("Awake chiamato");
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable chiamato");
    }

    private void Start()
    {
        Debug.Log("Start chiamato");
    }

    private void Update()
    {
        Debug.Log("Update chiamato");

        float orizzontale = Input.GetAxis("Horizontal");
        float verticale = Input.GetAxis("Vertical");
        direzione = new Vector3(orizzontale, 0f, verticale);

        Debug.Log("transform.position: " + transform.position);
        Debug.Log("transform.localPosition: " + transform.localPosition);

        if (Input.GetKeyDown(KeyCode.I))
        {
            IstanziaPrefab();
        }
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate chiamato");

        Vector3 movimentoAvanti = transform.forward * direzione.z * velocitaAvanti * Time.fixedDeltaTime;
        transform.Translate(movimentoAvanti, Space.World);

        Vector3 movimentoLaterale = transform.right * direzione.x * velocitaLaterale * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movimentoLaterale);
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable chiamato");
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy chiamato");
    }

    private void IstanziaPrefab()
    {
        if (prefab != null && posizioneIstanziazione != null)
        {
            Instantiate(prefab, posizioneIstanziazione.position, posizioneIstanziazione.rotation);
            Debug.Log("Prefab istanziato");
        }
        else
        {
            Debug.LogWarning("Prefab o posizione di istanziazione non assegnati!");
        }
    }
}
