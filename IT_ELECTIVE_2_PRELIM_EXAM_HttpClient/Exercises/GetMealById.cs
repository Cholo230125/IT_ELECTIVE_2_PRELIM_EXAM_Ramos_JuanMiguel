namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 3: GET Lookup by ID
// TheMealDB API: https://themealdb.com/api/json/v1/1/lookup.php?i={id}
//
// Your task:
// 1. Use the HttpClient to look up meal with ID 52772
// 2. Assert status code is 200 OK
// 3. Parse the JSON and assert the meal name is "Arrabiata"
//
// Note: TheMealDB meal IDs are numeric (52771 = Arrabiata)
public static class GetMealById
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/lookup.php?i=52771";

        var response = await client.GetAsync(url);

        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new System.Exception("Status code is not 200 OK");
        }

        string body = await response.Content.ReadAsStringAsync();

        using (var doc = System.Text.Json.JsonDocument.Parse(body))
        {
            var mealsElement = doc.RootElement.GetProperty("meals");
            var firstMeal = mealsElement[0];
            string mealName = firstMeal.GetProperty("strMeal").GetString();

            if (mealName != "Spicy Arrabiata Penne")
            {
                throw new System.Exception($"Expected meal name 'Spicy Arrabiata Penne' but got '{mealName}'");
            }
        }
    }
}