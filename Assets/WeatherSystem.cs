using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeatherSystem : MonoBehaviour {
    
    // 0 = Tu (Earth), 1 = Mu (Wood), 2 = Huo (Fire), 3 = Jin (Metal), 4 = Shui (Water) 
    public static int weather;

    // Initial Weather must be in [1, 2, 3, 4]
    public int initialWeather;
    private int tempWeather;
    private int[] weathers = { 1, 2, 3, 4 };
    private int weatherIndex;

    public Text weatherText;

	void Start ()
    {
        weatherIndex = initialWeather - 1;
        tempWeather = weather = weathers[weatherIndex];
        if (weather == 1)
            weatherText.text = "Wood";
        else if (weather == 2)
            weatherText.text = "Fire";
        else if (weather == 3)
            weatherText.text = "Metal";
        else if (weather == 4)
            weatherText.text = "Water";

        StartCoroutine("WeatherChange");
    }

	void Update ()
    {
	}

    IEnumerator WeatherChange()
    {
        while (true)
        {
            if (weather == 0)
            {
                yield return new WaitForSeconds(1f);
                weather = weathers[tempWeather % 4];

                if (weather == 1)
                    weatherText.text = "Wood";
                else if (weather == 2)
                    weatherText.text = "Fire";
                else if (weather == 3)
                    weatherText.text = "Metal";
                else if (weather == 4)
                    weatherText.text = "Water";
            }
            else
            {
                yield return new WaitForSeconds(2f);
                tempWeather = weather;
                weather = 0;
                weatherText.text = "Earth";
            }
        }  
    }
}
