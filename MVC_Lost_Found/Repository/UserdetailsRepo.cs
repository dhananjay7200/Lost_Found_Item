using Microsoft.IdentityModel.Tokens;
using MVC_Lost_Found.Interfaces;
using MVC_Lost_Found.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MVC_Lost_Found.Repository
{
    public class UserdetailsRepo : IUserdetails
    {
        private readonly LostandFoundContext _context;
        //private readonly IConfiguration iconfiguration;

        public UserdetailsRepo(LostandFoundContext context)
        {
            _context = context;
           // this.iconfiguration = iconfiguration;
        }

       


        public Userdetail UserLogin(Userdetail user)
        {
          Userdetail uData=_context.Userdetails.Where(x=>x.UserName== user.UserName && x.UserPassword==user.UserPassword).FirstOrDefault();
            if (uData != null)
            {
                /*Console.WriteLine(GenerateToken(uData));
                Console.WriteLine(uData.UserRole);*/
                return uData;
              
            }
            return null;
        }

        public IEnumerable<Item> UserProfile(string name)
        {
           IEnumerable<Item> item=_context.Items.Where(x=>x.Uname== name).ToList();
            return item;
        }

        public Userdetail UserReagister(Userdetail Udata)
        {
            throw new NotImplementedException();
        }

     /*   private string GenerateToken(Userdetail user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("this is my custom Secret key for authentication");
            var identity = new ClaimsIdentity(new Claim[]
            {
                  new Claim(ClaimTypes.Role, user.UserRole),
                   new Claim("name",user.UserName),
              });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials,
            };
            var token =jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);

        }*/


       /* private string GenerateToken(Userdetail user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(iconfiguration["Jwt:SecurityKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Role, user.UserRole),
                   new Claim("name",user.UserName),
            };
            var token = new JwtSecurityToken(iconfiguration["Jwt:Issuer"],
                iconfiguration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }*/
    }
}
