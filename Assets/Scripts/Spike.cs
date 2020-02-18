using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Completed
{
    public class Spike : ActionObject
    {
        List<GameObject> onSpike = new List<GameObject>();
        public Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public override void Activate()
        {
            // Print the entire list to the console.
            foreach (GameObject gObject in onSpike)
            {
                print(gObject.name);
            }
            this.gameObject.layer = LayerMask.NameToLayer("BlockingLayer");
            anim.SetBool("SpikeUp", true);
        }

        public override void Deactivate()
        {
            // Print the entire list to the console.
            foreach (GameObject gObject in onSpike)
            {
                print(gObject.name);
            }
            this.gameObject.layer = LayerMask.NameToLayer("Default");
            anim.SetBool("SpikeUp", false);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                onSpike.Add(collision.gameObject);
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                onSpike.Remove(collision.gameObject);
            }
        }
    }
}