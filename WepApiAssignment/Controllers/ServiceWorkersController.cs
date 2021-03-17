using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WepApiAssignment.Data;
using WepApiAssignment.Models;
using WepApiAssignment.ViewModels;

namespace WepApiAssignment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceWorkersController : ControllerBase
    {
        private readonly SqlDbContext _context;
        public IConfiguration Configuration { get; }

        public ServiceWorkersController(SqlDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }





        // GET: api/ServiceWorkers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceWorker>>> GetServiceWorkers()
        {
            return await _context.ServiceWorkers.ToListAsync();
        }

        // GET: api/ServiceWorkers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceWorker>> GetServiceWorker(int id)
        {
            var serviceWorker = await _context.ServiceWorkers.FindAsync(id);

            if (serviceWorker == null)
            {
                return NotFound();
            }

            return serviceWorker;
        }






        // PUT: api/ServiceWorkers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceWorker(int id, ServiceWorker serviceWorker)
        {
            if (id != serviceWorker.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceWorker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceWorkerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (_context.ServiceWorkers.Any(user => user.Email == model.Email))
                return Conflict();
            try
            {
                var serviceWorker = new ServiceWorker()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email
                };

                serviceWorker.CreatePasswordHash(model.Password);
                _context.ServiceWorkers.Add(serviceWorker);

                await _context.SaveChangesAsync();
                
            }
            catch
            {
                return new BadRequestResult();
            }
            return new OkResult();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
                return new BadRequestObjectResult("Invalid Email or Password");

            try
            {
                var serviceworker = await _context.ServiceWorkers.SingleOrDefaultAsync(serviceworker => serviceworker.Email == model.Email);

                if (serviceworker == null)
                    return new BadRequestObjectResult("User not Found");

                if (!serviceworker.ValidatePasswordHash(model.Password))
                    return new BadRequestObjectResult("Invalid Email or Password");

                var tokenHandler = new JwtSecurityTokenHandler();
                var secretKey = Encoding.UTF8.GetBytes(Configuration.GetSection("SecretKey").Value);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                   {
                        new Claim(ClaimTypes.Name, serviceworker.Id.ToString())
                   }),

                    Expires = DateTime.UtcNow.AddDays(7),

                    SigningCredentials = new SigningCredentials(
                       new SymmetricSecurityKey(secretKey),
                       SecurityAlgorithms.HmacSha256Signature
                   )
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return new OkObjectResult(
                    new
                    {
                        Id = serviceworker.Id,
                        Email = serviceworker.Email,
                        Token = tokenString
                    });
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }




        // DELETE: api/ServiceWorkers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceWorker(int id)
        {
            var serviceWorker = await _context.ServiceWorkers.FindAsync(id);
            if (serviceWorker == null)
            {
                return NotFound();
            }

            _context.ServiceWorkers.Remove(serviceWorker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceWorkerExists(int id)
        {
            return _context.ServiceWorkers.Any(e => e.Id == id);
        }
    }
}
