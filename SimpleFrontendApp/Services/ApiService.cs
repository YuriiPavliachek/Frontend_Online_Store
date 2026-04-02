using System.Net.Http.Json;

public class ApiService
{
    private readonly HttpClient _http;

    public ApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Book>> GetBooks()
    {
        return await _http.GetFromJsonAsync<List<Book>>("api/books");
    }
}

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
}