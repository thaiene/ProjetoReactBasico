using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UserCrudApi.Models;

namespace UserCrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStaticController : ControllerBase
    {
        private static List<CadastroUsuario> users = new List<CadastroUsuario>
        {
            new CadastroUsuario { Id = 1, Nome = "John Doe", Email = "john@example.com", Telefone = "123456789", Senha = "abc123" },
            new CadastroUsuario { Id = 2, Nome = "Jane Smith", Email = "jane@example.com", Telefone = "987654321", Senha = "xyz456" }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = users.Find(u => u.Id == id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post(CadastroUsuario user)
        {
            user.Id = users.Count + 1;
            users.Add(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, CadastroUsuario user)
        {
            var index = users.FindIndex(u => u.Id == id);
            if (index == -1)
                return NotFound();

            users[index] = user;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = users.Find(u => u.Id == id);
            if (user == null)
                return NotFound();

            users.Remove(user);
            return NoContent();
        }
    }
}
