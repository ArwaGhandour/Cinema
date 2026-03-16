namespace cinemasecondflutter.Genaricrepos
{
    public interface IGenaric<T>where T:class
    {
        public Task<List<T>>Getall();
        public Task<T> GetbyID(int id);
        public Task Addasync(T entity);
        public void Updateasync(T entity);
        public void Delete(int id);

    }
}
