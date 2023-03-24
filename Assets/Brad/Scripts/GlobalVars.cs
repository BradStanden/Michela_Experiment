using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{


    public static string UID;
    public static string Age;
    public static string Sex;
    public static string whatType;
    public static int triggerCode;
    public static string Target;
    public static bool TargetHit;
    public static bool Success;
    public static float baselineDuration;
    public static string currentBlock;
    public static string currentLevel;
    public static string currentCondition;
    public static string currentVersion;

    public static string[,] setupData;
    public static string[,] variableData;
    public static int index;

    public static bool inTrial;

    public static GameObject selectedObject;

    public static Color TargetHitColor;
    public static Color NoHitColor;

    public static float totalScore;
    public static float highScore;
    public static float secondHighScore;

    ///VideoRoom
    public static List<string> conditionList;

    ///SAM
    public static string Score;

    //PANAS
    public static string relaxed;
    public static string sad;
    public static string calm;
    public static string afraid;
    public static string happy;
    public static string angry;
    public static string joyful;
    public static string hostile;
    public static string scared;
    public static string downhearted;


    //memory
    public static int condition;
    public static int count;

    public static Color cBox1;
    public static Color cBox2;
    public static Color cBox3;
    public static Color cBox4;
    public static Color cBox5;
    public static Color cBox6;
    public static Color cBox7;
    public static Color cBox8;
    public static Color cBox9;

    public static int xTrials;
    public static int xType;
    public static bool xCorrect;
    public static float xRT;


    ///AIT
    public static float totalRT;
    public static float congRT;
    public static float incongRT;
    public static float imiError;
    public static float correctCount;
    public static float trialDuration;

}
