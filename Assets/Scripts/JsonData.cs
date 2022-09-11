using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class JsonData
{

    public PlayerData player_data; //{ get; set; }
    public PulpitData pulpit_data; //{ get; set; }
}

[System.Serializable]
public class PlayerData
{
    public int speed;// { get; set; }
}

[System.Serializable]
public class PulpitData
{
    public int min_pulpit_destroy_time;//{ get; set; }
    public int max_pulpit_destroy_time;// { get; set; }
    public double pulpit_spawn_time;// { get; set; }
}





