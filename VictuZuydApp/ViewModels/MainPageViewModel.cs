using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VictuZuydApp.ViewModels
{
    public class MainPageViewModel : BindableObject
    {
        private readonly Repos.IBaseRepository<Models.Event> _eventRepository;
        public ObservableCollection<Models.Event> Events { get; private set; } = new ObservableCollection<Models.Event>();

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Location { get; set; }
        public string Image { get; set; }
        public int MaxParticipants { get; set; }
        public bool IsActive { get; set; } = true;

        public ICommand AddEventCommand { get; }

        public MainPageViewModel(Repos.IBaseRepository<Models.Event> eventRepository)
        {
            _eventRepository = eventRepository;

            AddEventCommand = new Command(async () => await AddEventAsync());

            // Load existing events 
            _ = LoadEventsAsync();
        }

        private async Task AddEventAsync()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Description) || string.IsNullOrWhiteSpace(Location))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Name, Description, and Location cannot be empty.", "OK");
                return;
            }

            var newEvent = new Models.Event
            {
                Name = Name,
                Description = Description,
                Date = Date,
                Location = Location,
                Image = Image,
                MaxParticipants = MaxParticipants,
                CurrentParticipants = 0, // New events 0 participants
                IsActive = IsActive
            };

            await _eventRepository.InsertAsync(newEvent);

            // Clear input
            Name = string.Empty;
            Description = string.Empty;
            Location = string.Empty;
            Image = string.Empty;
            MaxParticipants = 0;
            IsActive = true;

            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(Date));
            OnPropertyChanged(nameof(Location));
            OnPropertyChanged(nameof(Image));
            OnPropertyChanged(nameof(MaxParticipants));
            OnPropertyChanged(nameof(IsActive));

            // Refresh the list of events
            await LoadEventsAsync();
        }

        private async Task LoadEventsAsync()
        {
            var events = await _eventRepository.GetAllAsync();
            Events.Clear();

            foreach (var e in events)
            {
                Events.Add(e);
            }
        }

    }
}
