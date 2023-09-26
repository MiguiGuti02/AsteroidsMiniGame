using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    float thrustForce = 3f;
    float rotationSpeed = 90f;
    Vector2 thrustDirection;
    Rigidbody _rigidbody;
    public static int SCORE = 0;
    public GameObject gun, bulletPrefab;
    public float xBorderLimit, yBorderLimit;
    void Start()
    {
        // rigidbody nos permite aplicar fuerzas en el jugador
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // obtenemos las pulsaciones de teclado
        float rotation = Input.GetAxis("Rotate") * rotationSpeed * Time.deltaTime;
        float thrust = Input.GetAxis("Thrust") * thrustForce;
        // la dirección de empuje por defecto es .right (el eje X positivo)
        thrustDirection = transform.right;
        // rotamos con el eje "Rotate" negativo para que la dirección sea correcta
        transform.Rotate(Vector3.forward, -rotation);
        // añadimos la fuerza capturada arriba a la nave del jugador
        _rigidbody.AddForce(thrust * thrustDirection);
        var newPos =transform.position;
        if (newPos.x>xBorderLimit) newPos.x =-xBorderLimit+1;
        else if (newPos.x<-xBorderLimit+1) newPos.x=xBorderLimit;
        else if (newPos.y>yBorderLimit) newPos.y =-yBorderLimit+1;
        else if (newPos.y<-yBorderLimit+1) newPos.y=yBorderLimit;
        transform.position=newPos;
        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position,Quaternion.identity);
            Bala balaScript = bullet.GetComponent<Bala>();
            balaScript.targetVector=thrustDirection;
        }
 }
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Enemy"){
        SCORE=0;
        SceneManager.LoadScene("SampleScene");
        }
    }
}
