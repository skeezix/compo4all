using System;
using System.Collections.Generic;
using System.Text;

namespace HiToText.Utils
{
    public class OneToManyMap<K, T>
    {
        private Dictionary<K, T> _oneToMany = new Dictionary<K, T>();
        private Dictionary<T, K> _manyToOne = new Dictionary<T, K>();

        private K _defaultOne;
        private T _defaultMany;

        public OneToManyMap()
        {
        }

        public void AddMapping(K oneValueToMap, T manyValueToMap)
        {
            //It's possible to have multiple T's mapped to any K's, but not the other way
            //around. Don't add to _oneToMany in this case.
            if (!ContainsOne(oneValueToMap))
                _oneToMany.Add(oneValueToMap, manyValueToMap);

            _manyToOne.Add(manyValueToMap, oneValueToMap);
        }

        /// <summary>
        /// If no value is found in the mapping when used, it will default to either of these depending on the
        /// type of switch statement.
        /// </summary>
        /// <param name="oneValueDefault"></param>
        /// <param name="manyValueDefault"></param>
        public void AddDefault(K oneValueDefault, T manyValueDefault)
        {
            _defaultMany = manyValueDefault;
            _defaultOne = oneValueDefault;
        }

        public T FindMany(K manyToFind)
        {
            if (ContainsOne(manyToFind))
            {
                if (manyToFind.GetType() == typeof(byte[]))
                    return GetTFromByteArrayKey((byte[])((object)manyToFind));
                else
                    return _oneToMany[manyToFind];
            }
            else
                return _defaultMany;
        }

        public K FindOne(T oneToFind)
        {
            if (ContainsMany(oneToFind))
            {
                if (oneToFind.GetType() == typeof(byte[]))
                    return GetKFromByteArrayKey((byte[])((object)oneToFind));
                else
                    return _manyToOne[oneToFind];
            }
            else
                return _defaultOne;
        }

        public bool ContainsOne(K valToMap)
        {
            foreach (K keyAsK in _oneToMany.Keys)
            {
                if (valToMap.GetType() == typeof(byte[]))
                {
                    byte[] key = (byte[])((object)keyAsK);
                    byte[] map = (byte[])((object)valToMap);

                    bool isSame = true;
                    for (int i = 0; i < map.Length; i++)
                    {
                        if (!map[i].Equals(key[i]))
                        {
                            isSame = false;
                            break;
                        }
                    }
                    if (isSame)
                        return true;
                }
                else
                {
                    if (keyAsK.Equals(valToMap))
                        return true;
                }
            }

            return false;
        }

        public bool ContainsMany(T valToMap)
        {
            foreach (T keyAsT in _manyToOne.Keys)
            {
                if (valToMap.GetType() == typeof(byte[]))
                {
                    byte[] key = (byte[])((object)keyAsT);
                    byte[] map = (byte[])((object)valToMap);

                    bool isSame = true;
                    for (int i = 0; i < map.Length; i++)
                    {
                        if (!map[i].Equals(key[i]))
                        {
                            isSame = false;
                            break;
                        }
                    }
                    if (isSame)
                        return true;
                }
                else
                {
                    if (keyAsT.Equals(valToMap))
                        return true;
                }
            }

            return false;
        }

        private T GetTFromByteArrayKey(byte[] map)
        {
            int forCount = 0;
            foreach (K keyAsK in _oneToMany.Keys)
            {
                byte[] key = (byte[])((object)keyAsK);
                int location = -1;
                bool isSame = true;
                for (int i = 0; i < map.Length; i++)
                {
                    if (!map[i].Equals(key[i]))
                    {
                        isSame = false;
                        break;
                    }
                }
                if (isSame)
                    location = forCount;

                if (location != -1)
                {
                    int counter = 0;
                    foreach (T val in _oneToMany.Values)
                    {
                        if (counter == location)
                            return val;
                        counter++;
                    }
                }

                forCount++;
            }

            //Will only get here if there's no map in _oneToMany.
            return _defaultMany;
        }

        private K GetKFromByteArrayKey(byte[] map)
        {
            int forCount = 0;
            foreach (T keyAsT in _manyToOne.Keys)
            {
                byte[] key = (byte[])((object)keyAsT);
                int location = -1;
                bool isSame = true;
                for (int i = 0; i < map.Length; i++)
                {
                    if (!map[i].Equals(key[i]))
                    {
                        isSame = false;
                        break;
                    }
                }
                if (isSame)
                    location = forCount;

                if (location != -1)
                {
                    int counter = 0;
                    foreach (K val in _manyToOne.Values)
                    {
                        if (counter == location)
                            return val;
                        counter++;
                    }
                }

                forCount++;
            }

            //Will only get here if there's no map in _manyToOne.
            return _defaultOne;
        }
    }
}
