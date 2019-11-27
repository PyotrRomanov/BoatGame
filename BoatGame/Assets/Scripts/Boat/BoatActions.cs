using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

/**
InControl keybinding class. Ensures both keyboard and controller can be used without needing to switch in a menu.
Keyboard option remains for testing purposes, but is not recommended as keyboards often have a limit of keys that can be pressed concurrently.
**/
public class BoatActions : PlayerActionSet
{
    public PlayerAction RightPaddleUp;
    public PlayerAction RightPaddleDown;
    public PlayerAction RightPaddleUnsubmerge;

    public PlayerOneAxisAction RightPaddleMove;

    public PlayerAction LeftPaddleUp;
    public PlayerAction LeftPaddleDown;
    public PlayerAction LeftPaddleUnsubmerge;

    public PlayerOneAxisAction LeftPaddleMove;

    public PlayerAction StartGame;

    public BoatActions()
    {
        RightPaddleUp = CreatePlayerAction("Right Paddle Up");
        RightPaddleDown = CreatePlayerAction("Right Paddle Down");
        RightPaddleUnsubmerge = CreatePlayerAction("Right Paddle Unsubmerge");

        LeftPaddleUp = CreatePlayerAction("Left Paddle Up");
        LeftPaddleDown = CreatePlayerAction("Left Paddle Down");
        LeftPaddleUnsubmerge = CreatePlayerAction("Left Paddle Unsubmerge");

        RightPaddleMove = CreateOneAxisPlayerAction(RightPaddleUp, RightPaddleDown);
        LeftPaddleMove = CreateOneAxisPlayerAction(LeftPaddleUp, LeftPaddleDown);

        StartGame = CreatePlayerAction("Start Game");
    }
}
