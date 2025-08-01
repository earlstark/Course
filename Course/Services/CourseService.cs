using System.Security.Claims;
using Course.Data;
using Course.Dtos;
using Course.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Course.Services
{
    public class CourseService : ICourseService
    {

        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Task CreateAsync(CourseDto data)
        {
            return _courseRepository.CreateAsync(MapToModel(data));
        }

        public Task<bool> DeleteAsync(int id)
            => _courseRepository.DeleteAsync(id);

        public async Task<List<CourseDto>> GetAllAsync()
        {
            var courses = await _courseRepository.GetAllAsync();

            return courses.Select(MapToDto).ToList();
        }

        public async Task<CourseDto?> GetByIdAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            return course != null ? MapToDto(course) : null;
        }

        public async Task<CourseDto?> UpdateAsync(int id, CourseDto data)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            if (course != null)
            {
                course.Id = data.Id;
                course.Title = data.Title;
                course.Description = data.Description;
                course.AuthorId = data.AuthorId;
                await _courseRepository.UpdateAsync();
            }

            return course != null ? MapToDto(course) : null;
        }

        private static CourseDto MapToDto(Course.Data.Course course) => new()
        {
            Id = course.Id,
            Title = course.Title,
            Description = course.Description,
            AuthorId = course.AuthorId,
        };

        private static Course.Data.Course MapToModel(CourseDto courseDto) => new()
        {
            Id = courseDto.Id,
            Title = courseDto.Title,
            Description = courseDto.Description,
            AuthorId = courseDto.AuthorId,
        };

    }
}
