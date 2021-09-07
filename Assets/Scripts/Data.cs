using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data {
    
    static float totalTime = 0;

    public static float getTotalTime() {
        return totalTime;
    }

    public static void addToTotal(float a) {
        totalTime += a;
    }

    public static void resetTotalTime() {
        totalTime = 0;
    }
}
