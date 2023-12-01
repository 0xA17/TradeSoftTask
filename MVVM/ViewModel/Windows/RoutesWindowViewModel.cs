using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TradeSoftTask.MVVM.ViewModel.Windows;

class RoutesWindowViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private String _selectedSearchEngine;

    private Dictionary<String, List<String>> SearchResults;

    public RoutesWindowViewModel(Dictionary<String, List<String>> searchResults)
    {
        SearchResults = searchResults;
    }

    public String SelectedSearchEngine
    {
        get => _selectedSearchEngine;
        set
        {
            if (_selectedSearchEngine != value)
            {
                _selectedSearchEngine = value;
                OnPropertyChanged(nameof(SelectedSearchEngine));
                OnPropertyChanged(nameof(SearchResultsForSelectedEngine));
            }
        }
    }

    public IEnumerable<String> SearchEngines => SearchResults.Keys;

    public IEnumerable<String> SearchResultsForSelectedEngine =>
        _selectedSearchEngine != null && SearchResults.TryGetValue(_selectedSearchEngine, out var results)
            ? results
            : Enumerable.Empty<String>();

    protected virtual void OnPropertyChanged(String propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
