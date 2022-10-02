using TestIntComex.Core.DTOs;
using TestIntComex.Core.Entities;

namespace TestIntComex.Core.Interfaces
{
    public interface IInformationContactRepository
    {
        Task<List<ListContactsDto>> ListContacts();
        Task<List<TbContactType>> ListContactsType();
        Task<ResultsDto> SaveInformation(TbContact contact);
        Task<bool> IsFullContactType();
        Task<ResultsDto> FillContactType();
    }
}
