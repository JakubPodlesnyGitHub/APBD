using EntityFrameWorkCoreApp.Models;
using EntityFrameWorkCoreApp.Models.DTO.Requests;
using EntityFrameWorkCoreApp.Models.DTO.Response;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameWorkCoreApp
{
    public class SqlService
    {
        private s20540Context _Context;

        public SqlService(s20540Context context)
        {
            _Context = context;
        }

        public async Task<IEnumerable<GetTripInfoDTO>> GetTravelers()
        {
            return await _Context.Trips.Include(trip => trip.ClientTrips)
            .ThenInclude(trip => trip.IdClientNavigation)
            .Include(trip => trip.CountryTrips)
            .ThenInclude(trip => trip.IdCountryNavigation)
                .Select(e => new GetTripInfoDTO
                {
                    Name = e.Name,
                    Description = e.Description,
                    DateFrom = e.DateFrom,
                    DateTo = e.DateTo,
                    MaxPeople = e.MaxPeople,
                    Countries = e.CountryTrips.Select(eT => new GetCountryInfoDTO { Name = eT.IdCountryNavigation.Name }).ToList(),
                    Clients = e.ClientTrips.Select(c => new GetClinetInfoDTO { FirstName = c.IdClientNavigation.FirstName, LastName = c.IdClientNavigation.LastName }).ToList()
                }).OrderByDescending(e => e.DateFrom).ToListAsync();
        }

        public async Task<int> DeleteTraveler(int idTraveler)
        {
            if (_Context.Clients.Include(c => c.ClientTrips).Any(c => c.ClientTrips.Any(ct => ct.IdClient == idTraveler)))
                return -1;

            var clientToRemoved = await _Context.Clients.FirstAsync(cl => cl.IdClient == idTraveler);
            _Context.Clients.Attach(clientToRemoved);
            _Context.Entry(clientToRemoved).State = EntityState.Deleted;
            await _Context.SaveChangesAsync();
            return idTraveler;
        }

        public async Task<string> AddNewClient(CreateClientAndTripRequestDTO requestDTO, int idTrip)
        {
            var client = new Client
            {
                FirstName = requestDTO.FirstName,
                LastName = requestDTO.LastName,
                Email = requestDTO.Email,
                Telephone = requestDTO.Telephone,
                Pesel = requestDTO.Pesel
            };

            if (!await _Context.Clients.AnyAsync(c => c.Pesel == client.Pesel))
            {
                _Context.Clients.Attach(client);
                _Context.Entry(client).State = EntityState.Added;
                await _Context.SaveChangesAsync();
            }

            int idClinet = await _Context.Clients.Where(c => c.FirstName == client.FirstName && c.LastName == client.LastName).Select(c => c.IdClient).FirstOrDefaultAsync();

            var client_Trip = new ClientTrip
            {
                IdClient = idClinet,
                IdTrip = idTrip,
                PaymentDate = requestDTO.PaymentDate,
                RegisteredAt = DateTime.Today
            };

            if (await _Context.ClientTrips.AnyAsync(cT => cT.IdClient == idClinet && cT.IdTrip == client_Trip.IdTrip))
                throw new Exception("This customer is already signed up for this tour");

            var trip = new Trip
            {
                Name = requestDTO.TripName
            };

            if (!await _Context.Trips.AnyAsync(tr => tr.Name == trip.Name && tr.IdTrip == client_Trip.IdTrip))
                throw new Exception("Tour doesn't exist");

            _Context.ClientTrips.Attach(client_Trip);
            _Context.Entry(client_Trip).State = EntityState.Added;
            await _Context.SaveChangesAsync();

            return "Client: " + client.FirstName + " " + client.LastName + " has been added to: " + trip.Name;
        }
    }
}
