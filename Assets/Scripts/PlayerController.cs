using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Completed
{
    public class PlayerController : MovingObject
    {
        Rigidbody2D rigid;

        public bool controls = true;
        public string horizontal = "P1RightHorizontal";
        public string vertical = "P1RightVertical";
        private float xInput, yInput, lastX, lastY;
        private static bool playerExists;



        //Start overrides the Start function of MovingObject
        protected override void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
            base.Start();
        }



        // Update is called once per frame
        void Update()
        {

            float xAxis = Input.GetAxisRaw(horizontal);
            float yAxis = Input.GetAxisRaw(vertical);

            bool isMoving = (xAxis != 0 || yAxis != 0);

            // Movement
            if (isMoving)
            {
                var moveVector = new Vector3(xAxis, yAxis, 0);
                rigid.MovePosition(new Vector2((transform.position.x + moveVector.x * moveSpeed * Time.deltaTime),
                       transform.position.y + moveVector.y * moveSpeed * Time.deltaTime));
            }

            /**else if (gamePadHorizontal != 0 || gamePadVertical != 0)
            {
                //Call AttemptMove passing in the generic parameter Wall, since that is what Player may interact with if they encounter one (by attacking it)
                //Pass in horizontal and vertical as parameters to specify the direction to move Player in.
                AttemptMove<Wall>(gamePadHorizontal, gamePadVertical);
            }
            */
            // Animations
            if (Input.GetAxisRaw("Horizontal") > 0)
            {


            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {


            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {

            }
            else if (Input.GetAxisRaw("Vertical") > 0)
            {

            }
            else
            {

            }
        }
        //AttemptMove overrides the AttemptMove function in the base class MovingObject
        //AttemptMove takes a generic parameter T which for Player will be of the type Wall, it also takes integers for x and y direction to move in.
        protected override void AttemptMove<T>(float xDir, float yDir)
        {

            //Call the AttemptMove method of the base class, passing in the component T (in this case Wall) and x and y direction to move.
            base.AttemptMove<T>(xDir, yDir);

            //Hit allows us to reference the result of the Linecast done in Move.
            RaycastHit2D hit;

            //If Move returns true, meaning Player was able to move into an empty space.
            if (Move(xDir, yDir, out hit))
            {

            }


            //Set the playersTurn boolean of GameManager to false now that players turn is over.
            GameManager.instance.playersTurn = false;
        }
        //OnCantMove overrides the abstract function OnCantMove in MovingObject.
        //It takes a generic parameter T which in the case of Player is a Wall which the player can attack and destroy.
        protected override void OnCantMove<T>(T component)
        {

        }
    }

}