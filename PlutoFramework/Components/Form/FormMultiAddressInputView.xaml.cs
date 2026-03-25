using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace PlutoFramework.Components.Form;

public partial class FormMultiAddressInputView : ContentView
{
    public class AddressItem : INotifyPropertyChanged
    {
        private string _address = string.Empty;
        public string Address
        {
            get => _address;
            set
            {
                if (_address == value) return;
                _address = value ?? string.Empty;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Address)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

    public ObservableCollection<AddressItem> AddressItems { get; } = new();

    public static readonly BindableProperty AddressesProperty = BindableProperty.Create(
        nameof(Addresses), typeof(IList<string>), typeof(FormMultiAddressInputView),
        defaultValue: new List<string>(),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: OnAddressesChanged);

    public IList<string> Addresses
    {
        get => (IList<string>)GetValue(AddressesProperty);
        set => SetValue(AddressesProperty, value);
    }

    // Synchronization guards to avoid reentrancy modifications during CollectionChanged
    private bool _isSyncingFromAddresses;
    private bool _isPushingToAddresses;

    public FormMultiAddressInputView()
    {
        InitializeComponent();
        AddressItems.CollectionChanged += OnAddressItemsChanged;
    }

    private static void OnAddressesChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (FormMultiAddressInputView)bindable;
        if (control._isPushingToAddresses)
            return; // ignore changes caused by pushing from items
        control.SyncItemsFromAddresses();
    }

    private void SyncItemsFromAddresses()
    {
        _isSyncingFromAddresses = true;
        AddressItems.CollectionChanged -= OnAddressItemsChanged;
        try
        {
            AddressItems.Clear();
            if (Addresses != null)
            {
                foreach (var addr in Addresses)
                {
                    var item = new AddressItem { Address = addr ?? string.Empty };
                    item.PropertyChanged += OnItemPropertyChanged;
                    AddressItems.Add(item);
                }
            }

            EnsureTrailingEmptyRow();
        }
        finally
        {
            AddressItems.CollectionChanged += OnAddressItemsChanged;
            _isSyncingFromAddresses = false;
        }
    }

    private void OnAddressItemsChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (_isSyncingFromAddresses)
            return; // do not react while we are syncing from Addresses

        // Only push to the bindable list here; do NOT mutate AddressItems to avoid reentrancy exceptions
        PushItemsToAddresses();
    }

    private void OnItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(AddressItem.Address))
        {
            PushItemsToAddresses();
        }
    }

    private void PushItemsToAddresses()
    {
        if (_isSyncingFromAddresses)
            return;

        // Build list excluding trailing empty item
        var list = AddressItems
            .Select(i => i.Address?.Trim() ?? string.Empty)
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToList();

        // Update bindable if changed
        var current = Addresses ?? new List<string>();
        if (!list.SequenceEqual(current))
        {
            _isPushingToAddresses = true;
            Addresses = list;
            _isPushingToAddresses = false;
        }
    }

    // Ensure trailing empty row exists (call only outside of CollectionChanged reaction)
    private void EnsureTrailingEmptyRow()
    {
        if (AddressItems.Count == 0 || !string.IsNullOrWhiteSpace(AddressItems.Last().Address))
        {
            var empty = new AddressItem();
            empty.PropertyChanged += OnItemPropertyChanged;
            AddressItems.Add(empty);
        }
    }

    private void OnAddClicked(object sender, EventArgs e)
    {
        var empty = new AddressItem();
        empty.PropertyChanged += OnItemPropertyChanged;
        AddressItems.Add(empty);
    }

    private void OnRemoveClicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.BindingContext is AddressItem item)
        {
            // Prevent removing the last row; instead clear it
            if (AddressItems.Count <= 1)
            {
                item.Address = string.Empty;
                return;
            }

            AddressItems.Remove(item);

            // Defer ensuring trailing empty row to avoid modifying collection during notify cycle
            Dispatcher.Dispatch(EnsureTrailingEmptyRow);
        }
    }

    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        // no-op, TwoWay binding already updates AddressItem and triggers Push
    }

    private void OnEntryCompleted(object sender, EventArgs e)
    {
        // Add a new row when the last item is completed and non-empty
        if (sender is Entry entry && entry.BindingContext is AddressItem item)
        {
            var index = AddressItems.IndexOf(item);
            if (index == AddressItems.Count - 1 && !string.IsNullOrWhiteSpace(item.Address))
            {
                var empty = new AddressItem();
                empty.PropertyChanged += OnItemPropertyChanged;
                AddressItems.Add(empty);
            }
        }
    }
}