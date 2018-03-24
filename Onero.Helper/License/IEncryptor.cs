namespace Onero.Helper.License
{
    public interface IEncryptor
    {
        string Encrypt(string value);
        string Decrypt(string code);
    }
}
