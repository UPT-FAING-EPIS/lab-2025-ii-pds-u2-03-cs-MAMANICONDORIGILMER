namespace Comportamiento.Domain
{
    /// <summary>
    /// Observer interface that defines the contract for objects that should be notified of changes
    /// </summary>
    /// <typeparam name="T">The type of data being observed</typeparam>
    public interface IObserver<T>
    {
        /// <summary>
        /// Called when the subject has new data to share
        /// </summary>
        /// <param name="data">The data being shared by the subject</param>
        void Update(T data);
    }
}