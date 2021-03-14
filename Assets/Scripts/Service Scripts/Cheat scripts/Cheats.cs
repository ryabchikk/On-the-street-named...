using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cheats : MonoBehaviour
{
    [SerializeField] private GameObject ladder;
    [SerializeField] private GameObject fpsMeter;
    [SerializeField] private InputField inputField;
    [SerializeField] private GameObject spawns;
    private bool _cheatsOn;
    private CommandParser _parser;
    private Player _player;

#if DEBUG
    private void Start()
    {
        _cheatsOn = true;
        _player = Player.player;
        
        GameObject[] objects = {_player.gameObject, ladder, fpsMeter, spawns};
        Vector3[] positions =
        {
            new Vector3(449f, 4.7f, 467.7f),
            new Vector3(365.04f, 4.873f, 248.121f),
            new Vector3(750.87f, 39.714f, 350.41f),
            new Vector3(160.50f, 4.873f, 290.745f)
        };
        _parser = new CommandParser(objects, positions);
    }
#endif
    
    private void Update()
    {
        if (_cheatsOn == false) return;

        if (Input.GetKeyDown("`"))
        {
            if(inputField.gameObject.activeSelf)
            {
                _player.ActivateShooting();
                inputField.gameObject.SetActive(false);
            }
            else
            {
                _player.DeactivateShooting();
                inputField.gameObject.SetActive(true);
                inputField.ActivateInputField();
            }
        }
    }
    
    public void OnCommandEntered()
    {
        using (_parser)
            if(inputField.text != "`")
            {
                try
                {
                    _parser.Build(inputField.text).Invoke();
                }
                catch (ArgumentException e)
                {
                    Debug.Log(e.Message);
                }
                finally
                {
                    inputField.text = "";
                    inputField.ActivateInputField();
                }
            }
    }
}

public class CommandParser : IDisposable
{
    private Action _action;
    private GameObject _player;
    private readonly Dictionary<string, GameObject> _objects;
    private readonly Dictionary<string, Vector3> _places;

    public CommandParser(GameObject[] fastAccessObjects, Vector3[] positions)
    {
        _player = fastAccessObjects[0];
        _places = new Dictionary<string, Vector3>
        {
            { "kakuro", positions[0] },
            { "test", positions[1] },
            { "terminal", positions[1] },
            { "flash", positions[2] },
            { "code", positions[3] }
        };
        
        _objects = new Dictionary<string, GameObject>
        {
            { "ladder", fastAccessObjects[1] },
            { "fps", fastAccessObjects[2] },
            { "spawns", fastAccessObjects[3] },
            { "enemies", fastAccessObjects[3] }
        };
    }

    public CommandParser Build(string command)
    {
        _action = Parse(command);
        return this;
    }

    public void Invoke()
    {
        _action.Invoke();
    }

    private Action Parse(string command)
    {
        string[] words = command.Split(' ');
        for (var i = 0; i < words.Length; i++)
        {
            words[i] = words[i].ToLower();
        }
        
        switch (words[0])
        {
            case "activate":
                return Activate(words[1]);
            case "deactivate":
                return Deactivate(words[1]);
            case "kill":
                return Kill(words[1]);
            case "teleport":
                return Teleport(words[1]);
            default:
                throw new ArgumentException("Invalid command");
        }
    }

    private Action Activate(string obj)
    {
        GameObject o;
        if(_objects.ContainsKey(obj))
            o = _objects[obj];
        else
            o = GameObject.Find("obj");
        
        if (o != null)
            return () => { o.SetActive(true); };
        else
            throw new ArgumentException("Object not found");
    }
    
    private Action Deactivate(string obj)
    {
        GameObject o;
        if(_objects.ContainsKey(obj))
            o = _objects[obj];
        else
            o = GameObject.Find("obj");
        
        if (o != null)
            return () => { o.SetActive(false); };
        else
            throw new ArgumentException("Object not found");
    }

    private Action Kill(string obj)
    {
        if (obj == "self" || obj == "player")
            return () => { Player.player.ApplyDamage(4); };
        else if (obj == "enemy" || obj == "enemies")
            return () =>
            {
                foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
                    enemy.SendMessage("Die");
            };
        else
            throw new ArgumentException("Invalid object to kill");
    }

    private Action Teleport(string place)
    {
        
        if (_places.ContainsKey(place))
        {
            Debug.Log("TP");
            return () => { Player.player.Teleport(_places[place]); };
        }
        else
            throw new ArgumentException("Invalid place");
    }

    public void Dispose()
    {
        _action = null;
    }
}