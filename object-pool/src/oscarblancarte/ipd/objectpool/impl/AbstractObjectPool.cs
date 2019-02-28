using oscarblancarte.ipd.objectpool.impl.factory;
using oscarblancarte.ipd.objectpool.impl.poolable;
using System; 
using System.Collections.Generic;
using System.Threading;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.objectpool.impl{
    public abstract class AbstractObjectPool<T>  : IObjectPool<T> 
        where T: IPooledObject
    {

        private readonly int MinInstances;
        private readonly int MaxInstances;
        private readonly int WaitTime;

        private readonly IPoolableObjectFactory<T> PoolableObjectFactory;

        private readonly List<PooledObjectStatus<T>> FullStack = new List<PooledObjectStatus<T>>();
        private readonly List<PooledObjectStatus<T>> UseStack = new List<PooledObjectStatus<T>>();
        private readonly Stack<PooledObjectStatus<T>> FreeStack = new Stack<PooledObjectStatus<T>>();

        public AbstractObjectPool(int minInstances, int maxInstances, int waitTime , IPoolableObjectFactory<T> poolableObjectFactory) {
            Console.WriteLine("=========== STARTING ============");
            this.MinInstances = minInstances;
            this.MaxInstances = maxInstances;
            this.WaitTime = waitTime;
            this.PoolableObjectFactory = poolableObjectFactory;
            InitPool();
            Console.WriteLine("=========== FINISH ============");
            Console.WriteLine();
        }

        private void InitPool() {
            for (int c = FullStack.Count ; c < MinInstances; c++) {
                PooledObjectStatus<T> createNewPooledObject = CreateNewPooledObject();
                FreeStack.Push(createNewPooledObject);
            }
        }

        private class PooledObjectStatus<T> {
            public bool Used;
            public Guid Uuid;
            public T PooledObject;

            public PooledObjectStatus(T pooledObject) {
                this.Used = false;
                this.Uuid = System.Guid.NewGuid();
                this.PooledObject = pooledObject;
            }
        }

        private T GetInternalObject()  {
            lock (FreeStack) {
                if (! (FreeStack.Count == 0)) {
                    PooledObjectStatus<T> first = this.FreeStack.Pop();
                    first.Used = true;
                    Console.WriteLine("Provisioning Object > " + first.Uuid.ToString());
                    UseStack.Add(first);
                    return first.PooledObject;
                }
                lock (FullStack) {
                    if (FullStack.Count < MaxInstances) {
                        PooledObjectStatus<T> returnObject = CreateNewPooledObject();
                        returnObject.Used = true;
                        Console.WriteLine("Provisioning Object > " + returnObject.Uuid.ToString());
                        UseStack.Add(returnObject);
                        return returnObject.PooledObject;
                    } else {
                        return default(T);
                    }
                }
            }
        }

        public T GetObject()  {
            T internalObject = GetInternalObject();
            if (internalObject != null) {
                return internalObject;
            }
            return WaitForResource();
        }

        private T WaitForResource()  {
            DateTime future = DateTime.Now.AddMilliseconds(WaitTime);
            do {
                PooledObjectStatus<T> returnObject = null;
                lock (FreeStack) {
                    if (!(FreeStack.Count == 0) && !FreeStack.Peek().Used) {
                        returnObject = FreeStack.Pop();
                        returnObject.Used = true;
                        UseStack.Add(returnObject);
                        Console.WriteLine("Provisioning Object > " + returnObject.Uuid.ToString());
                        return returnObject.PooledObject;
                    }
                }

                if (returnObject == null || returnObject.Used) {
                    long milliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    if (WaitTime != 0 && milliseconds >= future.Millisecond) {
                        throw new PoolException("Tiempo de espera agotado");
                    }
                    try {
                        Thread.Sleep(1000);
                    } catch (Exception e) {
                        Console.WriteLine(e.ToString());
                    }
                }

            } while (true);
        }

        private PooledObjectStatus<T> CreateNewPooledObject() {
            T newObject = PoolableObjectFactory.CreateNew();
            PooledObjectStatus<T> pooled = new PooledObjectStatus<T>(newObject);
            FullStack.Add(pooled);
            Console.WriteLine("New PoolableObject{UUID=" + pooled.Uuid.ToString() + ", poolSize=" + FullStack.Count + "}");
            return pooled;
        }

        public void ReleaceObject(T pooledObject) 
        {
            foreach(PooledObjectStatus<T> item in this.FullStack) {
                if (item.PooledObject.Equals(pooledObject) ) {
                    if (pooledObject.Validate()) {
                        FreeStack.Push(item);
                        UseStack.Remove(item);
                        item.Used = false;
                        Console.WriteLine("Object returned > " + item.Uuid.ToString());
                        return;
                    } else {
                        Console.WriteLine("Object Invalidate ==> " + item.Uuid.ToString());
                        pooledObject.Invalidate();
                        FullStack.Remove(item);
                        UseStack.Remove(item);
                        lock(FreeStack){
                            InitPool();
                        }
                        return;
                    }
                }
            }
        }

        public override String ToString() {
            return "AbstractObjectPool ==> currentSize > '"
                    +FullStack.Count  +"', " + "free > '"
                    +FreeStack.Count +"', used > '"+UseStack.Count+"'";
        }
    }

} 