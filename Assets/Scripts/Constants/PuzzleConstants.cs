using System.Collections.Generic;
using UnityEngine;

namespace Constants
{
    public abstract class PuzzleConstants
    {
        public static readonly Vector3[][] heroFormations =
        {
            Formation1.heroPositions,
            Formation2.heroPositions,
            Formation3.heroPositions,
            Formation4.heroPositions,
            Formation5.heroPositions,
        };
    }
    
    public abstract class PuzzleBossConstants
    {
        public static readonly Vector3[][] heroFormations =
        {
            BossFormation1.heroPositions,
            BossFormation2.heroPositions,
            BossFormation3.heroPositions,
            BossFormation4.heroPositions,
        };
    }

    
    public abstract class Formation5
    {
        public static readonly Vector3[] heroPositions =
        {
            new Vector3(-3.6f, 1.8f, 129),
            new Vector3(-2f, 1.8f, 125.5f),
            new Vector3(0, 1.8f, 122),
            new Vector3(2f, 1.8f, 125.5f),
            new Vector3(3.6f, 1.8f, 129),
        };
    }
    
    
    public abstract class Formation4 
    {
        public static readonly Vector3[] heroPositions =
        {
            new Vector3(-3.6f, 1.8f, 122),
            new Vector3(-1.3f, 1.8f, 126),
            new Vector3(1.3f, 1.8f, 126),
            new Vector3(3.6f, 1.8f, 122),
        };
    }
    
    public abstract class Formation3 
    {
        public static readonly Vector3[] heroPositions =
        {
            new Vector3(-3f, 1.8f, 124),
            new Vector3(0f, 1.8f, 127),
            new Vector3(3f, 1.8f, 124),
        };
    }
    public abstract class Formation2 
    {
        public static readonly Vector3[] heroPositions =
        {
            new Vector3(-1.75f, 1.8f, 124),
            new Vector3(1.75f, 1.8f, 124),
        };
    }
    
    public abstract class Formation1
    {
        public static readonly Vector3[] heroPositions =
        {
            new Vector3(0f, 1.8f, 122),
        };
    }
    
    
    public abstract class BossFormation4
    {
        public static readonly Vector3[] heroPositions =
        {
            new Vector3(-3.6f, 1.8f, 122),
            new Vector3(-1.3f, 3f, 124),
            new Vector3(1.3f, 3f, 124),
            new Vector3(3.6f, 1.8f, 122),
        };
    }
    
    public abstract class BossFormation3 
    {
        public static readonly Vector3[] heroPositions =
        {
            new Vector3(-3.5f, 1.8f, 122),
            new Vector3(0f, 3f, 124),
            new Vector3(3.5f, 1.8f, 122),
        };
    }
    
    public abstract class BossFormation2 
    {
        public static readonly Vector3[] heroPositions =
        {
            new Vector3(-2f, 3f, 122),
            new Vector3(2f, 3f, 122),
        };
    }
    
    public abstract class BossFormation1
    {
        public static readonly Vector3[] heroPositions =
        {
            new Vector3(0f, 3f, 123),
        };
    }
    
}