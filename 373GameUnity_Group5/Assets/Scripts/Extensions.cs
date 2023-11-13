using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Runtime;
using UnityEngine;

public static class Extensions
{
    #region Transform
    /// <summary>
    /// Passes the base transform for the transform calling the function
    /// </summary>
    /// <param name="transform">Transform to find the base for</param>
    /// <returns>The base parent transform for the specified transform</returns>
    public static Transform GetBase(this Transform transform)
    {
        while (transform.parent != null)
        {
            transform = transform.parent;
        }
        return transform;
    }
    #endregion

    #region Generic
    
    #endregion

    #region Generic[]
    public static List<T> ToList<T>(this T[] array)
    {
        List<T> list = new List<T>();
        for (int i = 0; i < array.Length; ++i)
        {
            list.Add(array[i]);
        }
        return list;
    }
    #endregion

    #region Dictionary<T, int>
    /// <summary>
    /// Add a single unit of the specified item
    /// </summary>
    /// <typeparam name="T">Type used as the key for the dictionary</typeparam>
    /// <param name="amountDictionary">Dictionary that has integers for values for the purpose of tracking amounts</param>
    /// <param name="item">Item to add a single unit for</param>
    public static void AddItem<T>(this Dictionary<T, int> amountDictionary, T item) => amountDictionary.AddItem((item, 1));

    /// <summary>
    /// Adds as many of a specified item as needed
    /// </summary>
    /// <typeparam name="T">Type used as the key for the dictionary</typeparam>
    /// <param name="amountDictionary">Dictionary that has integers for values for the purpose of tracking amounts</param>
    /// <param name="newItem">Item to add multiple units for</param>
    public static void AddItem<T>(this Dictionary<T, int> amountDictionary, (T item, int amount) newItem)
    {
        if (amountDictionary.ContainsKey(newItem.item))
        {
            Debug.Log("Existing item increased in dictionary. Amount added: " + newItem.amount.ToString());
            amountDictionary[newItem.item] += newItem.amount;
        }
        else
        {
            Debug.Log("New item added to dictionary. Amount added: " + newItem.amount.ToString());
            amountDictionary.Add(newItem.item, newItem.amount);
        }
    }

    /// <summary>
    /// Remove a single unit of the specified item
    /// </summary>
    /// <typeparam name="T">Type used as the key for the dictionary</typeparam>
    /// <param name="amountDictionary">Dictionary that has integers for values for the purpose of tracking amounts</param>
    /// <param name="item">Item to remove a single unit from</param>
    /// <returns></returns>
    public static bool RemoveItem<T>(this Dictionary<T, int> amountDictionary, T item) => amountDictionary.RemoveItem((item, 1), out int filler);

    /// <summary>
    /// Removes as many of specified item as needed
    /// </summary>
    /// <typeparam name="T">Type used as the key for the dictionary</typeparam>
    /// <param name="amountDictionary">Dictionary that has integers for values for the purpose of tracking amounts</param>
    /// <param name="targetItem">Item to remove multiple units from</param>
    /// <param name="receivedAmount">Amount of the item received from the inventory (pulls target amount or as much as is in dictionary)</param>
    /// <returns></returns>
    public static bool RemoveItem<T>(this Dictionary<T, int> amountDictionary, (T item, int amount) targetItem, out int receivedAmount)
    {
        if (!amountDictionary.ContainsKey(targetItem.item) || amountDictionary[targetItem.item] <= 0)
        {
            Debug.Log("Target item not found in dictionary");
            receivedAmount = 0;
            return false;
        }

        receivedAmount = Math.Min(targetItem.amount, amountDictionary[targetItem.item]);
        amountDictionary[targetItem.item] -= receivedAmount;
        return true;
    }
    #endregion
}
