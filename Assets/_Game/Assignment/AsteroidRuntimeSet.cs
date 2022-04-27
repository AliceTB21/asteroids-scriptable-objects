using Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AsteroidRuntimeSet : ScriptableObject
{
    [SerializeField] private Dictionary<int, Asteroid> _asteroids = new Dictionary<int, Asteroid>();

    private void Awake()
    {
        Clear();
    }

    public void Add(int asteroidID, Asteroid asteroidToAdd)
    {
        _asteroids.Add(asteroidID, asteroidToAdd);
    }

    public void Remove(int asteroidID)
    {
        _asteroids.Remove(asteroidID);
    }

    public Asteroid Get(int id)
    {
        return _asteroids[id];
    }

    private void Clear()
    {
        _asteroids = new Dictionary<int, Asteroid>();
    }
}
