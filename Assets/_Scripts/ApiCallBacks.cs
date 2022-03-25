using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Sirenix.OdinInspector;

public class ApiCallBacks : MonoBehaviour
{
    HttpClient client = new HttpClient();
    public AllSpells spellNames;
    [SerializeField] string extraDebug;

    public static ApiCallBacks instance;

    private void Awake()
    {
        if (instance)
            Destroy(instance);
        instance = this;
    }

    private void Start()
    {
        Task<AllSpells> loadSpells = Task.Run<AllSpells>(async () => await GetSpellAsync("https://www.dnd5eapi.co/api/spells/"));
        spellNames = loadSpells.Result;
    }

    public InDepthSpellInfo GetSpellInfo(string url)
    {
        Debug.Log(url);
        Task<InDepthSpellInfo> infoTask = Task.Run<InDepthSpellInfo>(async () => await GetSpellInfoAsync(url));
        InDepthSpellInfo info = infoTask.Result;
        return info;
    }

    async Task<InDepthSpellInfo> GetSpellInfoAsync(string url)
    {
        InDepthSpellInfo info = null;
        string data = "";
        HttpResponseMessage response = await client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            data = await response.Content.ReadAsStringAsync();
            Debug.Log(data);
            info = JsonUtility.FromJson<InDepthSpellInfo>(data);
        }
        return info;
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
    public string url;
}

[System.Serializable]
public class MagicSchool
{
    public string name;
}


[System.Serializable]
public class InDepthSpellInfo
{
    public string name;

    public List<string> components;
    public string duration;

    public string casting_time;
    public string ritual;

    public string range;
    public MagicSchool school;

    public string concentration;
    public string level;

    public List<string> desc = new List<string>();
    public List<string> higher_level = new List<string>();

}