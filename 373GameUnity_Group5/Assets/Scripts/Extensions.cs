using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    /// <summary>
    /// Adds a single item of the specified item
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="itemList"></param>
    /// <param name="newItem"></param>
    public static void AddItem<T>(this List<(T item, int amount)> itemList, T newItem)
    {

    }
    
    /// <summary>
    /// Adds as many of a specified item as needed
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="itemList"></param>
    /// <param name="newItem"></param>
    public static void AddItem<T>(this List<(T item, int amount)> itemList, (T item, int amount) newItem)
    {
        
    }
}
