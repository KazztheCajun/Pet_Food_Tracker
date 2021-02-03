using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDGenerator {

    private static int count = 0000000;
    
    public int GetNewID() {
    	count++;
        return count;
    }
}
