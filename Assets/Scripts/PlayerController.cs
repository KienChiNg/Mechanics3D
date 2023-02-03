using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    [SerializeField] private float speed;
    [SerializeField] private GameObject powerupIndicator;
    private bool hasPowerup = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed);
        powerupIndicator.transform.position = transform.position - new Vector3(0,0.5f,0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gem")){
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCountDownRoutine());
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy") && hasPowerup){
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (other.gameObject.transform.position - transform.position);
            enemyRb.AddForce(awayFromPlayer*1.5f,ForceMode.Impulse);
        }
    }
    IEnumerator PowerupCountDownRoutine(){
        yield return new WaitForSeconds(3);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }
}
