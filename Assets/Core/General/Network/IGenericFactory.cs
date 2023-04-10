namespace App.Network
{
    public interface IGenericFactory<T>
    {
        public T CreateInstance();
    }
}
