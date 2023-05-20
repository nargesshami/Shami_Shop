using Microsoft.Extensions.Options;
using OtpNet;
using System.Diagnostics.Eventing.Reader;
using System.Text;

namespace Shami_Shop.security.phoneoTotp.Providers
{
    public class phonetotpprovider : IPhoneTotpProvider
    {
        private Totp _totp;

        private readonly phonetotpoptions _option;

        public phonetotpprovider(IOptions<phonetotpoptions> options)
        {
            _option = options?.Value ?? new phonetotpoptions();
        }
        public string GenerateTotp(string secretkey)
        {
            createtoptp(secretkey);
            return _totp.ComputeTotp();
        }

        public Phonetotpresult VerifyTotp(string secretkey, string totpcode)
        {
            createtoptp(secretkey);
            var isvalid = _totp.VerifyTotp(totpcode, out _);
            if (isvalid)
            {
                return new Phonetotpresult()
                {
                    Succeded = true
                };
            }
            return new Phonetotpresult()
            {
                Succeded = false,
                erormessage="کد وارد شده معتبر نیست لطفا کد دیگری دریافت کنید"
            };
        }
        private void createtoptp(string secretkey)
        {
            _totp = new Totp(Encoding.UTF8.GetBytes(secretkey), _option.stepinsecon);
        }
    }
}
