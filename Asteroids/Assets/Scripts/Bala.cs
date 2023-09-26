using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bala : MonoBehaviour
{
int speed = 10;
 float maxLifeTime = 3;
 public Vector3 targetVector;
 void Start()
 {
 // nada más nacer, le damos unos segundos de vida,
 // lo suficiente para salir de la pantalla
 Destroy(gameObject, maxLifeTime);
 }
 void Update()
 {
 // la bala se mueve en la dirección del jugador al disparar
 transform.Translate(targetVector * speed * Time.deltaTime);
 }

 private void OnTriggerEnter(Collider other)
 {
 if (other.gameObject.CompareTag("Enemy")){
    IncreaseScore();
     Destroy(other.gameObject);
    Destroy(gameObject);
 }
 }

 private void IncreaseScore(){
    Jugador.SCORE++;
    UpdateScoreText();
 }

 private void UpdateScoreText(){
    GameObject go = GameObject.FindGameObjectWithTag("UI");
    go.GetComponent<Text>().text="Puntos: " + Jugador.SCORE;
 }

}
