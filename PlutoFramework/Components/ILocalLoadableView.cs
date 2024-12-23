namespace PlutoFramework.Components
{
    interface ILocalLoadableView
    {
        /// <summary>
        /// This function is called first in the queue.
        /// Used for loading locally stored data.
        /// </summary>
        void Load();
    }

    interface ILocalLoadableAsyncView
    {
        /// <summary>
        /// This function is called first in the queue.
        /// Used for loading locally stored data asynchronically.
        /// </summary>
        Task LoadAsync(CancellationToken token);
    }

    interface ISetEmptyView
    {
        /// <summary>
        /// This is a fallback function that is called if the view has not loaded any data,
        /// to display a default empty state instead.
        /// </summary>
        void SetEmpty();
    }
}
