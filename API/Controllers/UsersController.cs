using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        //Ctrl + . to generate private readonly constructor
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            //var users = _context.Users.ToList();
            //return users;
            return await _context.Users.ToListAsync();
        }

        //api/users/id e.g 1,2,3 e.t.c
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            //var user = _context.Users.Find(id);
            //return user;
            return await _context.Users.FindAsync(id);
        }



    }
}
