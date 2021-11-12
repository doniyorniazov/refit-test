using Refit;
using SimpleUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleUI.DataAccess
{
    public interface IGuestData
    {
        [Get("/Guests")]
        Task<List<GuestModel>> GetGuests();

        [Get("/Guests/(id)")]
        Task<GuestModel> GetGuest(int id);

        [Post("/Guiests")]
        Task CreateGuest([Body] GuestModel guest);

        [Put("/Guests/{id}")]
        Task UpdateGeuest(int id, [Body] GuestModel geuest);

        [Delete("/Guests/{id}")]
        Task DeleteGuest(int id);
    }
}
