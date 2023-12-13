using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Networking;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance;
    [SerializeField] LoginSignup sessionController;
    string username;
    string password;
    string uriGet;
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

    public void SendLoginDataJSON(string playerUsername, string playerPassword)
    {
        string json;

        json = $@"{{
            ""username"":""{username}"",
            ""password"":""{password}"",
            ""table"":""{userDataTable}"",
            ""filter"": {{
                ""usuario"": ""{playerUsername}"",
                ""password"": ""{playerPassword}""
            }}
        }}";

        StartCoroutine(SendGetLoginRequest(json));
    }
    public void GetSignupDataJSON(string playerUsername, string playerPassword, int age, int gender)
    {
        string getJson;

        getJson = $@"{{
            ""username"":""{username}"",
            ""password"":""{password}"",
            ""table"":""{userDataTable}"",
            ""filter"": {{
                ""usuario"": ""{playerUsername}""

            }}
        }}";

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

        StartCoroutine(SendGetRequest(getJson, json));
    }

    public void StartQueryCoroutine(string playerUsername, string playerPassword, int age, int gender)
    {
        GetSignupDataJSON(playerUsername, playerPassword, age, gender);
    }
    #region old

    //IEnumerator SendQuery(string json,string playerUsername)
    //{

    //    // Construir la URL con la consulta
    //    string url = uri + "?query=" + UnityWebRequest.EscapeURL("SELECT * FROM usuarios WHERE nombre='" + playerUsername + "'");

    //    // Enviar la solicitud
    //    UnityWebRequest www = UnityWebRequest.Get(url);
    //    yield return www.SendWebRequest();

    //    if (www.result != UnityWebRequest.Result.Success)
    //    {
    //        //Debug.LogError("Error en la solicitud: " + www.error);
    //    }
    //    else
    //    {
    //        // Procesar la respuesta
    //        string resultado = www.downloadHandler.text;
    //        //Debug.Log("Resultado de la consulta: " + resultado);
    //    }
    //}
    #endregion
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

    IEnumerator SendGetRequest(string data, string postData)
    {
        //string data = CreateJSON("UserData", "Maria", "123calypso", 116 ,1);
        //string data = SendLevelDataJSON("LevelData", "Maria", 1, 2, 34, 0);


        using (UnityWebRequest www = UnityWebRequest.Post(uriGet, data, contentType))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                print("Error: " + www.error);
            }
            else
            {
                print("Respuesta: " + www.downloadHandler.text);
                string answer = www.downloadHandler.text;
                RespuestaData respuesta = JsonUtility.FromJson<RespuestaData>(answer);
                if (respuesta.data.Count == 0)
                {
                  
                    StartCoroutine(SendPostRequest(postData));
                    sessionController.SuccessRegister();

                }
                else
                {
                    sessionController.FailureRegister();
                }

            }
        }
    }

    IEnumerator SendGetLoginRequest(string data)
    {
        //string data = CreateJSON("UserData", "Maria", "123calypso", 116 ,1);
        //string data = SendLevelDataJSON("LevelData", "Maria", 1, 2, 34, 0);


        using (UnityWebRequest www = UnityWebRequest.Post(uriGet, data, contentType))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                print("Error: " + www.error);
            }
            else
            {
                print("Respuesta: " + www.downloadHandler.text);
                string answer = www.downloadHandler.text;
                RespuestaData respuesta = JsonUtility.FromJson<RespuestaData>(answer);
                if (respuesta.data.Count != 0)
                {

                    sessionController.SuccessLogin();
                    GetLevelData();


                }
                else
                {
                    sessionController.FailureLogin();
                }

            }
        }
    }

    IEnumerator SendGetLevelRequest(string data)
    {
        //string data = CreateJSON("UserData", "Maria", "123calypso", 116 ,1);
        //string data = SendLevelDataJSON("LevelData", "Maria", 1, 2, 34, 0);


        using (UnityWebRequest www = UnityWebRequest.Post(uriGet, data, contentType))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                print("Error: " + www.error);
            }
            else
            {
                print("Respuesta: " + www.downloadHandler.text);
                string answer = www.downloadHandler.text;
                RespuestaLevelData respuesta = JsonUtility.FromJson<RespuestaLevelData>(answer);
                

            }
        }
    }

    public void GetLevelData()
    {
        string getJson;

        getJson = $@"{{
            ""username"":""{username}"",
            ""password"":""{password}"",
            ""table"":""{levelDataTable}"",
            ""filter"": {{
                ""usuario"": ""{name}""

            }}
        }}";


        StartCoroutine(SendGetLevelRequest(getJson));
    }

    public void GetMaxLevel(RespuestaLevelData files)
    {
        int maxLevel;
        foreach(var levelData in files.data)
        {

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
            uriGet = config.uriGet;
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
        public string uriGet;
        
    }


    [System.Serializable]
    public class UserData
    {
        public string usuario;
        public string password;
        public int edad;
        public int genero;
    }

    [System.Serializable]
    public class RespuestaData
    {
        public string result;
        public List<UserData> data;
    }

    [System.Serializable]
    public class LevelData
    {
        public string usuario;
        public int nivel;
        public int completado;
        public int nEstrellas;
        public int nPasos;
    }

    [System.Serializable]
    public class RespuestaLevelData
    {
        public string result;
        public List<LevelData> data;
    }



}
