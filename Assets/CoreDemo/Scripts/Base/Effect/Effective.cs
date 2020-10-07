using System.Collections;
using System.Collections.Generic;
using Core.Character;
using UnityEngine;

namespace Core
{
  public abstract class Effective : MonoBehaviour
  {
    public Collider2D col;
    protected List<GameObject> effectedObjects = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D other)
    {

      GameObject gameObject = other.gameObject;
      if (effectedObjects.Exists(x => x.name == gameObject.name) == false)
      {
        processObjectEnter(gameObject);
        effectedObjects.Add(gameObject);
      }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
      GameObject gameObject = other.gameObject;
      processObjectExit(gameObject);
      effectedObjects.Remove(gameObject);
    }

    private void OnTriggerStay2D()
    {
      processObjectUpdate();
    }

    protected abstract void processObjectEnter(GameObject gameObject);

    protected abstract void processObjectExit(GameObject gameObject);

    protected abstract void processObjectUpdate();
  }
}