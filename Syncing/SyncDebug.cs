using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        public List<string> InitializeList(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();
            Parallel.ForEach(items, i =>
            {
                bag.Add(i);
            });
            var list = bag.ToList();
            return list;
        }

        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var concurrentDictionary = new ConcurrentDictionary<int, string>();
            try
            {
                var itemsToInitialize = Enumerable.Range(0, 100).ToList();
                var threads = Enumerable.Range(0, 3)
                    .Select(i => new Thread(() =>
                    {
                        foreach (var item in itemsToInitialize)
                        {
                            concurrentDictionary.GetOrAdd(item, getItem, (_, s) => s);
                        }
                    }))
                    .ToList();

                foreach (var thread in threads)
                {
                    thread.Start();
                }
                foreach (var thread in threads)
                {
                    thread.Join();
                }

                return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
            }
            catch (Exception)
            {
                Var errDict = new Dictionary<int, string> { { -1, " " } ;
                return errDict;
            }
        }
    }