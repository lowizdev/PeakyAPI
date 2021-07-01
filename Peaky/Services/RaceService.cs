using Peaky.Models;
using Peaky.Models.DTOs;
using Peaky.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Services
{
    public class RaceService : IRaceService
    {

        private IRaceRepository _raceRepository;

        public RaceService(IRaceRepository raceRepository)
        {
            this._raceRepository = raceRepository;
        }

        public async Task<Race> Create(CreateRaceDTO element)
        {
            Race race = new Race();

            DateTime dt = new DateTime();

            var parseResult = DateTime.TryParse(element.raceDate, out dt);

            if (!parseResult) {

                dt = new DateTime();

            }

            race.description = element.description;
            race.race_date = dt;

            var result = await this._raceRepository.InsertOne(race);

            if (result != 0) {

                return race;

            }

            return null;
        }

        public Task<bool> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Race> ReadAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Race> ReadById(int id)
        {
            Race race = await this._raceRepository.GetOneById(id);

            return race;

        }

        public async Task<Race> RegisterHorseToRace(Race race, Horse horse) {

            var currentHorseQuantityInRace = await this._raceRepository.GetHorseQuantity(race);

            //A SAMPLE BUSINESS RULE
            if ( currentHorseQuantityInRace < 3 ) { //OTHERS MIGHT GO IN SAME CONDITION

                var resultRace = await this._raceRepository.AddHorse(race, horse);

                return resultRace;

            }

            return null;
        
        }

        /*public async Task<int> ReadQuantityOfHorsesInRace(Race race)
        {

            return await this._raceRepository.GetHorseQuantity(race);

        }*/
    }
}
