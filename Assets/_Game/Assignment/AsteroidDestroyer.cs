using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{    
    public class AsteroidDestroyer : MonoBehaviour
    {
        [SerializeField] Asteroid asteroidPrefab;

       [SerializeField] private AsteroidRuntimeSet _asteroids;

        public void OnAsteroidHitByLaser(int asteroidId)
        {
            Asteroid asteroid = _asteroids.Get(asteroidId);
            float asteroidSize = _asteroids.Get(asteroidId).GetScale;

            if (asteroid.GetScale <= 0.5f)
            {

            }
            else
            {
                if(asteroid.GetScale == 1)
                {
                    for(int i = 0; i < 1; i++)
                    {
                        SpawnNewAsteroid(asteroid, asteroidSize);
                    }
                }
                SpawnNewAsteroid(asteroid, asteroidSize);
            }

            Destroy(asteroid);
        }

        private void SpawnNewAsteroid(Asteroid asteroid, float asteroidSize)
        {
            float newSize = asteroidSize / 2;
            Asteroid newAsteroid = Instantiate(asteroidPrefab, asteroid.transform.position, Quaternion.identity);
            newAsteroid.shouldSetStartSize = false;
            if (newSize < 0.3f)
            {
                newSize = 0.3f;
            }

            newAsteroid.SetSize(0.3f, newSize);
            _asteroids.Add(newAsteroid.GetID, newAsteroid);
        }

        public void RegisterAsteroid(Asteroid asteroid)
        {
            _asteroids.Add(asteroid.GetID, asteroid);
        }

        private void DestroyAsteroid(Asteroid asteroid)
        {
            _asteroids.Remove(asteroid.GetID);
        }
    }
}
