using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WepApiAssignment.Data;
using WepApiAssignment.Models;
using WepApiAssignment.ViewModels;

namespace WepApiAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
 
    public class IssuesController : ControllerBase
    {
        private readonly SqlDbContext _context;
        public IConfiguration _configuration { get; }

        public IssuesController(SqlDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/Issues
        [HttpGet]
        public async Task<IActionResult> GetIssues([FromQuery] string status, int Id, int customerId, DateTime date)
        {
            var querystring = _context.Issues.AsQueryable().Include(x => x.Customer).Include(x => x.ServiceWorker);

            if (!string.IsNullOrEmpty(status))
                querystring = querystring.Where(x => x.IssueStatus == status).Include(x => x.Customer).Include(x => x.ServiceWorker);

            if (Id >= 1)
                querystring = querystring.Where(x => x.Id == Id).Include(x => x.Customer).Include(x => x.ServiceWorker);

            if (customerId >= 1)
                querystring = querystring.Where(x => x.CustomerId == customerId).Include(x => x.Customer).Include(x => x.ServiceWorker);

            if (date != DateTime.MinValue) 
                querystring = querystring.OrderBy(x => x.IssueDate).Include(e => e.Customer).Include(e => e.ServiceWorker);
  

            return new OkObjectResult(await querystring.ToListAsync());
        }

        // GET: api/Issues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Issue>> GetIssue(int id)
        {
            var issue = await _context.Issues.FindAsync(id);

            if (issue == null)
            {
                return NotFound();
            }

            return issue;
        }


  


        [HttpPost("Create")]
        public async Task<IActionResult> CreateIssue([FromBody] CreateIssueModel model)
        {

            var customer = await _context.Customers.FindAsync(model.CustomerId);
            var serviceworker = await _context.ServiceWorkers.FindAsync(model.ServiceWorkerId);

            try
            {
                var issue = new Issue()
                {
                    IssueDescription = model.Description,
                    CustomerId = model.CustomerId,
                    ServiceWorkerId = model.ServiceWorkerId,
                    IssueStatus = model.IssueStatus,
                    IssueDate = DateTime.Now
                };

                issue.Customer = customer;
                issue.ServiceWorker = serviceworker;
                _context.Issues.Add(issue);
                await _context.SaveChangesAsync();

            }
            catch
            {
                return new BadRequestResult();
            }
            return new OkResult();
        }


        // PUT: api/Issues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIssue(int id, Issue issue)
        {
            if (id != issue.Id)
            {
                return BadRequest();
            }

            _context.Entry(issue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssueExists(id))
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

        // POST: api/Issues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Issue>> PostIssue(Issue issue)
        {
            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIssue", new { id = issue.Id }, issue);
        }



        // DELETE: api/Issues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIssue(int id)
        {
            var issue = await _context.Issues.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }

            _context.Issues.Remove(issue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IssueExists(int id)
        {
            return _context.Issues.Any(e => e.Id == id);
        }
    }
}
