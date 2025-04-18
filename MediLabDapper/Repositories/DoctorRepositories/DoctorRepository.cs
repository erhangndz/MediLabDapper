﻿using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.DoctorDtos;
using System.Data;

namespace MediLabDapper.Repositories.DoctorRepositories
{
    public class DoctorRepository(DapperContext _context) : IDoctorRepository
    {
        private readonly IDbConnection _db = _context.CreateConnection();
        public async Task CreateDoctorAsync(CreateDoctorDto createDoctorDto)
        {
            var query = "insert into doctors (nameSurname, ImageUrl, description, departmentId) values (@NameSurname, @ImageUrl, @Description, @DepartmentId)";
            var parameters = new DynamicParameters(createDoctorDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var query = "delete from doctors where DoctorId=@DoctorId";
            var parameter = new DynamicParameters();
            parameter.Add("@DoctorId", id);
            await _db.ExecuteAsync(query, parameter);
        }

        public async Task<IEnumerable<ResultDoctorDto>> GetAllDoctorsAsync()
        {
            var query = "select * from doctors";
            return await _db.QueryAsync<ResultDoctorDto>(query);
        }

        public async Task<GetDoctorByIdDto> GetDoctorByIdAsync(int id)
        {
            var query = "select * from doctors where DoctorId= @DoctorId";
            var parameter = new DynamicParameters();
            parameter.Add("@DoctorId", id);
            return await _db.QueryFirstOrDefaultAsync<GetDoctorByIdDto>(query,parameter); 
        }

        public async Task<IEnumerable<ResultDoctorWithDepartmentDto>> GetDoctorsWithDepartmentAsync()
        {
            var query = "select DoctorId, NameSurname, ImageUrl, doctors.Description, DepartmentName from doctors inner join departments on doctors.DepartmentId=departments.DepartmentId";
            return await _db.QueryAsync<ResultDoctorWithDepartmentDto>(query); 
        }

        public async Task UpdateDoctorAsync(UpdateDoctorDto updateDoctorDto)
        {
            var query = "update doctors set NameSurname=@NameSurname, Description= @Description, ImageUrl= @ImageUrl, DepartmentId= @DepartmentId where DoctorId=@DoctorId ";
            var parameters = new DynamicParameters(updateDoctorDto);
            await _db.ExecuteAsync(query, parameters); 
        }
    }
}
