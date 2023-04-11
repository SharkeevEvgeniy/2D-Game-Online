namespace App
{
    public interface IGenericFactory<T>
    {
        T Spawn();
    }
}
