using Example.Fake;
using Example.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
    private List<Users> _users = FakeDate.GetUsers(100); //users listesi oluşturarak bize gelen verileri nerede tutacagımızı belirledik. GetUsers(100) ile de kac adet veri istedigimizi belirtmiş olduk.,

    [HttpGet] //default attribute HTTPGET'tir. belirtmesek de bu sekilde çalışır.
    public List<Users> Get()
    {

      return _users;
    }

    [HttpGet("{id}")] // id bekler şekilde yazarsak localhost:5050/api/users/5 seklinde istek atmamız gerekir
    public Users GetUsers(int id)
    {
      var user = _users.FirstOrDefault(x => x.Id == id); //id si gelen useri buluyor.
      return user;
    }

    [HttpPost]
    public Users Post([FromBody] Users user) //postmandan json formatında bi user gonderdigimizde bunu db ye kayıtediyor.
    {
      _users.Add(user);
      return user;
    }

    [HttpPut]
    public Users Put([FromBody] Users user) //json da gönderdigimiz useri id si ile eşleşen userin üzerine basıyor
    {
      var editUser = _users.FirstOrDefault(x => x.Id == user.Id);
      editUser.FirstName = user.FirstName;
      editUser.LastName = user.LastName;
      editUser.Address = user.Address;
      //_users.Add(user);
      return user;
    }

    [HttpDelete("{id}")]  // idsini gönderdigimiz useri siliyor.
    public Users Delete(int id)
    {
      var deletedUser = _users.FirstOrDefault(x => x.Id == id);
      _users.Remove(deletedUser);

      return deletedUser;
    }

  }
}
