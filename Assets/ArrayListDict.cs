using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayListDict : MonoBehaviour
{
    public string client1 = "Greg";
    public string client2 = "Kate";
    public string client3 = "Adam";
    public string client4 = "Mia";
    public string client5 = "Fred";
    public string client6 = "Roman";
    public string client7 = "health";
    public string client8 = "Princess";


    //creating Array Example
    public string[] clientList = new string[] { "Greg", "Kate", "Adam", "Mia", "Fred", "Morgana","Krull","ninja","Apex","Epic"};

    //creating List Example ,Declaring
    public List<string> santasNaughtyList = new List<string>();

    //ArrayList Example
    public ArrayList inventory = new ArrayList();

    private void Start()
    {

        //printing Arrays
        PrintingByIndex(0);
        PrintingByIndex(1);
        PrintingByIndex(2);
        PrintingByIndex(3);


        //adding Lists
        AddingList(client1);
        AddingList(client2);
        AddingList(client3);
        AddingList(client4);
        AddingList(client5);
        AddingList(client6);
        AddingList(client7);
        AddingList(client8);

        //removing Lists
        RemovingList(client1);
        RemovingList(client2);
        RemovingList(client3);
        RemovingList(client4);

        //should print fred
        print(santasNaughtyList[0]);
        

        //Adding Content to the ArrayList
        inventory.Add(10);
        inventory.Add("boo");
        inventory.Add("false");
        inventory.Add(4.5f);
        inventory.Add(false);
        inventory.Add(true);
        inventory.Add("nonthing");
        inventory.Add(12);


        //printing Array List by index
        PrintingArrayLists(1);
        PrintingArrayLists(2);
        PrintingArrayLists(3);
        PrintingArrayLists(4);
        PrintingArrayLists(4);
    }   

    /// Adding client to the list

    public void AddingList(string client)
    {
        santasNaughtyList.Add(client);
        print(client + " was Added");
        
    }
 
    /// Removing client of the list
    public void RemovingList(string client)
    {
        santasNaughtyList.Remove(client);
    }

    //Addingitems to the ArrayList inventory 
    public void Addinginventory(string item)
    {
        inventory.Add(item);
    }

    /// printing list by index 
    public void PrintingByIndex(int index)
    {
        print(clientList[index]);

    }

    //printing ArrayListByIndex
    public void PrintingArrayLists(int index)
    {
        print(inventory[index]);

    }

}
