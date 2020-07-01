// Root myDeserializedClass = JsonConvert.DeserializeObject(myJsonResponse); 


public class Auth
{
    public bool success { get; set; }
    public User user { get; set; }
    public string token { get; set; }

}

