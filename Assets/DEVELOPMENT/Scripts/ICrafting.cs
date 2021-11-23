using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICrafting : MonoBehaviour
{
    private List<IRecipe> recipes;
    private IInventory inventory;

    private void Craft(IRecipe recipe)
    {
        if (inventory.Querry(recipe.components))
        {
            inventory.RemoveAll(recipe.components);
            inventory.Add(recipe.result, 2);
        }
    }
}