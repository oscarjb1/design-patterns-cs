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

        private readonly int minInstances;
        private readonly int maxInstances;
        private readonly int waitTime;

        private readonly IPoolableObjectFactory<T> poolableObjectFactory;

        private readonly List<PooledObjectStatus<T>> fullStack = new List<PooledObjectStatus<T>>();
        private readonly List<PooledObjectStatus<T>> useStack = new List<PooledObjectStatus<T>>();
        private readonly Stack<PooledObjectStatus<T>> freeStack = new Stack<PooledObjectStatus<T>>();

        public AbstractObjectPool(int minInstances, int maxInstances, int waitTime , IPoolableObjectFactory<T> poolableObjectFactory) {
            Console.WriteLine("=========== STARTING ============");
            this.minInstances = minInstances;
            this.maxInstances = maxInstances;
            this.waitTime = waitTime;
            this.poolableObjectFactory = poolableObjectFactory;
            initPool();
            Console.WriteLine("=========== FINISH ============");
            Console.WriteLine();
        }

        private void initPool() {
            for (int c = fullStack.Count ; c < minInstances; c++) {
                PooledObjectStatus<T> createNewPooledObject = CreateNewPooledObject();
                freeStack.Push(createNewPooledObject);
            }
        }

        private class PooledObjectStatus<T> {
            public bool used;
            public Guid uuid;
            public T pooledObject;

            public PooledObjectStatus(T pooledObject) {
                this.used = false;
                this.uuid = System.Guid.NewGuid();
                this.pooledObject = pooledObject;
            }
        }

        private T getInternalObject()  {
            lock (freeStack) {
                if (! (freeStack.Count == 0)) {
                    PooledObjectStatus<T> first = this.freeStack.Pop();
                    first.used = true;
                    Console.WriteLine("Provisioning Object > " + first.uuid.ToString());
                    useStack.Add(first);
                    return first.pooledObject;
                }
                lock (fullStack) {
                    if (fullStack.Count < maxInstances) {
                        PooledObjectStatus<T> returnObject = CreateNewPooledObject();
                        returnObject.used = true;
                        Console.WriteLine("Provisioning Object > " + returnObject.uuid.ToString());
                        useStack.Add(returnObject);
                        return returnObject.pooledObject;
                    } else {
                        return default(T);
                    }
                }
            }
        }

        public T getObject()  {
            T internalObject = getInternalObject();
            if (internalObject != null) {
                return internalObject;
            }
            return waitForResource();
        }

        private T waitForResource()  {
            DateTime future = DateTime.Now.AddMilliseconds(waitTime);
            do {
                PooledObjectStatus<T> returnObject = null;
                lock (freeStack) {
                    if (!(freeStack.Count == 0) && !freeStack.Peek().used) {
                        returnObject = freeStack.Pop();
                        returnObject.used = true;
                        useStack.Add(returnObject);
                        Console.WriteLine("Provisioning Object > " + returnObject.uuid.ToString());
                        return returnObject.pooledObject;
                    }
                }

                if (returnObject == null || returnObject.used) {
                    long milliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    if (waitTime != 0 && milliseconds
                            >= future.Millisecond) {
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
            T newObject = poolableObjectFactory.createNew();
            PooledObjectStatus<T> pooled = new PooledObjectStatus<T>(newObject);
            fullStack.Add(pooled);
            Console.WriteLine("New PoolableObject{UUID=" + pooled.uuid.ToString() + ", poolSize=" + fullStack.Count + "}");
            return pooled;
        }

        public void releaceObject(T pooledObject) 
        {
            foreach(PooledObjectStatus<T> item in this.fullStack) {
                if (item.pooledObject.Equals(pooledObject) ) {
                    if (pooledObject.validate()) {
                        freeStack.Push(item);
                        useStack.Remove(item);
                        item.used = false;
                        Console.WriteLine("Object returned > " + item.uuid.ToString());
                        return;
                    } else {
                        Console.WriteLine("Object Invalidate ==> " + item.uuid.ToString());
                        pooledObject.Invalidate();
                        fullStack.Remove(item);
                        useStack.Remove(item);
                        lock(freeStack){
                            initPool();
                        }
                        return;
                    }
                }
            }
        }

        public override String ToString() {
            return "AbstractObjectPool ==> currentSize > '"
                    +fullStack.Count  +"', " + "free > '"
                    +freeStack.Count +"', used > '"+useStack.Count+"'";
        }
    }

} 