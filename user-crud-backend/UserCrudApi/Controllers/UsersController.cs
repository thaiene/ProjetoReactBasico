using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserCrudApi.Context;
using UserCrudApi.Models;

namespace UserCrudApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        public readonly ApplicationDbContext _dbContext;

        public UsersController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
       public IActionResult Get()
       {
        var users = _dbContext.CadastroUsuarios;
        return Ok(users);
       }

        [HttpGet("{id}")]
       public IActionResult Get(int id)
       {
        var user = _dbContext.CadastroUsuarios.Find(id);

        if(user == null)        
            return NotFound();

        return Ok(user);
       }

        [HttpPost]
        public IActionResult Post(CadastroUsuario user){
            _dbContext.CadastroUsuarios.Add(user);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = user.Id}, user);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, CadastroUsuario user){
            var existingUser = _dbContext.CadastroUsuarios.Find(id);
            if(existingUser == null)
                return NotFound();

            existingUser.Nome = user.Nome;
            existingUser.Email = user.Email;
            existingUser.Telefone = user.Telefone;
            existingUser.Senha = user.Senha;

            _dbContext.SaveChanges();
            return NoContent();
        }
       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var user = _dbContext.CadastroUsuarios.Find(id);
            if(user == null)
                return NotFound();            

            _dbContext.CadastroUsuarios.Remove(user);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}