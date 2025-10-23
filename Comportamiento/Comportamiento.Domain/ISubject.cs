namespace Comportamiento.Domain
{
    /// <summary>
    /// Subject interface that defines the contract for objects that can be observed
    /// </summary>
    /// <typeparam name="T">The type of data being observed</typeparam>
    public interface ISubject<T>
    {
        /// <summary>
        /// Attach an observer to the subject
        /// </summary>
        /// <param name="observer">The observer to attach</param>
        void Attach(IObserver<T> observer);

        /// <summary>
        /// Detach an observer from the subject
        /// </summary>
        /// <param name="observer">The observer to detach</param>
        void Detach(IObserver<T> observer);

        /// <summary>
        /// Notify all attached observers of new data
        /// </summary>
        void Notify(T data);
    }
}