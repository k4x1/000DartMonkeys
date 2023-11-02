using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrack : Tower
{
    public enum BarrackType { type_cactus, type_potato, type_cucumber};
    public int ProductionRate = 0;
    public BarrackType Type;
    public void CreatePlantFactory(){
        
    }
}
