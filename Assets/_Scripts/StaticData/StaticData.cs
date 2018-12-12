using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData {

	private static int playerHealth = 3;
	private static string gameState = "running";
	private static int currentAge = 1;
    private static int bufferAge = 0;
    private static bool stopScroll = false;

	private static GameObject frozenObject1;
	private static GameObject frozenObject2;


	public static int PlayerHealth {
		get {
			return playerHealth;
		}
		set {
			playerHealth = value;
		}
	}

	public static string GameState {
		get {
			return gameState;
		}
		set {
			gameState = value;
		}
	}

	public static int CurrentAge{
		get{
			return currentAge;
		}
		set{
			currentAge = value;
		}
	}

    public static int BufferAge{
        get{
            return bufferAge;
        }
        set{
            if (value > bufferAge) {
                if (value > 20) {
                    value = 0;
                    currentAge += 1;
                    stopScroll = true;
                    bufferAge = 0;
                }
                else if (value > 0 && currentAge == 3) {
                    bufferAge = 0;
                }
                else {
                    bufferAge = value;
                }
            }
            else if (value < bufferAge) {
                if (value < -20) {
                    value = 0;
                    currentAge -= 1;
                    stopScroll = true;
                    bufferAge = 0;
                }
                else if (value < 0 && currentAge == 1) {
                    bufferAge = 0;
                }
                else {
                    bufferAge = value;
                }
            }
        } 
    }

    public static bool StopScroll{
        get {
            return stopScroll;
        }
        set {
            stopScroll = value;
        }
    }

	public static GameObject FrozenObjectOne{
		get{
			return frozenObject1;
		}
		set{
			frozenObject1 = value;
		}
	}

	public static GameObject FrozenObjectTwo {
		get {
			return frozenObject2;
		}
		set {
			frozenObject2 = value;
		}
	}
}


