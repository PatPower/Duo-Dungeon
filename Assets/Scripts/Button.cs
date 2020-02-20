using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Completed
{
    public class Button : ActionObject
    {
        public GameObject actionObj;
        public Sprite pressed;
        private Sprite defaultSprite;
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            spriteRend = GetComponent<SpriteRenderer>();
            defaultSprite = spriteRend.sprite;
            callerObj = this.gameObject;
        }

        public override void Activate(GameObject caller)
        {
            if (frozen)
            {
                return;
            }
            ActionObject actionObjScript = actionObj.GetComponent<ActionObject>();
            actionObjScript.Activate(this.gameObject);
            spriteRend.sprite = pressed;
        }

        public override void Deactivate()
        {
            if (frozen)
            {
                return;
            }
            ActionObject actionObjScript = actionObj.GetComponent<ActionObject>();
            actionObjScript.Deactivate();
            spriteRend.sprite = defaultSprite;
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Activate(this.gameObject);
            isActive = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            Deactivate();
            isActive = false;
        }
    }
}