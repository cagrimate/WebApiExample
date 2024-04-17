using Bogus;
using Example.Models;

namespace Example.Fake
{
  public static class FakeDate
  {
    private static List<Users> _users; //field oluşturduk. bu sayede Model klasoru altındaki Users Class'ındaki bilgileri kullanarak listeye ekleyebileceğiz.

    public static List<Users> GetUsers(int number) //int number alarak kullanıcı istedigi kadar fake data oluşturabilmesini sağladık.
    {
      if (_users == null) //bu sayede program boyunca aynı datalar ile işlem yapabiliriz.
      {
        _users = new Faker<Users>()
          .RuleFor(u => u.Id, f => f.IndexFaker + 1) //fakedate indexi 0 dan baslıyordur o yuzden ekledik.
          .RuleFor(u => u.FirstName, f => f.Name.FirstName())
          .RuleFor(u => u.LastName, f => f.Name.LastName())
          .RuleFor(u => u.Address, f => f.Address.FullAddress())
          .Generate(number); //
      }

      return _users; //listeyi döndürüyoruz.

    }

  }
}
