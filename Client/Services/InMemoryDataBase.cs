using Client.Static;
using Shared.Models;
using System.Net.Http.Json;

namespace Client.Services;

internal sealed class InMemoryDataBase
{
    private readonly HttpClient _httpClient;

    public InMemoryDataBase(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private List<Category> _categories = null;

    internal List<Category> Categories
    {
        get { return _categories; }
        set
        {
            _categories = value;
            NotifyCategoriesDataChanged();
        }
    }

    private bool _gettingCategoriesFromDatabaseAndInMemory = false;
    internal async Task GetCategoriesFromDatabaseAndInMemory()
    {
        //Only allow one Get request to run at a time
        if (_gettingCategoriesFromDatabaseAndInMemory==false)
        {
            _gettingCategoriesFromDatabaseAndInMemory=true;
            _categories = await _httpClient.GetFromJsonAsync<List<Category>>(ApiEndpoints.s_categories);
            _gettingCategoriesFromDatabaseAndInMemory = false;

        }
    }

    internal event Action OnCategoriesDataChanged;
    private void NotifyCategoriesDataChanged()=> OnCategoriesDataChanged?.Invoke();
    
}
