using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Student> GetStudentAsync(int id)
        {
            return await _context.Students
            .Include(nameof(Gender))
            .Include(nameof(Address))
            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.Students
            .Include(nameof(Gender))
            .Include(nameof(Address))
            .ToListAsync();
        }
    }
}