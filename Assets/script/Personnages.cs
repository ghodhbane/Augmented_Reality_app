using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personnages : MonoBehaviour
{

    // Use this for initialization

    Transform var; // varible membre 
    public Renderer rend;
    public Color orange = new Color(128, 128, 128);
    public Animator animations;

    void Start()
    {

        MyDefaultHandler[] trackableEvents = FindObjectsOfType<MyDefaultHandler>(); // récuprer tout les Object types
        foreach (MyDefaultHandler trackEvent in trackableEvents)
        {
            trackEvent.AddOnTrackerFound(bonjour);

            trackEvent.AddOnTrackerLost(aurevoir);


        }

        //rend = GetComponent<Renderer>();   // recuperer le render du personnage 
        // maintenant pas besoin de ce appel, vu que le render devien public 
    }

    // Update is called once per frame
    void Update()
    {

        if (var != null)
        {
            Debug.Log("La dernière position est" + var.position);
            //  transform.position = var.position   ; // c'est le transform de gameobject sur lequel a été appliquer ce script 
            Vector3 direction = var.position - transform.position; // la direction = destination - position acctuelle 
            direction.Normalize(); // la manigtude = 1 ; quelque soit la distance, la vitesse 
            float dist = Vector3.Distance(var.position, transform.position);
            transform.LookAt(var); // regarde projeter vers la destination 


            if (dist > 0.1)  // si la distance entre la personnage et le tag > 0.15, on stabilise 
            {
                transform.LookAt(var.position); // regarde projeter vers la destination 
                                       //transform.Translate(direction * Time.deltaTime, Space.World); // on agir sur la fonction Translate du transform du personnage
                transform.Translate(transform.forward * Time.deltaTime, Space.World);

                // rend.material.color = orange;  // changer la couleur de tout le cops du cube
                rend.materials[1].color = orange; // changer la couleur des yeux 
                animations.SetBool("ismoving", true); // affecter la valeur true à "ismoving" pour rendre cette action valide, et donc moving

            }
            else
            {
//                rend.material.color = Color.green;
                rend.materials[1].color = Color.green;
                animations.SetBool("ismoving", false); // affecter la valeur false à "ismoving" pour rendre cette action invalide, et donc stop mosing 


            }
        }

        else
        {
            //rend.material.color = Color.red;
            rend.materials[1].color = Color.red; 

        }



    }

    void bonjour(Transform trakeposB)
    {  // "Transform" pour récuperer 


        Debug.Log("Bonjour");
        Debug.Log("J'ai trouvé le cube avec le tag" + trakeposB);
        var = trakeposB;


    }

    void aurevoir(Transform trakposA)
    {
        Debug.Log("Aurevoir");
        Debug.Log("J'ai perdu le cube avec le tag" + trakposA);
        if (var == trakposA)
            var = null;

    }



}
