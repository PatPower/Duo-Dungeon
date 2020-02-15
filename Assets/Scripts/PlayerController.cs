using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Completed
{
    public class PlayerController : MovingObject
    {
        public float moveSpeed;
        Rigidbody2D rigid;

        public bool controls = true;
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
            //If it's not the player's turn, exit the function.
            if (!GameManager.instance.playersTurn) return;

            int horizontal = 0;     //Used to store the horizontal move direction.
            int vertical = 0;		//Used to store the vertical move direction.

            //Get input from the input manager, round it to an integer and store in horizontal to set x axis move direction
            horizontal = (int)(Input.GetAxisRaw("Horizontal"));

            //Get input from the input manager, round it to an integer and store in vertical to set y axis move direction
            vertical = (int)(Input.GetAxisRaw("Vertical"));

            //Check if moving horizontally, if so set vertical to zero.
            if (horizontal != 0)
            {
                vertical = 0;
            }

            //Check if we have a non-zero value for horizontal or vertical
            if (horizontal != 0 || vertical != 0)
            {
                //Call AttemptMove passing in the generic parameter Wall, since that is what Player may interact with if they encounter one (by attacking it)
                //Pass in horizontal and vertical as parameters to specify the direction to move Player in.
                AttemptMove<Wall>(horizontal, vertical);
            }


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

            if (Input.GetButtonDown("Interact"))
            {

            }
        }
        //AttemptMove overrides the AttemptMove function in the base class MovingObject
        //AttemptMove takes a generic parameter T which for Player will be of the type Wall, it also takes integers for x and y direction to move in.
        protected override void AttemptMove<T>(int xDir, int yDir)
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