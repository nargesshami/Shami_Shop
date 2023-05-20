namespace Shami_Shop.security.phoneoTotp.Providers
{
    public interface IPhoneTotpProvider
    {
        string GenerateTotp(string secretkey);
        Phonetotpresult VerifyTotp(string secretkey,string totpcode);
    }
}
