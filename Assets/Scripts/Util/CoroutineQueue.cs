using System;

using System.Collections;

using System.Collections.Generic;

using UnityEngine;



/// <Usage>

/// 

/// Create Instance : 

/// var queue = new CoroutineQueue(2, StartCoroutine);

/// 

/// Run Instance : 

/// queue.Run(TestCoroutineMethod(params));

/// 

/// </Usage>

public class CoroutineQueue

{

    // Maximum number of coroutines to run at once
    private readonly uint maxActive;
    // Delegate to start coroutines with
    private readonly Func<IEnumerator, Coroutine> coroutineStarter;

    // Queue of coroutines waiting to start
    private readonly Queue<IEnumerator> queue;

    // Number of currently active coroutines
    private uint numActive;



    /// <summary>
    /// Create the queue, initially with no coroutines
    /// </summary>

    /// <param name="maxActive"> Maximum number of coroutines to run at once. This must be at least one. </param>

    /// <param name="coroutineStarter"> Delegate to start coroutines with. Normally you'd pass </param>
    /// <exception cref="ArgumentException"> If maxActive is Zero. </exception>

    public CoroutineQueue(uint maxActive, Func<IEnumerator, Coroutine> coroutineStarter)

    {

        if (maxActive == 0) { throw new ArgumentException("Must be at least one", "maxActive"); }
        
        this.maxActive = maxActive;

        this.coroutineStarter = coroutineStarter;

        this.queue = new Queue<IEnumerator>();

    }



    /// <summary>

    /// If the number of active coroutines is under the limit specified in the constructor, run the

    /// given coroutine. Otherwise, queue it to be run when other coroutines finish.

    /// </summary>

    /// <param name="coroutine"></param>

    public void Run(IEnumerator coroutine)

    {
        if (numActive < maxActive)
        {
            IEnumerator runner = CoroutineRunner(coroutine);
            coroutineStarter(runner);
        }
        
        else
        {
            queue.Enqueue(coroutine);
        }
    }



    /// <summary>

    /// Runs a coroutine then runs the next queued coroutine (via <see cref="Run"/>) if available.

    /// Increments <see cref="numActive"/> before running the coroutine and decrements it after.

    /// </summary>

    /// <param name="coroutine"> Coroutine to run </param>

    /// <returns> Values yielded by the given coroutine </returns> 

    private IEnumerator CoroutineRunner(IEnumerator coroutine)

    {
        numActive++;
        while (coroutine.MoveNext())
        {
            yield return coroutine.Current;
        }
        numActive--;
        if (queue.Count > 0)
        {

            IEnumerator next = queue.Dequeue();
            Run(next);

        }
    }
}


