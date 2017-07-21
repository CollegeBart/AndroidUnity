using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dispatcher : MonoBehaviour
{

    private List<Action> queue;
    private List<Action> dequeue;


	void Start ()
    {
        queue = new List<Action>();
        dequeue = new List<Action>();
	}
	

	void Update ()
    {
	    lock (queue)
        {
            dequeue.AddRange(queue);
            queue.Clear();
        }

        for(int i = 0, size = dequeue.Count; i<size; ++i)
        {
            try
            {
                dequeue[i]();
            }
            finally { }
        }
        dequeue.Clear();
	}

    public void Dispatch(Action act)
    {
        lock(queue)
        {
            queue.Add(act);
        }
    }
}
