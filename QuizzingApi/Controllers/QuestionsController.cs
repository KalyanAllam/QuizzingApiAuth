using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizzingApi.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
 using Microsoft.AspNetCore.Authorization;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;

namespace QuizzingApi.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Policy = "CustomAuthentication")]
    [System.Web.Http.Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly JkoatuolContext _context;

        public QuestionsController(JkoatuolContext context)
        {
            _context = context;
        }

        // GET: api/Questions

        [HttpGet("api/Questions")]

        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
          if (_context.Questions == null)
          {
              return NotFound();
          }
            return await _context.Questions.ToListAsync();
        }

    
      

        private bool QuestionExists(int id)
        {
            return (_context.Questions?.Any(e => e.No == id)).GetValueOrDefault();
        }
    }
}
