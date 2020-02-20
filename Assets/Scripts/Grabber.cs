using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Completed
{
    public class Grabber : MovingObject
    {
        Rigidbody2D rigid;

        public string horizontalControl = "P1RightHorizontal";
        public string verticalControl = "P1RightVertical";
        public string actionControl = "leftBumper";
        private float xInput, yInput, lastX, lastY;

        //Start overrides the Start function of MovingObject
        protected override void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
            base.Start();
        }



        private void Update()
        {


            int horizontal = 0;     //Used to store the horizontal move direction.
            int vertical = 0;		//Used to store the vertical move direction.
            float joyStickHorizontal = 0;     //Used to store the horizontal move direction.
            float joyStickVertical = 0;       //Used to store the vertical move direction.
            bool action = false;

            //Get input from the input manager, round it to an integer and store in horizontal to set x axis move direction
            joyStickHorizontal = Input.GetAxisRaw(horizontalControl);

            //Get input from the input manager, round it to an integer and store in vertical to set y axis move direction
            joyStickVertical = Input.GetAxisRaw(verticalControl);

            // If 1, then action button is pressed
            action = Input.GetButtonDown(actionControl);

            if (joyStickHorizontal < -0.15)
            {
                horizontal = -1;
            }
            else if (joyStickHorizontal > 0.15)
            {
                horizontal = 1;
            }

            if (joyStickVertical < -0.15)
            {
                vertical = -1;
            }
            else if (joyStickVertical > 0.15)
            {
                vertical = 1;
            }

            //Check if moving horizontally, if so set vertical to zero.
            if (horizontal != 0)
            {
                vertical = 0;
            }

            //Check if we have a non-zero value for horizontal or vertical
            if (horizontal != 0 || vertical != 0)
            {
                // If the joystick is between two directions
                if (horizontal != 0 && vertical != 0)
                {
                    if (joyStickHorizontal > joyStickVertical)
                    {
                        vertical = 0;
                    }
                    else
                    {
                        horizontal = 0;
                    }
                }

                //Call AttemptMove passing in the generic parameter Wall, since that is what Player may interact with if they encounter one (by attacking it)
                //Pass in horizontal and vertical as parameters to specify the direction to move Player in.
                AttemptMove<Wall>(horizontal, vertical);
            }

            if (action)
            {
                Ability();
            }
        }

        //AttemptMove overrides the AttemptMove function in the base class MovingObject
        //AttemptMove takes a generic parameter T which for Player will be of the type Wall, it also takes integers for x and y direction to move in.
        //Return true means player is able to move, false means player can't move
        protected override bool AttemptMove<T>(int xDir, int yDir)
        {

            //Call the AttemptMove method of the base class, passing in the component T (in this case Wall) and x and y direction to move.
            if (!base.AttemptMove<T>(xDir, yDir))
            {
                return true;
            }

            //Hit allows us to reference the result of the Linecast done in Move.
            RaycastHit2D hit;

            //If Move returns true, meaning Player was able to move into an empty space.
            if (Move(xDir, yDir, out hit))
            {

            }


            //Set the playersTurn boolean of GameManager to false now that players turn is over.
            GameManager.instance.playersTurn = false;
            return false;
        }
        //OnCantMove overrides the abstract function OnCantMove in MovingObject.
        //It takes a generic parameter T which in the case of Player is a Wall which the player can attack and destroy.
        protected override void OnCantMove<T>(T component)
        {

        }

        protected override void Ability()
        {

        }
    }
}