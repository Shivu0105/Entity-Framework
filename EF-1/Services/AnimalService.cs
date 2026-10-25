using EF_1.Models;
using EF_1.Repository;
using Microsoft.EntityFrameworkCore;

namespace EF_1.Services
{
    public class AnimalService
    {
        private readonly AnimalDB _animal;
        public AnimalService(AnimalDB animal)
        {
            _animal = animal;
        }

        public async Task<List<Animals>> GetAnimalsAsync()
        {
            return await _animal.AnimalsTable.ToListAsync();
        }

        public async Task<string> AddAnimal(Animals entity)
        {
            try
            {
                _animal.AnimalsTable.Add(entity);
                await _animal.SaveChangesAsync();
                return "Data Saved Successfully";
            }
            catch (Exception ex)
            {
                return $"Error occurred while saving data: {ex.Message}";
            }
        }

        public async Task<string> DeleteAnimal(int Id)
        {
            try
            {
                var entity = await _animal.AnimalsTable.FindAsync(Id);
                if (entity == null)
                {
                    return "Animal not found";
                }
                _animal.AnimalsTable.Remove(entity);
                await _animal.SaveChangesAsync();
                return "Animal deleted successfully";
            }
            catch (Exception ex)
            {
                return $"Error occurred while deleting data: {ex.Message}";
            }
        }

        public async Task<string> UpdateAnimal(int Id, Animals entity)
        {
            try
            {
                var existingEntity = await _animal.AnimalsTable.FindAsync(Id);
                if (existingEntity == null)
                {
                    return "Animal not found";
                }
                existingEntity.Name = entity.Name;
                existingEntity.Type = entity.Type;
                existingEntity.Color = entity.Color;
                existingEntity.Diet = entity.Diet;

                _animal.AnimalsTable.Update(existingEntity);
                await _animal.SaveChangesAsync();
                return "Animal updated successfully";
            }
            catch (Exception ex)
            {
                return $"Error occurred while updating data: {ex.Message}"; 
            }
        }
    }
}
