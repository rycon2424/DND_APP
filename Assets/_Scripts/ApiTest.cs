using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Sirenix.OdinInspector;

public class ApiTest : MonoBehaviour
{
    HttpClient client = new HttpClient();
    [SerializeField] AllSpells spellNames;
    [SerializeField] string extraDebug;

    private void Start()
    {
        Task<AllSpells> loadSpells = Task.Run<AllSpells>(async () => await GetSpellAsync("https://www.dnd5eapi.co/api/spells/"));
        spellNames = loadSpells.Result;
    }

    async Task<AllSpells> GetSpellAsync(string path)
    {
        AllSpells spell = null;
        string data = "";
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            data = await response.Content.ReadAsStringAsync();
            spell = JsonUtility.FromJson<AllSpells>(data);
        }
        return spell;
    }
}

[System.Serializable]
public class AllSpells
{ 
    public int count;
    public Results[] results;
}

[System.Serializable]
public class Results
{
    public string name;
    public string index;
    public string url;
}


