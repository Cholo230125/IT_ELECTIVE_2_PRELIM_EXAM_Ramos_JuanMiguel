namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 9: GET Handle 404 Not Found
// TheMealDB API: https://themealdb.com/api/json/v1/1/lookup.php?i={id}
//
// Your task:
// 1. Use the HttpClient to look up a meal with an ID that doesn't exist (ID 999999)
// 2. Assert the HTTP status code is 200 OK (TheMealDB always returns 200)
// 3. Parse the JSON and assert that the "meals" field is null
//    (meaning no meal was found for that ID)
//
// This teaches: APIs can return 200 OK but still indicate "not found"
// in the response body via null data.
public static class HandleNotFound
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/lookup.php?i=999999";

        var response = await client.GetAsync(url);

        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new System.Exception("Status code is not 200 OK");
        }

        string body = await response.Content.ReadAsStringAsync();

        using (var doc = System.Text.Json.JsonDocument.Parse(body))
        {
            var mealsElement = doc.RootElement.GetProperty("meals");

            if (mealsElement.ValueKind != System.Text.Json.JsonValueKind.Null)
            {
                throw new System.Exception("Expected the 'meals' property to be null for a non-existent ID.");
            }
        }
    }
}