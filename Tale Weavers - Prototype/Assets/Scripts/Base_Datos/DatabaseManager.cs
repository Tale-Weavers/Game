using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance;
    string username;
    string password;
    string uri;
    string contentType = "application/json";

    string levelDataTable = "LevelData";
    string userDataTable = "UserData";
    string name = "Maria";

    private void Awake()
    {
        Time.timeScale = 1.0f;
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        LoadCredentials();
    }
    void Start()
    {
        //StartCoroutine(SendPostRequest());
    }

    string CreateJSON(string tabla, string name, string cont, int age, int genre)
    {
        //Construye JSON para la petición REST         
        string json = $@"{{
            ""username"":""{username}"",
            ""password"":""{password}"",
            ""table"":""{tabla}"",
            ""data"": {{
                ""usuario"": ""{name}"",
                ""password"": ""{cont}"",
                ""edad"": {age},
                ""genero"": {genre}
            }}
        }}";

        return json;
    }
    public void SendLevelDataJSON(int level, int nStars, int nSteps, int levelCompleted)
    {
        string json;
        if (levelCompleted == 0)
        {
            json = $@"{{
            ""username"":""{username}"",
            ""password"":""{password}"",
            ""table"":""{levelDataTable}"",
            ""data"": {{
                ""usuario"": ""{name}"",
                ""nivel"": {level},
                ""completado"": {levelCompleted},
                
                ""nPasos"": {nSteps}
            }}
        }}";
        }
        else
        {
            //Construye JSON para la petición REST         
            json = $@"{{
            ""username"":""{username}"",
            ""password"":""{password}"",
            ""table"":""{levelDataTable}"",
            ""data"": {{
                ""usuario"": ""{name}"",
                ""nivel"": {level},
                ""completado"": {levelCompleted},
                ""nEstrellas"": {nStars},
                ""nPasos"": {nSteps}
            }}
        }}";
        }

       StartCoroutine(SendPostRequest(json));
    }

    public void SendSignupDataJSON(string playerUsername, string playerPassword, int age, int gender)
    {
        string json;
        
            json = $@"{{
            ""username"":""{username}"",
            ""password"":""{password}"",
            ""table"":""{userDataTable}"",
            ""data"": {{
                ""usuario"": ""{playerUsername}"",
                ""password"": ""{playerPassword}"",
                ""edad"": {age},
                ""genero"": {gender}
            }}
        }}";
        
        

        StartCoroutine(SendPostRequest(json));
    }


    public void StartQueryCoroutine(string playerUsername)
    {
        StartCoroutine(SendQuery(playerUsername));
    }
    IEnumerator SendQuery(string playerUsername)
    {
        // Construir la URL con la consulta
        string url = uri + "?query=" + UnityWebRequest.EscapeURL("SELECT * FROM usuarios WHERE nombre='" + playerUsername + "'");

        // Enviar la solicitud
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            //Debug.LogError("Error en la solicitud: " + www.error);
        }
        else
        {
            // Procesar la respuesta
            string resultado = www.downloadHandler.text;
            //Debug.Log("Resultado de la consulta: " + resultado);
        }
    }
    IEnumerator SendPostRequest(string data)
    {
        //string data = CreateJSON("UserData", "Maria", "123calypso", 116 ,1);
        //string data = SendLevelDataJSON("LevelData", "Maria", 1, 2, 34, 0);


        using (UnityWebRequest www = UnityWebRequest.Post(uri, data, contentType))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                print("Error: " + www.error);
            }
            else
            {
                print("Respuesta: " + www.downloadHandler.text);
            }
        }
    }

    void LoadCredentials()
    {
        string configPath = "Assets/Resources/Datos/config.json";

        if (File.Exists(configPath))
        {
            string configJson = File.ReadAllText(configPath);
            var config = JsonUtility.FromJson<Credentials>(configJson);

            username = config.username;
            password = config.password;
            uri = config.uri;
        }
        else
        {
            //Debug.LogError("Config file not found!");
        }
    }

    [System.Serializable]
    private class Credentials
    {
        public string username;
        public string password;
        public string uri;
    }


}
