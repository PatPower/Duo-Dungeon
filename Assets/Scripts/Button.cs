using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Completed
{
    public class Button : MonoBehaviour
    {
        public GameObject actionObj;
        public Sprite pressed;
        private Sprite defaultSprite;
        private SpriteRenderer spriteRend;
        // Start is called before the first frame update
        void Start()
        {
            spriteRend = GetComponent<SpriteRenderer>();
            defaultSprite = spriteRend.sprite;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            ActionObject actionObjScript = actionObj.GetComponent<ActionObject>();
            actionObjScript.Activate();
            spriteRend.sprite = pressed;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            ActionObject actionObjScript = actionObj.GetComponent<ActionObject>();
            actionObjScript.Deactivate();
            spriteRend.sprite = defaultSprite;
        }
    }
}