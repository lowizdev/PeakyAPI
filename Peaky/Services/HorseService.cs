using Peaky.Infra.PgSQL;
using Peaky.Models;
using Peaky.Models.DTOs;
using Peaky.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Services
{
    public class HorseService : IHorseService
    {

        private IHorseRepository _repository = null;
        private IUnitOfWork _unitOfWork = null;

        public HorseService(IHorseRepository repository, IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<Horse> Create(CreateHorseDTO element)
        {
            Horse horse = new Horse();

            horse.name = element.name;
            horse.age = element.age;

            var result = await this._repository.InsertOne(horse);

            if (result != 0) {
                return horse;
            }

            return null;
        }

        public Task<bool> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Horse>> ReadAll()
        {
            return await this._repository.GetAll();
        }

        public async Task<Horse> ReadById(int id)
        {

            this._unitOfWork.BeginTransaction(); //DEMONSTRATION ONLY

            Horse horse = await this._repository.GetOneById(id);

            this._unitOfWork.Commit();

            return horse;

        }
    }
}
