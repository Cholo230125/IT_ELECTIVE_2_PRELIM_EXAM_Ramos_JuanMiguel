namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 5: GET Filter by Ingredient
// TheMealDB API: https://themealdb.com/api/json/v1/1/filter.php?i={ingredient}
//
// Your task:
// 1. Use the HttpClient to filter meals by ingredient "chicken_breast"
// 2. Assert status code is 200 OK
// 3. Parse the JSON and assert the "meals" array has at least 1 item
//
// Response format: { "meals": [{ "strMeal": "...", "strMealThumb": "...", "idMeal": "..." }, ...] }
public static class FilterByIngredient
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/filter.php?i=chicken_breast";

        var response = await client.GetAsync(url);

        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new System.Exception("Status code is not 200 OK");
        }

        string body = await response.Content.ReadAsStringAsync();

        using (var doc = System.Text.Json.JsonDocument.Parse(body))
        {
            var mealsElement = doc.RootElement.GetProperty("meals");

            if (mealsElement.GetArrayLength() < 1)
            {
                throw new System.Exception("The 'meals' array does not contain any items.");
            }
        }
    }
}