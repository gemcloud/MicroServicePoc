namespace AuthService.Entities
{
    public interface IUsers
    {
        void Add(Users agent);

        Users FindByLogin(string login);
    }
}
